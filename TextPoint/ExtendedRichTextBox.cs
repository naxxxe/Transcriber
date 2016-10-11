using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextPoint
{
    public class ExtendedRichTextBox
    {
        private string size { get; set; }
        private RichTextBox rtb;
        public ExtendedRichTextBox(RichTextBox rtb) { this.rtb = rtb; }
        
        /// <summary>
        /// Method to append text with a background color
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public void AppendWithColor(string text, Color color)
        {
            if (rtb.GetFirstCharIndexOfCurrentLine() != rtb.TextLength)
            {
                rtb.AppendText("\n");
            }
            rtb.SelectionBackColor = color;
            rtb.AppendText(text);
            rtb.Select(rtb.GetFirstCharIndexOfCurrentLine(), text.Length);
            //rtb.SelectionProtected = true;
            rtb.AppendText("\n");
            //rtb.SelectionProtected = false;
            rtb.SelectionBackColor = rtb.BackColor;
            rtb.Focus();
        }

        /// <summary>
        /// Metod that checks if the selceted text is the same size
        /// </summary>
        /// <returns></returns>
        public bool SameSizeSelection()
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

        /// <summary>
        /// Returns the font size of the current selection
        /// </summary>
        /// <returns></returns>
        public string GetCurrentSize()
        {
            return size;
        }

        /// <summary>
        /// Changes the format of the selected text
        /// </summary>
        /// <param name="what"></param>
        /// <param name="value"></param>
        public void ChangeFormat(string what, string value)
        {
            using (RichTextBox tmpRB = new RichTextBox())
            {
                tmpRB.SelectAll();
                tmpRB.SelectedRtf = rtb.SelectedRtf;
                if (tmpRB.TextLength < 1)
                {
                    rtb.SelectionFont = ChangeFormatNoSelection(what, value);
                }
                else
                {
                    int start = rtb.SelectionStart;
                    int length = rtb.SelectionLength;
                    rtb.SelectedRtf = ChangeFormatLongText(what, value, tmpRB);
                    rtb.Select(start, length);
                    rtb.Focus();
                }

            }
        }

        /// <summary>
        /// Changes the font for the current selection
        /// </summary>
        /// <param name="what"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private Font ChangeFormatNoSelection(string what, string value)
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

        /// <summary>
        /// Changes the format of a longer text. Also checks if the Bold, Italic and Underline attributes should be added or not
        /// </summary>
        /// <param name="what"></param>
        /// <param name="value"></param>
        /// <param name="tmpRB"></param>
        /// <returns></returns>
        private string ChangeFormatLongText(string what, string value, RichTextBox tmpRB)
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

        /// <summary>
        /// Checks if the selected text is Bold
        /// </summary>
        /// <param name="tmpRB"></param>
        /// <returns></returns>
        private bool CheckAllBold(RichTextBox tmpRB)
        {
            for (int i = 0; i < tmpRB.TextLength; ++i)
            {
                tmpRB.Select(i, 1);
                if (!tmpRB.SelectionFont.Bold) { return false; }
            }
            return true;
        }

        /// <summary>
        /// Checks if the selected text is Italic
        /// </summary>
        /// <param name="tmpRB"></param>
        /// <returns></returns>
        private bool CheckAllItalic(RichTextBox tmpRB)
        {
            for (int i = 0; i < tmpRB.TextLength; ++i)
            {
                tmpRB.Select(i, 1);
                if (!tmpRB.SelectionFont.Italic) { return false; }
            }
            return true;
        }

        /// <summary>
        /// Checks if the selected text is Underline
        /// </summary>
        /// <param name="tmpRB"></param>
        /// <returns></returns>
        private bool CheckAllUnderline(RichTextBox tmpRB)
        {
            for (int i = 0; i < tmpRB.TextLength; ++i)
            {
                tmpRB.Select(i, 1);
                if (!tmpRB.SelectionFont.Underline) { return false; }
            }
            return true;
        }

        /// <summary>
        /// Changes the size, font and style character by character
        /// </summary>
        /// <param name="tmpRB"></param>
        /// <param name="what"></param>
        /// <param name="value"></param>
        /// <param name="AllBold"></param>
        /// <param name="AllItalic"></param>
        /// <param name="AllUnderline"></param>
        /// <returns></returns>
        private RichTextBox ChangeAllText(RichTextBox tmpRB, string what, string value, bool AllBold, bool AllItalic, bool AllUnderline)
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

        /// <summary>
        /// Appends the style Bold to the text or removes it deppending on the bool
        /// </summary>
        /// <param name="bold"></param>
        public void Bold(bool bold)
        {
            if (rtb.SelectionFont != null && SameSizeSelection())
            {
                var style = rtb.SelectionFont.Style;
                if (!rtb.SelectionFont.Bold) { style = style | FontStyle.Bold; }
                else { style = style & ~FontStyle.Bold; }
                rtb.SelectionFont = new Font(rtb.SelectionFont, style);
            }
            else if (rtb.SelectionFont == null) { ChangeFormat("Bold", "unknown"); }
            else if (bold) { ChangeFormat("Bold", "bold"); }
            else { ChangeFormat("Bold", "notbold"); }
            rtb.Focus();
        }

        /// <summary>
        /// Appends the style Italic to the text or removes it deppending on the bool
        /// </summary>
        /// <param name="italic"></param>
        public void Italic(bool italic)
        {
            if (rtb.SelectionFont != null && SameSizeSelection())
            {
                var style = rtb.SelectionFont.Style;
                if (!rtb.SelectionFont.Italic) { style = style | FontStyle.Italic; }
                else { style = style & ~FontStyle.Italic; }
                rtb.SelectionFont = new Font(rtb.SelectionFont, style);
            }
            else if (rtb.SelectionFont == null) { ChangeFormat("Italic", "unknown"); }
            else if (italic) { ChangeFormat("Italic", "italic"); }
            else { ChangeFormat("Italic", "notitalic"); }
            rtb.Focus();
        }

        /// <summary>
        /// Appends the style Underline to the text or removes it deppending on the bool
        /// </summary>
        /// <param name="underline"></param>
        public void Underline(bool underline)
        {
            if (rtb.SelectionFont != null && SameSizeSelection())
            {
                var style = rtb.SelectionFont.Style;
                if (!rtb.SelectionFont.Underline) { style = style | FontStyle.Underline; }
                else { style = style & ~FontStyle.Underline; }
                rtb.SelectionFont = new Font(rtb.SelectionFont, style);
            }
            else if (rtb.SelectionFont == null) { ChangeFormat("Underline", "unknown"); }
            else if (underline) { ChangeFormat("Underline", "underline"); }
            else { ChangeFormat("Underline", "notunderline"); }
            rtb.Focus();
        }
    }
}

