using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextPoint
{
    public static class RichTextBoxExtensions
    {
        public static void AppendProtectedWithColor(this RichTextBox rtb, string text, Color color)
        {
            if (rtb.GetFirstCharIndexOfCurrentLine() != rtb.TextLength)
            {
                rtb.AppendText("\n");
            }
            rtb.SelectionBackColor = color;
            rtb.AppendText(text);
            rtb.Select(rtb.GetFirstCharIndexOfCurrentLine(), text.Length);
            rtb.SelectionProtected = true;
            rtb.AppendText("\n");
            rtb.SelectionProtected = false;
            rtb.SelectionBackColor = rtb.BackColor;
        }
    }
}
