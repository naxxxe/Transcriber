using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;

namespace TextPoint
{
    /// <summary>
    /// Interaction logic for WPFSpellCheck.xaml
    /// </summary>
    public partial class WpfSpellCheck : UserControl
    {
        public WpfSpellCheck()
        {
            //this.rtf = rtf;
            InitializeComponent();
            var lang = RichTextBox.Language;
            RichTextBox.Language = System.Windows.Markup.XmlLanguage.GetLanguage("en-US");
            //LoadRTF();
            var lang2 = RichTextBox.Language;
        }
        public void LoadRtf(string rtf)
        {
            TextRange range = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
            // convert string to stream
            byte[] byteArray = Encoding.UTF8.GetBytes(rtf);
            //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
            MemoryStream stream = new MemoryStream(byteArray);
            range.Load(stream, System.Windows.DataFormats.Rtf);
            stream.Close();

        }
        public TextPointer GetStart()
        {
            return RichTextBox.Document.ContentStart;
        }

        public TextPointer GetEnd()
        {
            return RichTextBox.Document.ContentEnd;
        }
    }
}
