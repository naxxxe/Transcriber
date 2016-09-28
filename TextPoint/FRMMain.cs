using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;


namespace TextPoint
{
    public partial class FRMMain : Form, ITextPoint
    {
        IPlayer player;
        bool playing = false;
        bool fileloaded = false;
        bool fontsloaded = false;
        string loadedfile = "";
        FontConverter converter = new FontConverter();

        #region Form functions

        public FRMMain()
        {
            InitializeComponent();
            player = new AudioPlayer();
            KeyPreview = true;
            FontcomboBox.DataSource = GetAllFonts();
            
        }
        private void FRMMain_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            FontcomboBox.Text = RTBText.SelectionFont.Name;
        }
        private void FRMMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        /// <summary>
        /// Keyboard shortcuts for the audioplayer
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1) //F1 Loads a soundfile
            {
                LoadSoundFile();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F2) //F2 Plays or pauses a soundfile
            {
                PlayPause();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F3) //F3 Stops the soundfile
            {
                Stop();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F4) //F4 Toggles repeat on/off
            {
                Repeat();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F5) //F5 Inserts a Timestamp in the Rich Textbox
            {
                TimeStamp();
                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Toolstrip functions

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt";
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RTBText.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt";
            sfd.CheckPathExists = true;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, RTBText.Text);
            }
        }
        
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTBText.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTBText.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTBText.Paste();
        }
        #endregion

        #region ITextPoint functions
        // Plugin support below from here (ITextPoint)
        
        public void SetBackgroundColor(Color col)
        {
            RTBText.BackColor = col;
        }

        public void SetForegroundColor(Color col)
        {
            RTBText.ForeColor = col;
        }

        public void SetFont(Font font)
        {
            RTBText.Font = font;
        }

        public string GetText()
        {
            return RTBText.Text;
        }

        public void SetText(string text)
        {
            RTBText.Text = text;
        }
        #endregion

        #region Buttons
        private void LoadFileBtn_Click(object sender, EventArgs e)
        {
            LoadSoundFile();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private void timeStampBtn_Click(object sender, EventArgs e)
        {
            TimeStamp();
        }
        private void PlayPauseCheckboxBtn_Click(object sender, EventArgs e)
        {
            PlayPause();
        }
        private void RepeatCheckBoxBtn_Click(object sender, EventArgs e)
        {
            Repeat();
        }

        #endregion

        #region TextBoxes

        private void RepeatTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion

        #region Trackbars

        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            if(trackBarSpeed.Value == 0){ player.Speed(0.5); }
            else if (trackBarSpeed.Value == 1) { player.Speed(0.75); }
            else if (trackBarSpeed.Value == 2) { player.Speed(1); }
            else if (trackBarSpeed.Value == 3) { player.Speed(1.5); }
            else { player.Speed(2); }
        }

        private void progressBar_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }

        private void progressBar_MouseUp(object sender, MouseEventArgs e)
        {
            player.PlayFrom(progressBar.Value);
            timer1.Start();
        }

        private void progressBar_Scroll(object sender, EventArgs e)
        {
            var ts = TimeSpan.FromSeconds(progressBar.Value);
            progressToolTip.SetToolTip(progressBar, ts.ToString(@"hh\:mm\:ss"));
        }
        private void progressBar_MouseHover(object sender, EventArgs e)
        {
            var ts = TimeSpan.FromSeconds(progressBar.Value);
            progressToolTip.SetToolTip(progressBar, ts.ToString(@"hh\:mm\:ss"));
        }
        #endregion

        #region Timers

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar.Maximum != player.GetLength())
            {
                GetLength();
            }
            else { progressBar.Value = player.CurrentPosition(); }
        }

        #endregion

        #region AudioPlayer function calls 
        private void GetLength()
        {
            progressBar.Maximum = player.GetLength();
            var ts = TimeSpan.FromSeconds(progressBar.Maximum);
            length_Label.Text = "Length: " + ts.ToString(@"hh\:mm\:ss");
        }

        
        private void Reset()
        {
            playing = false;
            timer1.Stop();
            progressBar.Value = 0;
            PlayPauseCheckboxBtn.Text = "Play";
            PlayPauseCheckboxBtn.Checked = false;
            RepeatCheckBoxBtn.Checked = false;
        }

        
        private void PlayPause()
        {
            if (fileloaded)
            {
                playing = player.PlayPause();
                if (playing)
                {
                    PlayPauseCheckboxBtn.Checked = true;
                    PlayPauseCheckboxBtn.Text = "Playing";
                    timer1.Start();
                }
                else { PlayPauseCheckboxBtn.Checked = false; PlayPauseCheckboxBtn.Text = "Paused"; timer1.Stop(); }
            }
            else { PlayPauseCheckboxBtn.Checked = false; }
        }

        
        private void Repeat()
        {
            if (fileloaded)
            {
                if (RepeatTextBox.Text != "")
                {
                    int sec = Convert.ToInt32(RepeatTextBox.Text);
                    if (player.Repeat(sec))
                    {
                        RepeatCheckBoxBtn.Checked = true;
                    }
                    else
                    {
                        RepeatCheckBoxBtn.Checked = false;
                    }
                }
            }
            else { RepeatCheckBoxBtn.Checked = false; }
        }
        private void Stop()
        {
            player.Stop();
            Reset();
        }
        private void TimeStamp()
        {
            RTBText.AppendText(player.Timestamp());
        }

        private void LoadSoundFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Sound Files (*.mp3, *.wav)|*.mp3;*.wav";
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (loadedfile != ofd.FileName)
                {
                    loadedfile = ofd.FileName;
                    player.Load(ofd.FileName);
                    RTBText.AppendText(player.Filename() + "\n");
                    fileloaded = true;
                    Reset();
                }
            }
        }
        #endregion

        #region RichTextBox functions

        private void ColorChangerBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set selected text color to the selected color.
                RTBText.SelectionColor = colorDialog1.Color;
            }
        }

        private IList<string> GetAllFonts()
        {
            return FontFamily.Families.Select(f => f.Name).ToList();
        }
        #endregion

        private void FontcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fontsloaded)
            {
                try
                {
                    Font font = new Font(FontcomboBox.SelectedValue.ToString(), RTBText.SelectionFont.Size);
                    if (font != null) { RTBText.SelectionFont = font; }
                }
                catch
                {
                    Font font = new Font(FontcomboBox.SelectedValue.ToString(), int.Parse(FontSizeCombobox.Text));
                    if (font != null) { RTBText.SelectionFont = font; }
                }
            }
            else { fontsloaded = true; }
            
        }

        private void RTBText_SelectionChanged(object sender, EventArgs e)
        {
            ChangeComboboxes();
        }
        private void ChangeComboboxes()
        {
            try
            {
                FontcomboBox.Text = RTBText.SelectionFont.Name;
                if (RTBText.SelectionFont.Size == 13) { FontSizeCombobox.Text = ""; }
                else
                {
                    FontSizeCombobox.Text = RTBText.SelectionFont.Size.ToString();
                }
            }
            catch { FontcomboBox.Text = ""; }
        }

        private void FontSizeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int size = int.Parse(FontSizeCombobox.Text);
            RTBText.SelectionFont = new Font(RTBText.SelectionFont.FontFamily, size);
        }
    }
}
