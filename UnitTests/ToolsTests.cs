﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using WikiFunctions;
using System.Text.RegularExpressions;

namespace UnitTests
{
    [TestFixture]
    public class ToolsTests
    {
        [SetUp]
        public void SetUp()
        {
            Globals.UnitTestMode = true;
        }

        [Test]
        public void TestInvalidChars()
        {
            Assert.IsTrue(Tools.IsValidTitle("test"));
            Assert.IsTrue(Tools.IsValidTitle("This is a_test"));
            Assert.IsTrue(Tools.IsValidTitle("123"));
            Assert.IsTrue(Tools.IsValidTitle("А & Б сидели на трубе! ة日?"));

            Assert.IsFalse(Tools.IsValidTitle(""), "Empty strings are not supposed to be valid titles");
            Assert.IsFalse(Tools.IsValidTitle("[xxx"));
            Assert.IsFalse(Tools.IsValidTitle("]abc"));
            Assert.IsFalse(Tools.IsValidTitle("{duh!"));
            Assert.IsFalse(Tools.IsValidTitle("}yoyo"));
            Assert.IsFalse(Tools.IsValidTitle("|pwn3d"));
            Assert.IsFalse(Tools.IsValidTitle("<1337"));
            Assert.IsFalse(Tools.IsValidTitle(">nooooo"));
            Assert.IsFalse(Tools.IsValidTitle("#yeee-hooo"));

            //Complex titles
            Assert.IsFalse(Tools.IsValidTitle("[test]#1"));
            Assert.IsFalse(Tools.IsValidTitle("_ _"), "Titles should be normalised before checking");
            Assert.IsTrue(Tools.IsValidTitle("http://www.wikipedia.org")); //unfortunately
            Assert.IsTrue(Tools.IsValidTitle("index.php/Viagra")); //even more unfortunately
            Assert.IsTrue(Tools.IsValidTitle("index.php?title=foobar"));
        }

        [Test]
        public void RemoveInvalidChars()
        {
            Assert.AreEqual(Tools.RemoveInvalidChars("tesT 123!"), "tesT 123!");
            Assert.AreEqual(Tools.RemoveInvalidChars("тест, ёпта"), "тест, ёпта");
            Assert.AreEqual(Tools.RemoveInvalidChars(""), "");
            Assert.AreEqual(Tools.RemoveInvalidChars("{<[test]>}"), "test");
            Assert.AreEqual(Tools.RemoveInvalidChars("#|#"), "");
            Assert.AreEqual(Tools.RemoveInvalidChars("http://www.wikipedia.org"), "http://www.wikipedia.org");
        }

        [Test]
        public void TestRomanNumbers()
        {
            Assert.IsTrue(Tools.IsRomanNumber("XVII"));
            Assert.IsTrue(Tools.IsRomanNumber("I"));

            Assert.IsFalse(Tools.IsRomanNumber("xvii"));
            Assert.IsFalse(Tools.IsRomanNumber("XXXXXX"));
            Assert.IsFalse(Tools.IsRomanNumber("V II"));
            Assert.IsFalse(Tools.IsRomanNumber("AAA"));
            Assert.IsFalse(Tools.IsRomanNumber("123"));
            Assert.IsFalse(Tools.IsRomanNumber(" "));
            Assert.IsFalse(Tools.IsRomanNumber(""));
        }

        [Test]
        public void TestCaseInsensitive()
        {
            Assert.AreEqual("", Tools.CaseInsensitive(""));
            Assert.AreEqual("123", Tools.CaseInsensitive("123"));
            Assert.AreEqual("-", Tools.CaseInsensitive("-"));

            Regex r = new Regex(Tools.CaseInsensitive("test"));
            Assert.IsTrue(r.IsMatch("test 123"));
            Assert.AreEqual("Test", r.Match("Test").Value);
            Assert.IsFalse(r.IsMatch("tEst"));

            r = new Regex(Tools.CaseInsensitive("Test"));
            Assert.IsTrue(r.IsMatch("test 123"));
            Assert.AreEqual("Test", r.Match("Test").Value);
            Assert.IsFalse(r.IsMatch("TEst"));

            r = new Regex(Tools.CaseInsensitive("[test}"));
            Assert.IsTrue(r.IsMatch("[test}"));
            Assert.IsFalse(r.IsMatch("[Test}"));
            Assert.IsFalse(r.IsMatch("test"));
        }

        [Test]
        public void TestAllCaseInsensitive()
        {
            Assert.AreEqual("", Tools.AllCaseInsensitive(""));
            Assert.AreEqual("123", Tools.AllCaseInsensitive("123"));
            Assert.AreEqual("-", Tools.AllCaseInsensitive("-"));

            Regex r = new Regex(Tools.AllCaseInsensitive("tEsT"));
            Assert.IsTrue(r.IsMatch("Test 123"));
            Assert.AreEqual("Test", r.Match("Test").Value);
            Assert.IsFalse(r.IsMatch("teZt"));

            r = new Regex(Tools.AllCaseInsensitive("[test}"));
            Assert.IsTrue(r.IsMatch("?(Test["));
            Assert.IsFalse(r.IsMatch("test"));
        }

        //[Test]
        public void TestTurnFirstToUpper()
        {
            Assert.AreEqual("", Tools.TurnFirstToUpper(""));
            Assert.AreEqual("ASDA", Tools.TurnFirstToUpper("ASDA"));
            Assert.AreEqual("ASDA", Tools.TurnFirstToUpper("aSDA"));
            Assert.AreEqual("%test", Tools.TurnFirstToUpper("%test"));
            Assert.AreEqual("Ыыыы", Tools.TurnFirstToUpper("ыыыы"));

            Variables.SetProject(LangCodeEnum.en, ProjectEnum.wiktionary);
            Assert.AreEqual("test", Tools.TurnFirstToUpper("test"));
            Assert.AreEqual("Test", Tools.TurnFirstToUpper("Test"));
        }

        //[Test]
        public void TestTurnFirstToLower()
        {
        }

        [Test]
        public void TestWordCount()
        {
            Assert.AreEqual(0, Tools.WordCount(""));
            Assert.AreEqual(0, Tools.WordCount("    "));
            Assert.AreEqual(1, Tools.WordCount("foo"));
            Assert.AreEqual(2, Tools.WordCount("Превед медвед"));

            Assert.AreEqual(1, Tools.WordCount("0"));
        }
    }

    [TestFixture]
    public class HumanCatKeyTests
    {
        [SetUp]
        public void SetUp()
        {
            Globals.UnitTestMode = true;
        }

        [Test]
        public void OneWordNames()
        {
            Assert.AreEqual("OneWordName", Tools.MakeHumanCatKey("OneWordName"));
        }

        [Test]
        public void WithRomanNumbers()
        {
            Assert.AreEqual("Doe, John III", Tools.MakeHumanCatKey("John Doe III"));
        }

        [Test]
        public void WithJrSr()
        {
            Assert.AreEqual("Doe, John Jr.", Tools.MakeHumanCatKey("John Doe, Jr."));
            Assert.AreEqual("Doe, John Sr.", Tools.MakeHumanCatKey("John Doe, Sr."));
        }
    }

}
