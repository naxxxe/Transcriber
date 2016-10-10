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

        [TestMethod()]
        public void AppendWithColorTest()
        {
            rtb = new RichTextBox();
            ExtendedRichTextBox ertb = new ExtendedRichTextBox(rtb);
            Assert.IsTrue(rtb.Text.Length == 0);
            ertb.AppendWithColor("test", Color.Blue);
            rtb.SelectAll();
            Assert.AreEqual(Color.Blue, rtb.SelectionBackColor);
            Assert.IsTrue(rtb.Text.Contains("test"));
        }

        [TestMethod()]
        public void SameSizeSelectionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCurrentSizeTest()
        {
            Assert.Fail();
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

