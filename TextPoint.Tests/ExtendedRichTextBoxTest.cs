// <copyright file="ExtendedRichTextBoxTest.cs">Copyright ©  2016</copyright>
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextPoint;

namespace TextPoint.Tests
{
    /// <summary>This class contains parameterized unit tests for ExtendedRichTextBox</summary>
    [PexClass(typeof(ExtendedRichTextBox))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ExtendedRichTextBoxTest
    {
        /// <summary>Test stub for AppendWithColor(String, Color)</summary>
        [PexMethod]
        public void AppendWithColorTest(
            [PexAssumeUnderTest]ExtendedRichTextBox target,
            string text,
            Color color
        )
        {
            target.AppendWithColor(text, color);
            // TODO: add assertions to method ExtendedRichTextBoxTest.AppendWithColorTest(ExtendedRichTextBox, String, Color)
        }

        /// <summary>Test stub for Bold(Boolean)</summary>
        [PexMethod]
        public void BoldTest([PexAssumeUnderTest]ExtendedRichTextBox target, bool bold)
        {
            target.Bold(bold);
            // TODO: add assertions to method ExtendedRichTextBoxTest.BoldTest(ExtendedRichTextBox, Boolean)
        }

        /// <summary>Test stub for ChangeFormat(String, String)</summary>
        [PexMethod]
        public void ChangeFormatTest(
            [PexAssumeUnderTest]ExtendedRichTextBox target,
            string what,
            string value
        )
        {
            target.ChangeFormat(what, value);
            // TODO: add assertions to method ExtendedRichTextBoxTest.ChangeFormatTest(ExtendedRichTextBox, String, String)
        }

        /// <summary>Test stub for .ctor(RichTextBox)</summary>
        [PexMethod]
        public ExtendedRichTextBox ConstructorTest(RichTextBox rtb)
        {
            ExtendedRichTextBox target = new ExtendedRichTextBox(rtb);
            return target;
            // TODO: add assertions to method ExtendedRichTextBoxTest.ConstructorTest(RichTextBox)
        }

        /// <summary>Test stub for GetCurrentSize()</summary>
        [PexMethod]
        public string GetCurrentSizeTest([PexAssumeUnderTest]ExtendedRichTextBox target)
        {
            string result = target.GetCurrentSize();
            return result;
            // TODO: add assertions to method ExtendedRichTextBoxTest.GetCurrentSizeTest(ExtendedRichTextBox)
        }

        /// <summary>Test stub for Italic(Boolean)</summary>
        [PexMethod]
        public void ItalicTest([PexAssumeUnderTest]ExtendedRichTextBox target, bool italic)
        {
            target.Italic(italic);
            // TODO: add assertions to method ExtendedRichTextBoxTest.ItalicTest(ExtendedRichTextBox, Boolean)
        }

        /// <summary>Test stub for SameSizeSelection()</summary>
        [PexMethod]
        public bool SameSizeSelectionTest([PexAssumeUnderTest]ExtendedRichTextBox target)
        {
            bool result = target.SameSizeSelection();
            return result;
            // TODO: add assertions to method ExtendedRichTextBoxTest.SameSizeSelectionTest(ExtendedRichTextBox)
        }

        /// <summary>Test stub for Underline(Boolean)</summary>
        [PexMethod]
        public void UnderlineTest(
            [PexAssumeUnderTest]ExtendedRichTextBox target,
            bool underline
        )
        {
            target.Underline(underline);
            // TODO: add assertions to method ExtendedRichTextBoxTest.UnderlineTest(ExtendedRichTextBox, Boolean)
        }
    }
}
