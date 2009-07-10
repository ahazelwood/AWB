﻿/*
Copyright (C) 2008 Max Semenik

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/
using System;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

namespace WikiFunctions.API
{
    public delegate void AsyncEventHandler(AsyncApiEdit sender);
    public delegate void AsyncStringEventHandler(AsyncApiEdit sender, string result);
    public delegate void AsyncExceptionEventHandler(AsyncApiEdit sender, Exception ex);

    /// <summary>
    /// Multithreaded API editor class
    /// </summary>
    public class AsyncApiEdit
    {
        private Thread TheThread;
        private readonly Control ParentControl;

        public AsyncApiEdit(string url)
            :this(url, null, false)
        {
        }

        public AsyncApiEdit(string url, bool php5)
            : this(url, null, php5)
        {
        }

        public AsyncApiEdit(string url, Control parentControl)
            : this(url, parentControl, false)
        {
        }

        public AsyncApiEdit(string url, Control parentControl, bool php5)
            : this(new ApiEdit(url, php5), parentControl)
        {
        }

        private AsyncApiEdit(ApiEdit editor, Control parentControl)
        {
            SynchronousEditor = editor;
            ParentControl = parentControl;
            State = EditState.Ready;
        }

        public AsyncApiEdit Clone()
        {
            return new AsyncApiEdit((ApiEdit)SynchronousEditor.Clone(), ParentControl);
        }

        /// <summary>
        /// Provides access to the underlying ApiEdit
        /// </summary>
        public ApiEdit SynchronousEditor { get; private set; }

        public enum EditState
        {
            /// <summary>
            /// Nothing goes on, last operation completed successfully
            /// </summary>
            Ready,

            /// <summary>
            /// The editor is performing a background operation
            /// </summary>
            Working,

            /// <summary>
            /// Operation aborted
            /// </summary>
            Aborted,

            /// <summary>
            /// Last operation ended unsuccessfully
            /// </summary>
            Failed
        }

        private EditState mState = EditState.Ready;

        /// <summary>
        /// State of the editor
        /// </summary>
        public EditState State
        {
            get
            {
                return mState;
            }
            protected set
            {
                CallEvent(StateChanged, this);
                mState = value;
            }
        }

        /// <summary>
        /// True if the asynchronous
        /// </summary>
        public bool IsActive
        {
            get
            {
                return State == EditState.Working;
            }
        }

        /// <summary>
        /// Waits for asyncronous operation to complete
        /// </summary>
        public void Wait()
        {
            if (TheThread != null)
            {
                if (ParentControl != null && !ParentControl.InvokeRequired)
                {
                    // simple Thread.Joid() from UI thread would deadlock
                    while (IsActive) Application.DoEvents();
                }
                else
                {
                    TheThread.Join();
                }
            }
        }

        #region Events

        public event AsyncEventHandler SaveComplete;
        public event AsyncStringEventHandler PreviewComplete;

        public event AsyncExceptionEventHandler ExceptionCaught;
        public event AsyncEventHandler MaxlagExceeded;
        public event AsyncEventHandler LoggedOff;

        public event AsyncEventHandler StateChanged;

        #endregion

        #region Events internal
        delegate void OperationEndedInternal(string operation, object result);
        delegate void OperationFailedInternal(string operation, Exception ex);
        delegate void ExceptionCaughtInternal(Exception ex);

        protected virtual void OnOperationComplete(string operation, object result)
        {
            switch (operation)
            {
                case "Save":
                    if (SaveComplete != null) SaveComplete(this);
                    break;
                case "Preview":
                    if (PreviewComplete != null) PreviewComplete(this, (string)result);
                    break;
            }
        }

        protected virtual void OnOperationFailed(string operation, Exception ex)
        {
            Tools.WriteDebug("ApiEdit", ex.Message);

            if (ex is ApiMaxlagException)
            {
                if (MaxlagExceeded != null) MaxlagExceeded(this);
            }
            else if (ex is ApiLoggedOffException)
            {
                if (LoggedOff != null) LoggedOff(this);
            }

            else
                OnExceptionCaught(ex);
        }

        protected virtual void OnExceptionCaught(Exception ex)
        {
            if (ExceptionCaught != null) ExceptionCaught(this, ex);
        }
        #endregion

        #region Death magic invocations

        /// <summary>
        /// Invokes a supplied delegate. If the editor is owned by a control, the
        /// delegate will called from the control's thread, otherwise it will be 
        /// called from current thread.
        /// </summary>
        private void CallEvent(Delegate method, params object[] args)
        {
            if (method == null) return;

            if (ParentControl == null)
            {
                method.DynamicInvoke(args);
            }
            else
            {
                ParentControl.Invoke(method, args);
            }
        }

        private class InvokeArgs
        {
            public readonly string Function;
            public readonly object[] Arguments;

            public InvokeArgs(string func, params object[] args)
            {
                Function = func;
                Arguments = args;
            }
        };

        private void InvokerThread(object genericArgs)
        {
            string operation = null;

            try
            {
                InvokeArgs args = (InvokeArgs)genericArgs;
                operation = args.Function;

                Thread.CurrentThread.Name = string.Format("InvokerThread ({0})", args.Function);

                Type t = SynchronousEditor.GetType();

                object result = t.InvokeMember(
                    args.Function,                                  // name
                    BindingFlags.InvokeMethod,                      // invokeAttr
                    null,                                           // binder
                    SynchronousEditor,                                         // target
                    args.Arguments                                  // args
                    );

                TheThread = null;
                State = EditState.Ready;
                // No state changes past this point, the callback may launch another operation
                CallEvent(new OperationEndedInternal(OnOperationComplete), args.Function, result);
            }
            catch (ThreadAbortException)
            {
                SynchronousEditor.Reset();
                //TODO: maybe, an OperationAborted event is needed?
            }
            catch (Exception ex)
            {
                SynchronousEditor.Reset();

                if (ex is TargetInvocationException) ex = ex.InnerException;

                State = EditState.Failed;
                if (operation != null && ex is ApiException)
                {
                    CallEvent(new OperationFailedInternal(OnOperationFailed), operation, ex);
                }
                else
                {
                    CallEvent(new ExceptionCaughtInternal(OnExceptionCaught), ex);
                }
            }
            finally
            {
                TheThread = null;
            }
        }

        private void InvokeFunction(InvokeArgs args)
        {
            if (TheThread != null && TheThread.IsAlive)
                throw new ApiInvokeException("An asynchronous call is already being performed");

            State = EditState.Working;
            TheThread = new Thread(InvokerThread);
            TheThread.Start(args);
        }

        private void InvokeFunction(string name, params object[] args)
        {
            InvokeFunction(new InvokeArgs(name, args));
        }
        #endregion

        #region IApiEdit Members

        public string URL
        {
            get { return SynchronousEditor.URL; }
        }

        public bool PHP5
        {
            get { return SynchronousEditor.PHP5; }
        }

        public int Maxlag
        {
            get { return SynchronousEditor.Maxlag; }
            set { SynchronousEditor.Maxlag = value; }
        }

        public string Action
        {
            get { return SynchronousEditor.Action; }
        }

        public string HtmlHeaders
        {
            get { return SynchronousEditor.HtmlHeaders; }
        }

        public PageInfo Page
        {
            get { return SynchronousEditor.Page; }
        }

        public void Reset()
        {
            Abort();
            SynchronousEditor.Reset();
        }

        public void HttpGet(string url)
        {
            InvokeFunction("HttpGet", url);
        }

        public void Login(string username, string password)
        {
            InvokeFunction("Login", username, password);
        }

        public void Logout()
        {
            InvokeFunction("Logout");
        }

        public void Open(string title)
        {
            InvokeFunction("Open", title);
        }

        public void Save(string pageText, string summary, bool minor, bool watch)
        {
            InvokeFunction("Save", pageText, summary, minor, watch);
        }

        public void Watch(string title)
        {
            InvokeFunction("Watch", title);
        }

        public void Unwatch(string title)
        {
            InvokeFunction("Unwatch", title);
        }

        public void Delete(string title, string reason)
        {
            Delete(title, reason, false);
        }

        public void Delete(string title, string reason, bool watch)
        {
            InvokeFunction("Delete", title, reason, watch);
        }

        public void Protect(string title, string reason, string expiry, string edit, string move, bool cascade, bool watch)
        {
            InvokeFunction("Protect", title, reason, expiry, edit, move, cascade, watch);
        }

        public void Protect(string title, string reason, TimeSpan expiry, string edit, string move, bool cascade, bool watch)
        {
            Protect(title, reason, expiry.ToString(), edit, move, cascade, watch);
        }

        public void Protect(string title, string reason, string expiry, string edit, string move)
        {
            Protect(title, reason, expiry, edit, move, false, false);
        }

        public void Protect(string title, string reason, TimeSpan expiry, string edit, string move)
        {
            Protect(title, reason, expiry.ToString(), edit, move, false, false);
        }

        public void Move(string title, string newTitle, string reason)
        {
            Move(title, newTitle, reason, true, false, false);
        }

        public void Move(string title, string newTitle, string reason, bool moveTalk, bool noRedirect)
        {
            Move(title, newTitle, reason, moveTalk, noRedirect, false);
        }

        public void Move(string title, string newTitle, string reason, bool moveTalk, bool noRedirect, bool watch)
        {
            InvokeFunction("Move", title, newTitle, reason, moveTalk, noRedirect, watch);
        }

        public void Preview(string title, string text)
        {
            InvokeFunction("Preview", title, text);
        }

        public void ExpandTemplates(string title, string text)
        {
            InvokeFunction("ExpandTemplates", title, text);
        }

        public void Abort()
        {
            if (TheThread != null)
                TheThread.Abort();

            if (TheThread != null)
                TheThread.Join();
            TheThread = null; // the thread should reset this even if aborted, but let's be sure

            State = EditState.Aborted;
        }

        #endregion

        #region User info

        public UserInfo User
        {
            get { return SynchronousEditor.User; }
        }

        public void RefreshUserInfo()
        {
            InvokeFunction("RefreshUserInfo");
        }

        #endregion
    }
}
