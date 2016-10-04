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
        public static string size { get; private set; }
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
            rtb.Focus();
        }
        public static bool SameSizeSelection(this RichTextBox rtb)
        {
            float previousValue = -10;
            using (RichTextBox tmpRB = new RichTextBox())
            {
                tmpRB.SelectAll();
                tmpRB.SelectedRtf = rtb.SelectedRtf;
                for (int i = 0; i < tmpRB.TextLength; ++i)
                {
                    tmpRB.Select(i, 1);
                    if (previousValue == -10)
                    {
                        previousValue = tmpRB.SelectionFont.Size;
                    }
                    else
                    {
                        if (previousValue != tmpRB.SelectionFont.Size) { return false; }
                    }
                }
                if (previousValue == -10) { size = rtb.SelectionFont.Size.ToString(); return true; }
                else
                {
                    size = previousValue.ToString();
                    return true;
                }
            }
        }
        public static string GetCurrentSize(this RichTextBox rtb)
        {
            return size;
        }
        public static void ChangeFormat(this RichTextBox rtb, string what, string value)
        {
            using (RichTextBox tmpRB = new RichTextBox())
            {
                tmpRB.SelectAll();
                tmpRB.SelectedRtf = rtb.SelectedRtf;
                if (tmpRB.TextLength < 1)
                {
                    rtb.SelectionFont = rtb.ChangeFormatNoSelection(what, value);
                }
                else
                {
                    rtb.SelectedRtf = ChangeFormatLongText(what, value, tmpRB);
                }

            }
        }

        private static Font ChangeFormatNoSelection(this RichTextBox rtb, string what, string value)
        {
            int size = (int)rtb.SelectionFont.Size;
            string font = rtb.SelectionFont.Name;
            var style = rtb.SelectionFont.Style;
            if (what == "Size")
            {
                size = int.Parse(value);
            }
            else if (what == "Font")
            {
                font = value;
            }
            else if (what == "Bold")
            {
                if (value == "bold") { style = style | FontStyle.Bold; }
                else { style = style & ~FontStyle.Bold; }
            }
            else if (what == "Italic")
            {
                if (value == "italic") { style = style | FontStyle.Italic; }
                else { style = style & ~FontStyle.Italic; }
            }
            else if (what == "Underline")
            {
                if (value == "underline") { style = style | FontStyle.Underline; }
                else { style = style & ~FontStyle.Underline; }
            }

            return new Font(font, size, style);
        }
        private static string ChangeFormatLongText(string what, string value, RichTextBox tmpRB)
        {
            {
                bool AllBold = false;
                bool AllItalic = false;
                bool AllUnderline = false;
                if (value == "unknown")
                {
                    if (what == "Bold")
                    {
                        AllBold = CheckAllBold(tmpRB);
                    }
                    else if (what == "Italic")
                    {
                        AllItalic = CheckAllItalic(tmpRB);
                    }
                    else if (what == "Underline")
                    {
                        AllUnderline = CheckAllUnderline(tmpRB);
                    }
                }
                tmpRB = ChangeAllText(tmpRB, what, value, AllBold, AllItalic, AllUnderline);
                tmpRB.SelectAll();
                return tmpRB.SelectedRtf;
            }
        }
        private static bool CheckAllBold(RichTextBox tmpRB)
        {
            for (int i = 0; i < tmpRB.TextLength; ++i)
            {
                tmpRB.Select(i, 1);
                if (!tmpRB.SelectionFont.Bold) { return false; }
            }
            return true;
        }
        private static bool CheckAllItalic(RichTextBox tmpRB)
        {
            for (int i = 0; i < tmpRB.TextLength; ++i)
            {
                tmpRB.Select(i, 1);
                if (!tmpRB.SelectionFont.Italic) { return false; }
            }
            return true;
        }
        private static bool CheckAllUnderline(RichTextBox tmpRB)
        {
            for (int i = 0; i < tmpRB.TextLength; ++i)
            {
                tmpRB.Select(i, 1);
                if (!tmpRB.SelectionFont.Underline) { return false; }
            }
            return true;
        }

        private static RichTextBox ChangeAllText(RichTextBox tmpRB, string what, string value, bool AllBold, bool AllItalic, bool AllUnderline)
        {
            for (int i = 0; i < tmpRB.TextLength; ++i)
            {
                tmpRB.Select(i, 1);
                int size = (int)tmpRB.SelectionFont.Size;
                string font = tmpRB.SelectionFont.Name;
                var style = tmpRB.SelectionFont.Style;

                if (what == "Size")
                {
                    size = int.Parse(value);
                }

                else if (what == "Font")
                {
                    font = value;
                }

                else if (what == "Bold")
                {
                    if (value == "unknown")
                    {
                        if (AllBold) { style = style & ~FontStyle.Bold; }
                        else if (!AllBold) { style = style | FontStyle.Bold; }
                    }
                    else if (value == "bold") { style = style | FontStyle.Bold; }
                    else { style = style & ~FontStyle.Bold; }
                }


                else if (what == "Italic")
                {
                    if (value == "unknown")
                    {
                        if (AllItalic) { style = style & ~FontStyle.Italic; }
                        else if (!AllItalic) { style = style | FontStyle.Italic; }
                    }
                    else if (value == "italic") { style = style | FontStyle.Italic; }
                    else { style = style & ~FontStyle.Italic; }
                }


                else if (what == "Underline")
                {
                    if (value == "unknown")
                    {
                        if (AllUnderline) { style = style & ~FontStyle.Underline; }
                        else if (!AllUnderline) { style = style | FontStyle.Underline; }
                    }
                    else if (value == "underline") { style = style | FontStyle.Underline; }
                    else { style = style & ~FontStyle.Underline; }
                }
                tmpRB.SelectionFont = new Font(font, size, style);
            }
            return tmpRB;
        }
    }
}
