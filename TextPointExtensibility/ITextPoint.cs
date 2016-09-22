using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TextPoint
{
    public interface ITextPoint
    {
        void SetBackgroundColor(Color col);
        void SetForegroundColor(Color col);
        void SetFont(Font font);
        String GetText();
        void SetText(String text);
    }

}
