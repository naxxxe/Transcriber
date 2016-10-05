using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextPoint
{
    public static class FormExtension
    {
        public static void Bold(this Form form, RichTextBox RTBText, bool bold)
        {
            if (RTBText.SelectionFont != null && RTBText.SameSizeSelection())
            {
                var style = RTBText.SelectionFont.Style;
                if (!RTBText.SelectionFont.Bold) { style = style | FontStyle.Bold; }
                else { style = style & ~FontStyle.Bold; }
                RTBText.SelectionFont = new Font(RTBText.SelectionFont, style);
            }
            else if (RTBText.SelectionFont == null) { RTBText.ChangeFormat("Bold", "unknown"); }
            else if (bold) { RTBText.ChangeFormat("Bold", "bold"); }
            else { RTBText.ChangeFormat("Bold", "notbold"); }
            RTBText.Focus();
        }
        public static void Italic(this Form form, RichTextBox RTBText, bool italic)
        {
            if (RTBText.SelectionFont != null && RTBText.SameSizeSelection())
            {
                var style = RTBText.SelectionFont.Style;
                if (!RTBText.SelectionFont.Italic) { style = style | FontStyle.Italic; }
                else { style = style & ~FontStyle.Italic; }
                RTBText.SelectionFont = new Font(RTBText.SelectionFont, style);
            }
            else if (RTBText.SelectionFont == null) { RTBText.ChangeFormat("Italic", "unknown"); }
            else if (italic) { RTBText.ChangeFormat("Italic", "italic"); }
            else { RTBText.ChangeFormat("Italic", "notitalic"); }
            RTBText.Focus();
        }
        public static void Underline(this Form form, RichTextBox RTBText, bool underline)
        {
            if (RTBText.SelectionFont != null && RTBText.SameSizeSelection())
            {
                var style = RTBText.SelectionFont.Style;
                if (!RTBText.SelectionFont.Underline) { style = style | FontStyle.Underline; }
                else { style = style & ~FontStyle.Underline; }
                RTBText.SelectionFont = new Font(RTBText.SelectionFont, style);
            }
            else if (RTBText.SelectionFont == null) { RTBText.ChangeFormat("Underline", "unknown"); }
            else if (underline) { RTBText.ChangeFormat("Underline", "underline"); }
            else { RTBText.ChangeFormat("Underline", "notunderline"); }
            RTBText.Focus();
        }
    }
}
