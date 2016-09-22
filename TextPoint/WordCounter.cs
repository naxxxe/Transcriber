using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPoint
{
    public class WordCounter
    {
        public int Count(string text)
        {
            if(text == "" || text == null) { return 0; }
            return text.Split().Count();
        }
    }
}
