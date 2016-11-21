using System.Linq;

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
