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

        public FRMMain()
        {
            InitializeComponent();
            player = new AudioPlayer();
            player.Load(@"X:\[musik]\Blink_182_-_Neighborhoods-2011-MOD\01_blink_182_-_ghost_on_the_dance_floor.mp3");
            player.PlayPause();
            string test = player.Filename();
            string timestamp = player.Timestamp();
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
    }
}
