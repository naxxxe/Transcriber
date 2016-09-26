namespace TextPoint
{
    partial class FRMMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RTBText = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.LoadFileBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timeStampBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.length_Label = new System.Windows.Forms.Label();
            this.PlayPauseCheckboxBtn = new System.Windows.Forms.CheckBox();
            this.RepeatCheckBoxBtn = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).BeginInit();
            this.SuspendLayout();
            // 
            // RTBText
            // 
            this.RTBText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTBText.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTBText.Location = new System.Drawing.Point(0, 126);
            this.RTBText.Name = "RTBText";
            this.RTBText.Size = new System.Drawing.Size(718, 361);
            this.RTBText.TabIndex = 0;
            this.RTBText.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(718, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "File";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSpeed.LargeChange = 1;
            this.trackBarSpeed.Location = new System.Drawing.Point(602, 27);
            this.trackBarSpeed.Maximum = 4;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(104, 45);
            this.trackBarSpeed.TabIndex = 3;
            this.trackBarSpeed.Value = 2;
            this.trackBarSpeed.ValueChanged += new System.EventHandler(this.trackBarSpeed_ValueChanged);
            // 
            // LoadFileBtn
            // 
            this.LoadFileBtn.Location = new System.Drawing.Point(12, 27);
            this.LoadFileBtn.Name = "LoadFileBtn";
            this.LoadFileBtn.Size = new System.Drawing.Size(75, 45);
            this.LoadFileBtn.TabIndex = 4;
            this.LoadFileBtn.Text = "Load";
            this.progressToolTip.SetToolTip(this.LoadFileBtn, "F1");
            this.LoadFileBtn.UseVisualStyleBackColor = true;
            this.LoadFileBtn.Click += new System.EventHandler(this.LoadFileBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(174, 27);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(75, 45);
            this.StopBtn.TabIndex = 5;
            this.StopBtn.Text = "Stop";
            this.progressToolTip.SetToolTip(this.StopBtn, "F3");
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(256, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.progressToolTip.SetToolTip(this.textBox1, "Type in the number of seconds you want to repeat");
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // timeStampBtn
            // 
            this.timeStampBtn.Location = new System.Drawing.Point(336, 27);
            this.timeStampBtn.Name = "timeStampBtn";
            this.timeStampBtn.Size = new System.Drawing.Size(75, 45);
            this.timeStampBtn.TabIndex = 8;
            this.timeStampBtn.Text = "Timestamp";
            this.progressToolTip.SetToolTip(this.timeStampBtn, "F5");
            this.timeStampBtn.UseVisualStyleBackColor = true;
            this.timeStampBtn.Click += new System.EventHandler(this.timeStampBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(0, 75);
            this.progressBar.Maximum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(718, 45);
            this.progressBar.TabIndex = 9;
            this.progressBar.Scroll += new System.EventHandler(this.progressBar_Scroll);
            this.progressBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.progressBar_MouseDown);
            this.progressBar.MouseHover += new System.EventHandler(this.progressBar_MouseHover);
            this.progressBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.progressBar_MouseUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(606, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "0.5";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(649, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "1";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(687, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "2";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // length_Label
            // 
            this.length_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.length_Label.AutoEllipsis = true;
            this.length_Label.AutoSize = true;
            this.length_Label.Location = new System.Drawing.Point(630, 107);
            this.length_Label.Name = "length_Label";
            this.length_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.length_Label.Size = new System.Drawing.Size(88, 13);
            this.length_Label.TabIndex = 13;
            this.length_Label.Text = "Length: 00:00:00";
            this.length_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayPauseCheckboxBtn
            // 
            this.PlayPauseCheckboxBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.PlayPauseCheckboxBtn.Location = new System.Drawing.Point(93, 27);
            this.PlayPauseCheckboxBtn.Name = "PlayPauseCheckboxBtn";
            this.PlayPauseCheckboxBtn.Size = new System.Drawing.Size(75, 45);
            this.PlayPauseCheckboxBtn.TabIndex = 14;
            this.PlayPauseCheckboxBtn.Text = "Play";
            this.PlayPauseCheckboxBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressToolTip.SetToolTip(this.PlayPauseCheckboxBtn, "F2");
            this.PlayPauseCheckboxBtn.UseVisualStyleBackColor = true;
            this.PlayPauseCheckboxBtn.Click += new System.EventHandler(this.PlayPauseCheckboxBtn_Click);
            // 
            // RepeatCheckBoxBtn
            // 
            this.RepeatCheckBoxBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.RepeatCheckBoxBtn.Location = new System.Drawing.Point(255, 27);
            this.RepeatCheckBoxBtn.Name = "RepeatCheckBoxBtn";
            this.RepeatCheckBoxBtn.Size = new System.Drawing.Size(75, 23);
            this.RepeatCheckBoxBtn.TabIndex = 15;
            this.RepeatCheckBoxBtn.Text = "Repeat";
            this.RepeatCheckBoxBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressToolTip.SetToolTip(this.RepeatCheckBoxBtn, "F4");
            this.RepeatCheckBoxBtn.UseVisualStyleBackColor = true;
            this.RepeatCheckBoxBtn.Click += new System.EventHandler(this.RepeatCheckBoxBtn_Click);
            // 
            // FRMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 486);
            this.Controls.Add(this.RepeatCheckBoxBtn);
            this.Controls.Add(this.PlayPauseCheckboxBtn);
            this.Controls.Add(this.length_Label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.timeStampBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.LoadFileBtn);
            this.Controls.Add(this.trackBarSpeed);
            this.Controls.Add(this.RTBText);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FRMMain";
            this.Text = "TextPoint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMMain_FormClosing);
            this.Load += new System.EventHandler(this.FRMMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTBText;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Button LoadFileBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button timeStampBtn;
        private System.Windows.Forms.TrackBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip progressToolTip;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label length_Label;
        private System.Windows.Forms.CheckBox PlayPauseCheckboxBtn;
        private System.Windows.Forms.CheckBox RepeatCheckBoxBtn;
    }
}

