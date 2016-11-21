using System;
using System.IO;
using System.Windows.Documents;
using System.Windows.Forms;

namespace TextPoint
{
    public partial class SpellCheckForm : Form
    {
        //private string rtf = "";
        public SpellCheckForm(string rtf)
        {
            this.rtf = rtf;
            InitializeComponent();
            wpfSpellCheck1.LoadRtf(rtf);
        }
        public string GetChangedText()
        {
            return rtf;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var wpf = wpfSpellCheck1;
            using (MemoryStream ms = new MemoryStream())
            {
                TextRange range2 = new TextRange(wpf.GetStart(), wpf.GetEnd());
                range2.Save(ms, DataFormats.Rtf);
                ms.Seek(0, SeekOrigin.Begin);
                using (StreamReader sr = new StreamReader(ms))
                {
                    rtf = sr.ReadToEnd();
                }
            }
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
