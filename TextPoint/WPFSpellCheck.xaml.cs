using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextPoint
{
    /// <summary>
    /// Interaction logic for WPFSpellCheck.xaml
    /// </summary>
    public partial class WPFSpellCheck : UserControl
    {
        public WPFSpellCheck()
        {
            //this.rtf = rtf;
            InitializeComponent();
            var lang = richTextBox.Language;
            richTextBox.Language = System.Windows.Markup.XmlLanguage.GetLanguage("en-US");
            //LoadRTF();
            var lang2 = richTextBox.Language;
        }
        public void LoadRTF(string rtf)
        {
            TextRange range = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            // convert string to stream
            byte[] byteArray = Encoding.UTF8.GetBytes(rtf);
            //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
            MemoryStream stream = new MemoryStream(byteArray);
            range.Load(stream, System.Windows.DataFormats.Rtf);
            stream.Close();

        }
        public TextPointer GetStart()
        {
            return richTextBox.Document.ContentStart;
        }

        public TextPointer GetEnd()
        {
            return richTextBox.Document.ContentEnd;
        }
    }
}
