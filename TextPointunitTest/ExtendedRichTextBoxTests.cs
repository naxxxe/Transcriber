using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TextPointunitTest
{
    [TestClass()]
    public class ExtendedRichTextBoxTests
    {
        RichTextBox rtb;
        ExtendedRichTextBox ertb;

        [TestMethod()]
        public void AppendWithColorTest()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            Assert.IsTrue(rtb.Text.Length == 0);
            rtb.BackColor = Color.White;
            ertb.AppendWithColor("test", Color.Blue);
            rtb.SelectAll();
            Assert.AreEqual(Color.Blue, rtb.SelectionBackColor);
            Assert.AreNotEqual(rtb.BackColor, rtb.SelectionBackColor);
            Assert.IsTrue(rtb.Text.Contains("test"));
        }

        [TestMethod()]
        public void SameSizeSelectionTest_DifferentFonts_True()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.AppendText("testing1");
            rtb.SelectionFont = new Font("Arial", rtb.SelectionFont.Size);
            rtb.SelectedText = " testing2 ";
            rtb.AppendText("testing 3");
            rtb.SelectAll();
            Assert.IsNull(rtb.SelectionFont);
            Assert.IsTrue(ertb.SameSizeSelection());
        }
        [TestMethod()]
        public void SameSizeSelectionTest_DifferentFonts_False()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.AppendText("testing1");
            rtb.SelectionFont = new Font("Arial",28);
            rtb.SelectedText = " testing2 ";
            rtb.AppendText("testing 3");
            rtb.SelectAll();
            Assert.IsNull(rtb.SelectionFont);
            Assert.IsFalse(ertb.SameSizeSelection());
        }
        [TestMethod]
        public void SameSizeSelectionTest_SameFontDifferentSize_False()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.AppendText("testing1");
            rtb.SelectionFont = new Font(rtb.SelectionFont.Name, 28);
            rtb.SelectedText = " testing2 ";
            rtb.AppendText("testing 3");
            rtb.SelectAll();
            Assert.IsNotNull(rtb.SelectionFont);
            Assert.AreEqual(13, rtb.SelectionFont.Size);
            Assert.IsFalse(ertb.SameSizeSelection());
        }

        [TestMethod()]
        public void ChangeFormatTest_SetBold()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsFalse(rtb.SelectionFont.Bold);
            ertb.ChangeFormat("Bold", "bold");
            Assert.IsTrue(rtb.SelectionFont.Bold);
        }
        [TestMethod()]
        public void ChangeFormatTest_SetNotBold()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Bold);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsTrue(rtb.SelectionFont.Bold);
            ertb.ChangeFormat("Bold", "notbold");
            Assert.IsFalse(rtb.SelectionFont.Bold);
        }
        [TestMethod()]
        public void ChangeFormatTest_SetBold_MixedStyle()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsFalse(rtb.SelectionFont.Bold);
            rtb.DeselectAll();
            rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Bold);
            rtb.AppendText(" testing2");
            rtb.SelectAll();
            ertb.ChangeFormat("Bold", "unknown");
            Assert.IsTrue(rtb.SelectionFont.Bold);
        }

        [TestMethod()]
        public void ChangeFormatTest_SetItalic()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsFalse(rtb.SelectionFont.Italic);
            ertb.ChangeFormat("Italic", "italic");
            Assert.IsTrue(rtb.SelectionFont.Italic);
        }
        [TestMethod()]
        public void ChangeFormatTest_SetNotItalic()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Italic);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsTrue(rtb.SelectionFont.Italic);
            ertb.ChangeFormat("Italic", "notitalic");
            Assert.IsFalse(rtb.SelectionFont.Italic);
        }
        [TestMethod()]
        public void ChangeFormatTest_SetItalic_MixedStyle()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsFalse(rtb.SelectionFont.Italic);
            rtb.DeselectAll();
            rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Italic);
            rtb.AppendText(" testing2");
            rtb.SelectAll();
            ertb.ChangeFormat("Italic", "unknown");
            Assert.IsTrue(rtb.SelectionFont.Italic);
        }

        [TestMethod()]
        public void ChangeFormatTest_SetUnderline()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsFalse(rtb.SelectionFont.Underline);
            ertb.ChangeFormat("Underline", "underline");
            Assert.IsTrue(rtb.SelectionFont.Underline);
        }
        [TestMethod()]
        public void ChangeFormatTest_SetNotUnderline()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Underline);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsTrue(rtb.SelectionFont.Underline);
            ertb.ChangeFormat("Underline", "notunderline");
            Assert.IsFalse(rtb.SelectionFont.Underline);
        }
        [TestMethod()]
        public void ChangeFormatTest_SetUnderline_MixedStyle()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsFalse(rtb.SelectionFont.Underline);
            rtb.DeselectAll();
            rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Underline);
            rtb.AppendText(" testing2");
            rtb.SelectAll();
            ertb.ChangeFormat("Underline", "unknown");
            Assert.IsTrue(rtb.SelectionFont.Underline);
        }
        [TestMethod()]
        public void ChangeFormatTest_SetUnderlineKeepBold()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Bold);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsTrue(rtb.SelectionFont.Bold);
            ertb.ChangeFormat("Underline", "underline");
            Assert.IsTrue(rtb.SelectionFont.Underline);
            Assert.IsTrue(rtb.SelectionFont.Bold);
        }

        [TestMethod()]
        public void ChangeFormatTest_ChangeSize()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Bold);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsTrue(rtb.SelectionFont.Bold);
            string expectedfontname = rtb.SelectionFont.Name;
            float oldsize = rtb.SelectionFont.Size;
            ertb.ChangeFormat("Size", "28");
            string actualfontname = rtb.SelectionFont.Name;
            Assert.AreEqual(expectedfontname, actualfontname);
            float newsize = rtb.SelectionFont.Size;
            Assert.AreNotEqual(oldsize, newsize);
            Assert.IsTrue(rtb.SelectionFont.Bold);
        }

        [TestMethod()]
        public void ChangeFormatTest_ChangeSizeDifferentFont()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.AppendText("testing1");
            rtb.SelectionFont = new Font("Arial", rtb.SelectionFont.Size);
            rtb.AppendText(" testing2");
            rtb.SelectAll();
            Assert.IsNull(rtb.SelectionFont);
            ertb.ChangeFormat("Size", "28");
            Assert.IsTrue(ertb.SameSizeSelection());
            Assert.AreEqual("28", ertb.GetCurrentSize());
        }

   
        [TestMethod()]
        public void BoldTest_SetBold()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            ertb.Bold(true);
            Assert.IsTrue(rtb.SelectionFont.Bold);
        }
        [TestMethod()]
        public void BoldTest_SetNotBold()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.Font = new Font(rtb.Font, FontStyle.Bold);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsTrue(rtb.SelectionFont.Bold);
            ertb.Bold(false);
            Assert.IsFalse(rtb.SelectionFont.Bold);
        }

        [TestMethod()]
        public void ItalicTest_SetItalic()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            ertb.Italic(true);
            Assert.IsTrue(rtb.SelectionFont.Italic);
        }
        [TestMethod()]
        public void ItalicTest_SetNotItalic()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.Font = new Font(rtb.Font, FontStyle.Italic);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsTrue(rtb.SelectionFont.Italic);
            ertb.Italic(false);
            Assert.IsFalse(rtb.SelectionFont.Italic);
        }

        [TestMethod()]
        public void UnderlineTest_SetUnderline()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            ertb.Underline(true);
            Assert.IsTrue(rtb.SelectionFont.Underline);
        }
        [TestMethod()]
        public void UnderlineTest_SetNotUnderline()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.Font = new Font(rtb.Font, FontStyle.Underline);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsTrue(rtb.SelectionFont.Underline);
            ertb.Underline(false);
            Assert.IsFalse(rtb.SelectionFont.Underline);
        }
        [TestMethod()]
        public void UnderlineTest_SetBoldAndUnderline()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.Font = new Font(rtb.Font, FontStyle.Bold);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsTrue(rtb.SelectionFont.Bold);
            ertb.Underline(true);
            Assert.IsTrue(rtb.SelectionFont.Underline);
            Assert.IsTrue(rtb.SelectionFont.Bold);
        }
        [TestMethod()]
        public void UnderlineTest_SetItalicAndUnderline()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.Font = new Font(rtb.Font, FontStyle.Italic);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsTrue(rtb.SelectionFont.Italic);
            ertb.Underline(true);
            Assert.IsTrue(rtb.SelectionFont.Underline);
            Assert.IsTrue(rtb.SelectionFont.Italic);
        }
        [TestMethod()]
        public void StyleTest_SetAllStyles()
        {
            rtb = new RichTextBox();
            ertb = new ExtendedRichTextBox(rtb);
            rtb.Font = new Font(rtb.Font, FontStyle.Italic);
            rtb.AppendText("testing1");
            rtb.SelectAll();
            Assert.IsTrue(rtb.SelectionFont.Italic);
            ertb.Underline(true);
            ertb.Bold(true);
            Assert.IsTrue(rtb.SelectionFont.Underline);
            Assert.IsTrue(rtb.SelectionFont.Italic);
            Assert.IsTrue(rtb.SelectionFont.Bold);
        }
    }
}

