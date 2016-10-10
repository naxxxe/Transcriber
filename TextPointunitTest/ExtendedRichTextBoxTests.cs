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
        public void ChangeFormatTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BoldTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ItalicTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UnderlineTest()
        {
            Assert.Fail();
        }
    }
}

