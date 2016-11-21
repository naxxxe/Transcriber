using System.Drawing;
using System.Windows.Forms;

namespace TextPoint
{
    public class ExtendedRichTextBox
    {
        private int _startpos = 0;
        private string _stringtofind = "";
        private string Size { get; set; }
        private RichTextBox _rtb;
        public ExtendedRichTextBox(RichTextBox rtb) { this._rtb = rtb; }
        
        /// <summary>
        /// Method to append text with a background color
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public void AppendWithColor(string text, Color color)
        {
            if (_rtb.GetFirstCharIndexOfCurrentLine() != _rtb.TextLength)
            {
                _rtb.AppendText("\n");
            }
            _rtb.SelectionBackColor = color;
            _rtb.SelectionColor = Color.Black;
            _rtb.AppendText(text);
            _rtb.Select(_rtb.GetFirstCharIndexOfCurrentLine(), text.Length);
            //rtb.SelectionProtected = true;
            _rtb.AppendText("\n");
            //rtb.SelectionProtected = false;
            _rtb.SelectionBackColor = _rtb.BackColor;
            _rtb.Focus();
        }

        /// <summary>
        /// Metod that checks if the selceted text is the same size even though it may have different fonts
        /// </summary>
        /// <returns>true if same size, false if not</returns>
        public bool SameSizeSelection()
        {
            float previousValue = -10;
            using (RichTextBox tmpRb = new RichTextBox())
            {
                tmpRb.SelectAll();
                tmpRb.SelectedRtf = _rtb.SelectedRtf;
                for (int i = 0; i < tmpRb.TextLength; ++i)
                {
                    tmpRb.Select(i, 1);
                    if (previousValue == -10)
                    {
                        previousValue = tmpRb.SelectionFont.Size;
                    }
                    else
                    {
                        if (previousValue != tmpRb.SelectionFont.Size) { return false; }
                    }
                }
                if (previousValue == -10) { Size = _rtb.SelectionFont.Size.ToString(); return true; }
                else
                {
                    Size = previousValue.ToString();
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
            return Size;
        }

        /// <summary>
        /// Changes the font/size or style of the selected text
        /// </summary>
        /// <param name="what">The attribute to be changed (Font,Size,Bold,Italic,Underline)</param>
        /// <param name="value">The value it should be changed to</param>
        public void ChangeFormat(string what, string value)
        {
            using (RichTextBox tmpRb = new RichTextBox())
            {
                tmpRb.SelectAll();
                tmpRb.SelectedRtf = _rtb.SelectedRtf;
                if (tmpRb.TextLength < 1)
                {
                    _rtb.SelectionFont = ChangeFormatNoSelection(what, value);
                    _rtb.Focus();
                }
                else
                {
                    int start = _rtb.SelectionStart;
                    int length = _rtb.SelectionLength;
                    _rtb.SelectedRtf = ChangeFormatLongText(what, value, tmpRb);
                    _rtb.Select(start, length);
                    _rtb.Focus();
                }
            }
        }
        /// <summary>
        /// Finds the string ""find" in the text if it exists.
        /// If it occurs multiple times the next occasion is selected on the next search.
        /// </summary>
        /// <param name="find">The string to search for in the text</param>
        public void Find_FindNext(string find)
        {
            if (_stringtofind == find)
            {
                _startpos = _startpos + _stringtofind.Length;
                _startpos = _rtb.Find(_stringtofind, _startpos, RichTextBoxFinds.None);
            }
            else
            {
                _stringtofind = find;
                _startpos = _rtb.Find(_stringtofind, RichTextBoxFinds.None);
            }
            if (_rtb.Find(_stringtofind, RichTextBoxFinds.None) == -1) { return; }
            else if (_startpos == -1) { _startpos = _rtb.Find(_stringtofind, RichTextBoxFinds.None); }
            _rtb.Select(_startpos, _stringtofind.Length);
        }

        /// <summary>
        /// Changes the font/size/style for the current selection
        /// </summary>
        /// <param name="what">The attribute to be changed (Font,Size,Bold,Italic,Underline)</param>
        /// <param name="value">The value it should be changed to</param>
        /// <returns>A new font with updated attributes</returns>
        private Font ChangeFormatNoSelection(string what, string value)
        {
            int size = (int)_rtb.SelectionFont.Size;
            string font = _rtb.SelectionFont.Name;
            var style = _rtb.SelectionFont.Style;
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
        /// <param name="tmpRb">A temporary RichTextBox</param>
        /// <returns></returns>
        private string ChangeFormatLongText(string what, string value, RichTextBox tmpRb)
        {
            {
                bool allBold = false;
                bool allItalic = false;
                bool allUnderline = false;
                if (value == "unknown")
                {
                    if (what == "Bold")
                    {
                        allBold = CheckAllBold(tmpRb);
                    }
                    else if (what == "Italic")
                    {
                        allItalic = CheckAllItalic(tmpRb);
                    }
                    else if (what == "Underline")
                    {
                        allUnderline = CheckAllUnderline(tmpRb);
                    }
                }
                tmpRb = ChangeAllText(tmpRb, what, value, allBold, allItalic, allUnderline);
                tmpRb.SelectAll();
                return tmpRb.SelectedRtf;
            }
        }

        /// <summary>
        /// Checks if the selected text is Bold
        /// </summary>
        /// <param name="tmpRb">A temporary RichTextBox</param>
        /// <returns>true if all selected text is bold, false if not</returns>
        private bool CheckAllBold(RichTextBox tmpRb)
        {
            for (int i = 0; i < tmpRb.TextLength; ++i)
            {
                tmpRb.Select(i, 1);
                if (!tmpRb.SelectionFont.Bold) { return false; }
            }
            return true;
        }

        /// <summary>
        /// Checks if the selected text is Italic
        /// </summary>
        /// <param name="tmpRb">A temporary RichTextBox</param>
        /// <returns>true if all selected text is italic, false if not</returns>
        private bool CheckAllItalic(RichTextBox tmpRb)
        {
            for (int i = 0; i < tmpRb.TextLength; ++i)
            {
                tmpRb.Select(i, 1);
                if (!tmpRb.SelectionFont.Italic) { return false; }
            }
            return true;
        }

        /// <summary>
        /// Checks if the selected text is Underline
        /// </summary>
        /// <param name="tmpRb">A temporary RichTextBox</param>
        /// <returns>true if all selected text is undelined, false if not</returns>
        private bool CheckAllUnderline(RichTextBox tmpRb)
        {
            for (int i = 0; i < tmpRb.TextLength; ++i)
            {
                tmpRb.Select(i, 1);
                if (!tmpRb.SelectionFont.Underline) { return false; }
            }
            return true;
        }

        /// <summary>
        /// Changes the size, font and style character by character
        /// </summary>
        /// <param name="tmpRb">A temporary RichTextBox</param>
        /// <param name="what">The attribute which should be changed</param>
        /// <param name="value">The new value of the attribute</param>
        /// <param name="allBold">true or false</param>
        /// <param name="allItalic">true or false</param>
        /// <param name="allUnderline">true or false</param>
        /// <returns></returns>
        private RichTextBox ChangeAllText(RichTextBox tmpRb, string what, string value, bool allBold, bool allItalic, bool allUnderline)
        {
            for (int i = 0; i < tmpRb.TextLength; ++i)
            {
                tmpRb.Select(i, 1);
                int size = (int)tmpRb.SelectionFont.Size;
                string font = tmpRb.SelectionFont.Name;
                var style = tmpRb.SelectionFont.Style;

                if (what == "Size") { size = int.Parse(value); }

                else if (what == "Font"){ font = value; }

                else if (what == "Bold")
                {
                    if (value == "unknown")
                    {
                        if (allBold) { style = style & ~FontStyle.Bold; }
                        else if (!allBold) { style = style | FontStyle.Bold; }
                    }
                    else if (value == "bold") { style = style | FontStyle.Bold; }
                    else { style = style & ~FontStyle.Bold; }
                }
                else if (what == "Italic")
                {
                    if (value == "unknown")
                    {
                        if (allItalic) { style = style & ~FontStyle.Italic; }
                        else if (!allItalic) { style = style | FontStyle.Italic; }
                    }
                    else if (value == "italic") { style = style | FontStyle.Italic; }
                    else { style = style & ~FontStyle.Italic; }
                }
                else if (what == "Underline")
                {
                    if (value == "unknown")
                    {
                        if (allUnderline) { style = style & ~FontStyle.Underline; }
                        else if (!allUnderline) { style = style | FontStyle.Underline; }
                    }
                    else if (value == "underline") { style = style | FontStyle.Underline; }
                    else { style = style & ~FontStyle.Underline; }
                }
                tmpRb.SelectionFont = new Font(font, size, style);
            }
            return tmpRb;
        }

        /// <summary>
        /// Appends the style Bold to the text or removes it deppending on the bool
        /// </summary>
        /// <param name="bold">true if it should be bold, false if it should not be bold</param>
        public void Bold(bool bold)
        {
            if (_rtb.SelectionFont == null) { ChangeFormat("Bold", "unknown"); }
            else if (bold) { ChangeFormat("Bold", "bold"); }
            else { ChangeFormat("Bold", "notbold"); }
            _rtb.Focus();
        }

        /// <summary>
        /// Appends the style Italic to the text or removes it deppending on the bool
        /// </summary>
        /// <param name="italic">true if it should be italic, false if not</param>
        public void Italic(bool italic)
        {
            if (_rtb.SelectionFont == null) { ChangeFormat("Italic", "unknown"); }
            else if (italic) { ChangeFormat("Italic", "italic"); }
            else { ChangeFormat("Italic", "notitalic"); }
            _rtb.Focus();
        }

        /// <summary>
        /// Appends the style Underline to the text or removes it deppending on the bool
        /// </summary>
        /// <param name="underline">true if it should be undelined, false if not</param>
        public void Underline(bool underline)
        {
            if (_rtb.SelectionFont == null) { ChangeFormat("Underline", "unknown"); }
            else if (underline) { ChangeFormat("Underline", "underline"); }
            else { ChangeFormat("Underline", "notunderline"); }
            _rtb.Focus();
        }
    }
}

