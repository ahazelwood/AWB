Namespace AutoWikiBrowser.Plugins.SDKSoftware.Kingbotk.Plugins
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class WPNovelSettings
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.WorkgroupsGroupBox = New System.Windows.Forms.GroupBox
            Me.SFCheckBox = New System.Windows.Forms.CheckBox
            Me.ShortStoryCheckBox = New System.Windows.Forms.CheckBox
            Me.CrimeCheckBox = New System.Windows.Forms.CheckBox
            Me.StubClassCheckBox = New System.Windows.Forms.CheckBox
            Me.AutoStubCheckBox = New System.Windows.Forms.CheckBox
            Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
            Me.ParametersGroup = New System.Windows.Forms.GroupBox
            Me.TextInsertContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.WPNovelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.NovelsWikiProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.TaskForcesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.ShortStoriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.CrimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.ScienceFictionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me.NeedsAttentionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.NovelinfoboxneededToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.NovelinfoboxincompToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.CoverNeededToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
            Me.CollaborationCandidateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.PastCollaborationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.PeerReviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.OldPeerReviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
            Me.AutotaggedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.ClassListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.StCoverNeededToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.WorkgroupsGroupBox.SuspendLayout()
            Me.ParametersGroup.SuspendLayout()
            Me.TextInsertContextMenuStrip.SuspendLayout()
            Me.SuspendLayout()
            '
            'WorkgroupsGroupBox
            '
            Me.WorkgroupsGroupBox.Controls.Add(Me.SFCheckBox)
            Me.WorkgroupsGroupBox.Controls.Add(Me.ShortStoryCheckBox)
            Me.WorkgroupsGroupBox.Controls.Add(Me.CrimeCheckBox)
            Me.WorkgroupsGroupBox.Location = New System.Drawing.Point(141, 6)
            Me.WorkgroupsGroupBox.Name = "WorkgroupsGroupBox"
            Me.WorkgroupsGroupBox.Size = New System.Drawing.Size(123, 82)
            Me.WorkgroupsGroupBox.TabIndex = 2
            Me.WorkgroupsGroupBox.TabStop = False
            Me.WorkgroupsGroupBox.Text = "Workgroups"
            Me.ToolTip1.SetToolTip(Me.WorkgroupsGroupBox, "a&e-work-group=yes")
            '
            'SFCheckBox
            '
            Me.SFCheckBox.AutoSize = True
            Me.SFCheckBox.Location = New System.Drawing.Point(6, 63)
            Me.SFCheckBox.Name = "SFCheckBox"
            Me.SFCheckBox.Size = New System.Drawing.Size(39, 17)
            Me.SFCheckBox.TabIndex = 8
            Me.SFCheckBox.Text = "SF"
            Me.ToolTip1.SetToolTip(Me.SFCheckBox, "musician-work-group=yes")
            Me.SFCheckBox.UseVisualStyleBackColor = True
            '
            'ShortStoryCheckBox
            '
            Me.ShortStoryCheckBox.AutoSize = True
            Me.ShortStoryCheckBox.Location = New System.Drawing.Point(6, 41)
            Me.ShortStoryCheckBox.Name = "ShortStoryCheckBox"
            Me.ShortStoryCheckBox.Size = New System.Drawing.Size(78, 17)
            Me.ShortStoryCheckBox.TabIndex = 3
            Me.ShortStoryCheckBox.Text = "Short Story"
            Me.ToolTip1.SetToolTip(Me.ShortStoryCheckBox, "military-work-group=yes")
            Me.ShortStoryCheckBox.UseVisualStyleBackColor = True
            '
            'CrimeCheckBox
            '
            Me.CrimeCheckBox.AutoSize = True
            Me.CrimeCheckBox.Location = New System.Drawing.Point(6, 19)
            Me.CrimeCheckBox.Name = "CrimeCheckBox"
            Me.CrimeCheckBox.Size = New System.Drawing.Size(52, 17)
            Me.CrimeCheckBox.TabIndex = 3
            Me.CrimeCheckBox.Text = "Crime"
            Me.ToolTip1.SetToolTip(Me.CrimeCheckBox, "a&e-work-group=yes")
            Me.CrimeCheckBox.UseVisualStyleBackColor = True
            '
            'StubClassCheckBox
            '
            Me.StubClassCheckBox.AutoSize = True
            Me.StubClassCheckBox.Location = New System.Drawing.Point(6, 42)
            Me.StubClassCheckBox.Name = "StubClassCheckBox"
            Me.StubClassCheckBox.Size = New System.Drawing.Size(76, 17)
            Me.StubClassCheckBox.TabIndex = 3
            Me.StubClassCheckBox.Text = "Stub-Class"
            Me.ToolTip1.SetToolTip(Me.StubClassCheckBox, "class=Stub (not for use in bot mode; use Auto-Stub)")
            Me.StubClassCheckBox.UseVisualStyleBackColor = True
            '
            'AutoStubCheckBox
            '
            Me.AutoStubCheckBox.AutoSize = True
            Me.AutoStubCheckBox.Location = New System.Drawing.Point(6, 19)
            Me.AutoStubCheckBox.Name = "AutoStubCheckBox"
            Me.AutoStubCheckBox.Size = New System.Drawing.Size(73, 17)
            Me.AutoStubCheckBox.TabIndex = 2
            Me.AutoStubCheckBox.Text = "Auto-Stub"
            Me.ToolTip1.SetToolTip(Me.AutoStubCheckBox, "class=Stub|auto=yes")
            Me.AutoStubCheckBox.UseVisualStyleBackColor = True
            '
            'LinkLabel1
            '
            Me.LinkLabel1.AutoSize = True
            Me.LinkLabel1.Location = New System.Drawing.Point(154, 315)
            Me.LinkLabel1.Name = "LinkLabel1"
            Me.LinkLabel1.Size = New System.Drawing.Size(110, 13)
            Me.LinkLabel1.TabIndex = 7
            Me.LinkLabel1.TabStop = True
            Me.LinkLabel1.Text = "{{NovelsWikiProject}}"
            '
            'ParametersGroup
            '
            Me.ParametersGroup.Controls.Add(Me.StubClassCheckBox)
            Me.ParametersGroup.Controls.Add(Me.AutoStubCheckBox)
            Me.ParametersGroup.Location = New System.Drawing.Point(12, 6)
            Me.ParametersGroup.Name = "ParametersGroup"
            Me.ParametersGroup.Size = New System.Drawing.Size(123, 74)
            Me.ParametersGroup.TabIndex = 8
            Me.ParametersGroup.TabStop = False
            Me.ParametersGroup.Text = "Template Parameters"
            '
            'TextInsertContextMenuStrip
            '
            Me.TextInsertContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WPNovelsToolStripMenuItem})
            Me.TextInsertContextMenuStrip.Name = "TextInsertContextMenuStrip"
            Me.TextInsertContextMenuStrip.Size = New System.Drawing.Size(153, 48)
            '
            'WPNovelsToolStripMenuItem
            '
            Me.WPNovelsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NovelsWikiProjectToolStripMenuItem, Me.TaskForcesToolStripMenuItem, Me.ToolStripSeparator2, Me.NeedsAttentionToolStripMenuItem, Me.NovelinfoboxneededToolStripMenuItem, Me.NovelinfoboxincompToolStripMenuItem, Me.CoverNeededToolStripMenuItem, Me.StCoverNeededToolStripMenuItem, Me.ToolStripSeparator4, Me.CollaborationCandidateToolStripMenuItem, Me.PastCollaborationToolStripMenuItem, Me.PeerReviewToolStripMenuItem, Me.OldPeerReviewToolStripMenuItem, Me.ToolStripSeparator3, Me.AutotaggedToolStripMenuItem, Me.ClassListToolStripMenuItem})
            Me.WPNovelsToolStripMenuItem.Name = "WPNovelsToolStripMenuItem"
            Me.WPNovelsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.WPNovelsToolStripMenuItem.Text = "WPNovels"
            '
            'NovelsWikiProjectToolStripMenuItem
            '
            Me.NovelsWikiProjectToolStripMenuItem.Name = "NovelsWikiProjectToolStripMenuItem"
            Me.NovelsWikiProjectToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
            Me.NovelsWikiProjectToolStripMenuItem.Text = "{{NovelsWikiProject}}"
            '
            'TaskForcesToolStripMenuItem
            '
            Me.TaskForcesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShortStoriesToolStripMenuItem, Me.ToolStripSeparator1, Me.CrimeToolStripMenuItem, Me.ScienceFictionToolStripMenuItem})
            Me.TaskForcesToolStripMenuItem.Name = "TaskForcesToolStripMenuItem"
            Me.TaskForcesToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
            Me.TaskForcesToolStripMenuItem.Text = "Task Forces"
            '
            'ShortStoriesToolStripMenuItem
            '
            Me.ShortStoriesToolStripMenuItem.Name = "ShortStoriesToolStripMenuItem"
            Me.ShortStoriesToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
            Me.ShortStoriesToolStripMenuItem.Text = "Short Stories"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(152, 6)
            '
            'CrimeToolStripMenuItem
            '
            Me.CrimeToolStripMenuItem.Name = "CrimeToolStripMenuItem"
            Me.CrimeToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
            Me.CrimeToolStripMenuItem.Text = "Crime"
            '
            'ScienceFictionToolStripMenuItem
            '
            Me.ScienceFictionToolStripMenuItem.Name = "ScienceFictionToolStripMenuItem"
            Me.ScienceFictionToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
            Me.ScienceFictionToolStripMenuItem.Text = "Science Fiction"
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(197, 6)
            '
            'NeedsAttentionToolStripMenuItem
            '
            Me.NeedsAttentionToolStripMenuItem.Name = "NeedsAttentionToolStripMenuItem"
            Me.NeedsAttentionToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
            Me.NeedsAttentionToolStripMenuItem.Text = "Needs Attention"
            '
            'NovelinfoboxneededToolStripMenuItem
            '
            Me.NovelinfoboxneededToolStripMenuItem.Name = "NovelinfoboxneededToolStripMenuItem"
            Me.NovelinfoboxneededToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
            Me.NovelinfoboxneededToolStripMenuItem.Text = "Needs Infobox"
            '
            'NovelinfoboxincompToolStripMenuItem
            '
            Me.NovelinfoboxincompToolStripMenuItem.Name = "NovelinfoboxincompToolStripMenuItem"
            Me.NovelinfoboxincompToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
            Me.NovelinfoboxincompToolStripMenuItem.Text = "Incomplete Infobox"
            '
            'CoverNeededToolStripMenuItem
            '
            Me.CoverNeededToolStripMenuItem.Name = "CoverNeededToolStripMenuItem"
            Me.CoverNeededToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
            Me.CoverNeededToolStripMenuItem.Text = "Cover needed"
            '
            'ToolStripSeparator4
            '
            Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
            Me.ToolStripSeparator4.Size = New System.Drawing.Size(197, 6)
            '
            'CollaborationCandidateToolStripMenuItem
            '
            Me.CollaborationCandidateToolStripMenuItem.Name = "CollaborationCandidateToolStripMenuItem"
            Me.CollaborationCandidateToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
            Me.CollaborationCandidateToolStripMenuItem.Text = "Collaboration Candidate"
            '
            'PastCollaborationToolStripMenuItem
            '
            Me.PastCollaborationToolStripMenuItem.Name = "PastCollaborationToolStripMenuItem"
            Me.PastCollaborationToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
            Me.PastCollaborationToolStripMenuItem.Text = "Past Collaboration"
            '
            'PeerReviewToolStripMenuItem
            '
            Me.PeerReviewToolStripMenuItem.Name = "PeerReviewToolStripMenuItem"
            Me.PeerReviewToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
            Me.PeerReviewToolStripMenuItem.Text = "Peer Review"
            '
            'OldPeerReviewToolStripMenuItem
            '
            Me.OldPeerReviewToolStripMenuItem.Name = "OldPeerReviewToolStripMenuItem"
            Me.OldPeerReviewToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
            Me.OldPeerReviewToolStripMenuItem.Text = "Old Peer Review"
            '
            'ToolStripSeparator3
            '
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            Me.ToolStripSeparator3.Size = New System.Drawing.Size(197, 6)
            '
            'AutotaggedToolStripMenuItem
            '
            Me.AutotaggedToolStripMenuItem.Name = "AutotaggedToolStripMenuItem"
            Me.AutotaggedToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
            Me.AutotaggedToolStripMenuItem.Text = "Auto-tagged"
            '
            'ClassListToolStripMenuItem
            '
            Me.ClassListToolStripMenuItem.Name = "ClassListToolStripMenuItem"
            Me.ClassListToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
            Me.ClassListToolStripMenuItem.Text = "class=List"
            '
            'StCoverNeededToolStripMenuItem
            '
            Me.StCoverNeededToolStripMenuItem.Name = "StCoverNeededToolStripMenuItem"
            Me.StCoverNeededToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
            Me.StCoverNeededToolStripMenuItem.Text = "1st Cover needed"
            '
            'WPNovelSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.ParametersGroup)
            Me.Controls.Add(Me.WorkgroupsGroupBox)
            Me.Controls.Add(Me.LinkLabel1)
            Me.MaximumSize = New System.Drawing.Size(276, 349)
            Me.MinimumSize = New System.Drawing.Size(276, 349)
            Me.Name = "WPNovelSettings"
            Me.Size = New System.Drawing.Size(276, 349)
            Me.WorkgroupsGroupBox.ResumeLayout(False)
            Me.WorkgroupsGroupBox.PerformLayout()
            Me.ParametersGroup.ResumeLayout(False)
            Me.ParametersGroup.PerformLayout()
            Me.TextInsertContextMenuStrip.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Private WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Private WithEvents WorkgroupsGroupBox As System.Windows.Forms.GroupBox
        Private WithEvents CrimeCheckBox As System.Windows.Forms.CheckBox
        Private WithEvents ShortStoryCheckBox As System.Windows.Forms.CheckBox
        Private WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
        Private WithEvents SFCheckBox As System.Windows.Forms.CheckBox
        Private WithEvents ParametersGroup As System.Windows.Forms.GroupBox
        Private WithEvents StubClassCheckBox As System.Windows.Forms.CheckBox
        Private WithEvents AutoStubCheckBox As System.Windows.Forms.CheckBox
        Private WithEvents TextInsertContextMenuStrip As System.Windows.Forms.ContextMenuStrip
        Private WithEvents WPNovelsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents NovelsWikiProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents NovelinfoboxneededToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents NovelinfoboxincompToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents ClassListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents CoverNeededToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents TaskForcesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ShortStoriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents CrimeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ScienceFictionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents NeedsAttentionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents CollaborationCandidateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents PastCollaborationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents PeerReviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents OldPeerReviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents AutotaggedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents StCoverNeededToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    End Class
End Namespace