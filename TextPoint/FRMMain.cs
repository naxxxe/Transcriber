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

        public FRMMain()
        {
            InitializeComponent();
            player = new AudioPlayer();
            //player.Load(@"X:\[musik]\Blink_182_-_Neighborhoods-2011-MOD\01_blink_182_-_ghost_on_the_dance_floor.mp3");
            //player.PlayPause();
            //string test = player.Filename();
            //string timestamp = player.Timestamp();
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
            timer1.Interval = 1000;
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

        private void playPauseBtn_Click(object sender, EventArgs e)
        {
            playing = player.PlayPause();
            if (playing)
            {
                timer1.Start();
            }
            else { timer1.Stop(); }
            progressBar.Maximum = (int)player.GetLength();
        }

        private void LoadFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Sound Files (*.mp3, *.wav)|*.mp3;*.wav";
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                player.Load(ofd.FileName);
                RTBText.AppendText(player.Filename() + "\n");
                playing = false;
            }
            //progressBar.Maximum = (int)player.GetLength();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void RepeatBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int sec = Convert.ToInt32(textBox1.Text);
                player.Repeat(sec);
            }
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
            RTBText.AppendText(player.Timestamp());
        }

        private void progressBar_MouseUp(object sender, MouseEventArgs e)
        {
            player.PlayFrom(progressBar.Value);
        }

        private void progressBar_Scroll(object sender, EventArgs e)
        {
            var ts = TimeSpan.FromSeconds(progressBar.Value);
            progressToolTip.SetToolTip(progressBar, ts.ToString(@"hh\:mm\:ss"));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar.Value = player.CurrentPosition();
        }
    }
}
