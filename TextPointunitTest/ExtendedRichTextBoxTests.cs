using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextPoint;
using System.Windows.Forms;
using System.Drawing;

namespace TextPointunitTest
{
    [TestClass()]
    public class ExtendedRichTextBoxTests
    {
        private RichTextBox _rtb;
        private ExtendedRichTextBox _ertb;

        [TestMethod()]
        public void AppendWithColorTest()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            Assert.IsTrue(_rtb.Text.Length == 0);
            _rtb.BackColor = Color.White;
            _ertb.AppendWithColor("test", Color.Blue);
            _rtb.SelectAll();
            Assert.AreEqual(Color.Blue, _rtb.SelectionBackColor);
            Assert.AreNotEqual(_rtb.BackColor, _rtb.SelectionBackColor);
            Assert.IsTrue(_rtb.Text.Contains("test"));
        }

        [TestMethod()]
        public void SameSizeSelectionTest_DifferentFonts_True()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.AppendText("testing1");
            _rtb.SelectionFont = new Font("Arial", _rtb.SelectionFont.Size);
            _rtb.SelectedText = " testing2 ";
            _rtb.AppendText("testing 3");
            _rtb.SelectAll();
            Assert.IsNull(_rtb.SelectionFont);
            Assert.IsTrue(_ertb.SameSizeSelection());
        }
        [TestMethod()]
        public void SameSizeSelectionTest_DifferentFonts_False()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.AppendText("testing1");
            _rtb.SelectionFont = new Font("Arial",28);
            _rtb.SelectedText = " testing2 ";
            _rtb.AppendText("testing 3");
            _rtb.SelectAll();
            Assert.IsNull(_rtb.SelectionFont);
            Assert.IsFalse(_ertb.SameSizeSelection());
        }
        [TestMethod]
        public void SameSizeSelectionTest_SameFontDifferentSize_False()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.AppendText("testing1");
            _rtb.SelectionFont = new Font(_rtb.SelectionFont.Name, 28);
            _rtb.SelectedText = " testing2 ";
            _rtb.AppendText("testing 3");
            _rtb.SelectAll();
            Assert.IsNotNull(_rtb.SelectionFont);
            Assert.AreEqual(13, _rtb.SelectionFont.Size);
            Assert.IsFalse(_ertb.SameSizeSelection());
        }

        [TestMethod()]
        public void ChangeFormatTest_SetBold()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsFalse(_rtb.SelectionFont.Bold);
            _ertb.ChangeFormat("Bold", "bold");
            Assert.IsTrue(_rtb.SelectionFont.Bold);
        }
        [TestMethod()]
        public void ChangeFormatTest_SetNotBold()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.SelectionFont = new Font(_rtb.SelectionFont, FontStyle.Bold);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsTrue(_rtb.SelectionFont.Bold);
            _ertb.ChangeFormat("Bold", "notbold");
            Assert.IsFalse(_rtb.SelectionFont.Bold);
        }
        [TestMethod()]
        public void ChangeFormatTest_SetBold_MixedStyle()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsFalse(_rtb.SelectionFont.Bold);
            _rtb.DeselectAll();
            _rtb.SelectionFont = new Font(_rtb.SelectionFont, FontStyle.Bold);
            _rtb.AppendText(" testing2");
            _rtb.SelectAll();
            _ertb.ChangeFormat("Bold", "unknown");
            Assert.IsTrue(_rtb.SelectionFont.Bold);
        }

        [TestMethod()]
        public void ChangeFormatTest_SetItalic()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsFalse(_rtb.SelectionFont.Italic);
            _ertb.ChangeFormat("Italic", "italic");
            Assert.IsTrue(_rtb.SelectionFont.Italic);
        }
        [TestMethod()]
        public void ChangeFormatTest_SetNotItalic()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.SelectionFont = new Font(_rtb.SelectionFont, FontStyle.Italic);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsTrue(_rtb.SelectionFont.Italic);
            _ertb.ChangeFormat("Italic", "notitalic");
            Assert.IsFalse(_rtb.SelectionFont.Italic);
        }
        [TestMethod()]
        public void ChangeFormatTest_SetItalic_MixedStyle()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsFalse(_rtb.SelectionFont.Italic);
            _rtb.DeselectAll();
            _rtb.SelectionFont = new Font(_rtb.SelectionFont, FontStyle.Italic);
            _rtb.AppendText(" testing2");
            _rtb.SelectAll();
            _ertb.ChangeFormat("Italic", "unknown");
            Assert.IsTrue(_rtb.SelectionFont.Italic);
        }

        [TestMethod()]
        public void ChangeFormatTest_SetUnderline()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsFalse(_rtb.SelectionFont.Underline);
            _ertb.ChangeFormat("Underline", "underline");
            Assert.IsTrue(_rtb.SelectionFont.Underline);
        }
        [TestMethod()]
        public void ChangeFormatTest_SetNotUnderline()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.SelectionFont = new Font(_rtb.SelectionFont, FontStyle.Underline);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsTrue(_rtb.SelectionFont.Underline);
            _ertb.ChangeFormat("Underline", "notunderline");
            Assert.IsFalse(_rtb.SelectionFont.Underline);
        }
        [TestMethod()]
        public void ChangeFormatTest_SetUnderline_MixedStyle()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsFalse(_rtb.SelectionFont.Underline);
            _rtb.DeselectAll();
            _rtb.SelectionFont = new Font(_rtb.SelectionFont, FontStyle.Underline);
            _rtb.AppendText(" testing2");
            _rtb.SelectAll();
            _ertb.ChangeFormat("Underline", "unknown");
            Assert.IsTrue(_rtb.SelectionFont.Underline);
        }
        [TestMethod()]
        public void ChangeFormatTest_SetUnderlineKeepBold()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.SelectionFont = new Font(_rtb.SelectionFont, FontStyle.Bold);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsTrue(_rtb.SelectionFont.Bold);
            _ertb.ChangeFormat("Underline", "underline");
            Assert.IsTrue(_rtb.SelectionFont.Underline);
            Assert.IsTrue(_rtb.SelectionFont.Bold);
        }

        [TestMethod()]
        public void ChangeFormatTest_ChangeSize()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.SelectionFont = new Font(_rtb.SelectionFont, FontStyle.Bold);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsTrue(_rtb.SelectionFont.Bold);
            string expectedfontname = _rtb.SelectionFont.Name;
            float oldsize = _rtb.SelectionFont.Size;
            _ertb.ChangeFormat("Size", "28");
            string actualfontname = _rtb.SelectionFont.Name;
            Assert.AreEqual(expectedfontname, actualfontname);
            float newsize = _rtb.SelectionFont.Size;
            Assert.AreNotEqual(oldsize, newsize);
            Assert.IsTrue(_rtb.SelectionFont.Bold);
        }

        [TestMethod()]
        public void ChangeFormatTest_ChangeSizeDifferentFont()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.AppendText("testing1");
            _rtb.SelectionFont = new Font("Arial", _rtb.SelectionFont.Size);
            _rtb.AppendText(" testing2");
            _rtb.SelectAll();
            Assert.IsNull(_rtb.SelectionFont);
            _ertb.ChangeFormat("Size", "28");
            Assert.IsTrue(_ertb.SameSizeSelection());
            Assert.AreEqual("28", _ertb.GetCurrentSize());
        }

   
        [TestMethod()]
        public void BoldTest_SetBold()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            _ertb.Bold(true);
            Assert.IsTrue(_rtb.SelectionFont.Bold);
        }
        [TestMethod()]
        public void BoldTest_SetNotBold()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.Font = new Font(_rtb.Font, FontStyle.Bold);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsTrue(_rtb.SelectionFont.Bold);
            _ertb.Bold(false);
            Assert.IsFalse(_rtb.SelectionFont.Bold);
        }

        [TestMethod()]
        public void ItalicTest_SetItalic()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            _ertb.Italic(true);
            Assert.IsTrue(_rtb.SelectionFont.Italic);
        }
        [TestMethod()]
        public void ItalicTest_SetNotItalic()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.Font = new Font(_rtb.Font, FontStyle.Italic);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsTrue(_rtb.SelectionFont.Italic);
            _ertb.Italic(false);
            Assert.IsFalse(_rtb.SelectionFont.Italic);
        }

        [TestMethod()]
        public void UnderlineTest_SetUnderline()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            _ertb.Underline(true);
            Assert.IsTrue(_rtb.SelectionFont.Underline);
        }
        [TestMethod()]
        public void UnderlineTest_SetNotUnderline()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.Font = new Font(_rtb.Font, FontStyle.Underline);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsTrue(_rtb.SelectionFont.Underline);
            _ertb.Underline(false);
            Assert.IsFalse(_rtb.SelectionFont.Underline);
        }
        [TestMethod()]
        public void UnderlineTest_SetBoldAndUnderline()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.Font = new Font(_rtb.Font, FontStyle.Bold);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsTrue(_rtb.SelectionFont.Bold);
            _ertb.Underline(true);
            Assert.IsTrue(_rtb.SelectionFont.Underline);
            Assert.IsTrue(_rtb.SelectionFont.Bold);
        }
        [TestMethod()]
        public void UnderlineTest_SetItalicAndUnderline()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.Font = new Font(_rtb.Font, FontStyle.Italic);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsTrue(_rtb.SelectionFont.Italic);
            _ertb.Underline(true);
            Assert.IsTrue(_rtb.SelectionFont.Underline);
            Assert.IsTrue(_rtb.SelectionFont.Italic);
        }
        [TestMethod()]
        public void StyleTest_SetAllStyles()
        {
            _rtb = new RichTextBox();
            _ertb = new ExtendedRichTextBox(_rtb);
            _rtb.Font = new Font(_rtb.Font, FontStyle.Italic);
            _rtb.AppendText("testing1");
            _rtb.SelectAll();
            Assert.IsTrue(_rtb.SelectionFont.Italic);
            _ertb.Underline(true);
            _ertb.Bold(true);
            Assert.IsTrue(_rtb.SelectionFont.Underline);
            Assert.IsTrue(_rtb.SelectionFont.Italic);
            Assert.IsTrue(_rtb.SelectionFont.Bold);
        }
    }
}

