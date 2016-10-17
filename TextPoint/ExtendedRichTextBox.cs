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
        /// Metod that checks if the selceted text is the same size even though it may have different fonts
        /// </summary>
        /// <returns>true if same size, false if not</returns>
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
        /// <returns>a string with the current size of the selection</returns>
        public string GetCurrentSize()
        {
            return size;
        }

        /// <summary>
        /// Changes the font/size or style of the selected text
        /// </summary>
        /// <param name="what">The attribute to be changed (Font,Size,Bold,Italic,Underline)</param>
        /// <param name="value">The value it should be changed to</param>
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
        /// Changes the font/size/style for the current selection
        /// </summary>
        /// <param name="what">The attribute to be changed (Font,Size,Bold,Italic,Underline)</param>
        /// <param name="value">The value it should be changed to</param>
        /// <returns>A new font with updated attributes</returns>
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
        /// Changes the format of a longer text. If value is "unknown" check if the seleted text is bold/italic/underline.
        /// This check is made since the correct attributes can't be fetched if the selection contains multiple fonts.
        /// </summary>
        /// <param name="what">The attribute to be changed (Font,Size,Bold,Italic,Underline)</param>
        /// <param name="value">The value it should be changed to</param>
        /// <param name="tmpRB">A temporary RichTextBox</param>
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
        /// <param name="tmpRB">A temporary RichTextBox</param>
        /// <returns>true if all selected text is bold, false if not</returns>
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
        /// <param name="tmpRB">A temporary RichTextBox</param>
        /// <returns>true if all selected text is italic, false if not</returns>
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
        /// <param name="tmpRB">A temporary RichTextBox</param>
        /// <returns>true if all selected text is undelined, false if not</returns>
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
        /// <param name="tmpRB">A temporary RichTextBox</param>
        /// <param name="what">The attribute which should be changed</param>
        /// <param name="value">The new value of the attribute</param>
        /// <param name="AllBold">true or false</param>
        /// <param name="AllItalic">true or false</param>
        /// <param name="AllUnderline">true or false</param>
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
        /// <param name="bold">true if it should be bold, false if it should not be bold</param>
        public void Bold(bool bold)
        {
            if (rtb.SelectionFont == null) { ChangeFormat("Bold", "unknown"); }
            else if (bold) { ChangeFormat("Bold", "bold"); }
            else { ChangeFormat("Bold", "notbold"); }
            rtb.Focus();
        }

        /// <summary>
        /// Appends the style Italic to the text or removes it deppending on the bool
        /// </summary>
        /// <param name="italic">true if it should be italic, false if not</param>
        public void Italic(bool italic)
        {
            if (rtb.SelectionFont == null) { ChangeFormat("Italic", "unknown"); }
            else if (italic) { ChangeFormat("Italic", "italic"); }
            else { ChangeFormat("Italic", "notitalic"); }
            rtb.Focus();
        }

        /// <summary>
        /// Appends the style Underline to the text or removes it deppending on the bool
        /// </summary>
        /// <param name="underline">true if it should be undelined, false if not</param>
        public void Underline(bool underline)
        {
            if (rtb.SelectionFont == null) { ChangeFormat("Underline", "unknown"); }
            else if (underline) { ChangeFormat("Underline", "underline"); }
            else { ChangeFormat("Underline", "notunderline"); }
            rtb.Focus();
        }
    }
}

