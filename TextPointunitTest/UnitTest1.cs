using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextPoint;
using System.Drawing;
using System.Collections.Generic;

namespace TextPointunitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FirstLetterCapitalTest()
        {
            FirstLetterCapital flc = new FirstLetterCapital();
            string result = flc.Execute("hej jAg HETER aLAn");
            Assert.AreEqual("Hej Jag Heter Alan", result);
        }
        [TestMethod]
        public void CountWordTest()
        {
            WordCounter wordCounter = new WordCounter();
            int result = wordCounter.Count("");
            Assert.AreEqual(0, result);

            result = wordCounter.Count("Hej jag heter Alan");
            Assert.AreEqual(4, result);

            result = wordCounter.Count("Hej jag heter Alan och detta är många ord");
            Assert.AreEqual(9, result);
        }
    }

}
