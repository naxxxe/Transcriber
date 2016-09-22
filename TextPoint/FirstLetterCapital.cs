using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPoint
{
    public class FirstLetterCapital
    {
        public string Execute(string Text)
        {
            var TextToReturn = "";

            var StringArray = Text.ToLower().Split(' ');
            foreach (String s in StringArray)
            {
                TextToReturn += char.ToUpper(s[0]) + s.Substring(1) + " ";
            }
            return TextToReturn.TrimEnd();
        }
    }
    //    public void FirstLetterCapitalTest()
    //    {
    //        FirstLetterCapital flc = new FirstLetterCapital();
    //        string result = flc.Execute("hej jAg HETER aLAn");
    //        Assert.AreEqual("Hej Jag Heter Alan", result);
    //    }

}
