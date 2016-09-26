using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        string loadedfile = "";

        public FRMMain()
        {
            InitializeComponent();
            player = new AudioPlayer();
            KeyPreview = true;
        }

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

        private void FRMMain_Load(object sender, EventArgs e)
        {
            initiateExtensions();
            timer1.Interval = 500;
        }

        private void initiateExtensions()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dlls = Directory.GetFiles(path, "*.dll");
            foreach (var dll in dlls)
            {
                Assembly assm = Assembly.LoadFile(dll);
                foreach (var type in assm.GetTypes())
                {
                    if ((typeof(IExtension).IsAssignableFrom(type)) && !type.IsInterface)
                    {
                        var extensionInstance = (IExtension)Activator.CreateInstance(type);
                        extensionInstance.Initialize(this);
                        string title = extensionInstance.GetTitle();
                        ToolStripItem tsi = new ToolStripMenuItem(title);
                        tsi.Click += (o, e) => { extensionInstance.Execute(); };
                        toolsToolStripMenuItem.DropDownItems.Add(tsi);
                    }
                }
            }
        }
        void tsi_Click(object sender, EventArgs e)
        {
            
        }
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

        private void FRMMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void LoadFileBtn_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            if(trackBarSpeed.Value == 0){ player.Speed(0.5); }
            else if (trackBarSpeed.Value == 1) { player.Speed(0.75); }
            else if (trackBarSpeed.Value == 2) { player.Speed(1); }
            else if (trackBarSpeed.Value == 3) { player.Speed(1.5); }
            else { player.Speed(2); }
        }

        private void timeStampBtn_Click(object sender, EventArgs e)
        {
            TimeStamp();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar.Maximum != player.GetLength())
            {
                GetLength();
            }
            else { progressBar.Value = player.CurrentPosition(); }
        }
        private void GetLength()
        {
            progressBar.Maximum = player.GetLength();
            var ts = TimeSpan.FromSeconds(progressBar.Maximum);
            length_Label.Text = "Length: " + ts.ToString(@"hh\:mm\:ss");
        }

        private void progressBar_MouseHover(object sender, EventArgs e)
        {
            var ts = TimeSpan.FromSeconds(progressBar.Value);
            progressToolTip.SetToolTip(progressBar, ts.ToString(@"hh\:mm\:ss"));
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

        private void PlayPauseCheckboxBtn_Click(object sender, EventArgs e)
        {
             PlayPause();
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

        private void RepeatCheckBoxBtn_Click(object sender, EventArgs e)
        {
             Repeat(); 
        }
        private void Repeat()
        {
            if (fileloaded)
            {
                if (textBox1.Text != "")
                {
                    int sec = Convert.ToInt32(textBox1.Text);
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
            playing = false;
            progressBar.Value = 0;
            Reset();
        }
        private void TimeStamp()
        {
            RTBText.AppendText(player.Timestamp());
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                LoadFile();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F2)
            {
                PlayPause();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F3)
            {
                Stop();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F4)
            {
                Repeat();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F5)
            {
                TimeStamp();
                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void LoadFile()
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
    }
}
