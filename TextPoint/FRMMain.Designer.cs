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
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.LoadFileBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.RepeatTextBox = new System.Windows.Forms.TextBox();
            this.timeStampBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PlayPauseCheckboxBtn = new System.Windows.Forms.CheckBox();
            this.RepeatCheckBoxBtn = new System.Windows.Forms.CheckBox();
            this.BoldCheckboxBtn = new System.Windows.Forms.CheckBox();
            this.ItalicCheckboxBtn = new System.Windows.Forms.CheckBox();
            this.UnderlineCheckboxBtn = new System.Windows.Forms.CheckBox();
            this.FontcomboBox = new System.Windows.Forms.ComboBox();
            this.FontSizeCombobox = new System.Windows.Forms.ComboBox();
            this.ColorChangerBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.length_Label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.CurrentTimeLabel = new System.Windows.Forms.Label();
            this.tagComboBox = new System.Windows.Forms.ComboBox();
            this.findTagBtn = new System.Windows.Forms.Button();
            this.spellcheckBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RTBText
            // 
            this.RTBText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTBText.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTBText.HideSelection = false;
            this.RTBText.Location = new System.Drawing.Point(0, 56);
            this.RTBText.Name = "RTBText";
            this.RTBText.Size = new System.Drawing.Size(718, 329);
            this.RTBText.TabIndex = 0;
            this.RTBText.Text = "";
            this.RTBText.SelectionChanged += new System.EventHandler(this.RTBText_SelectionChanged);
            this.RTBText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTBText_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
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
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSpeed.LargeChange = 1;
            this.trackBarSpeed.Location = new System.Drawing.Point(3, 14);
            this.trackBarSpeed.Maximum = 4;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(104, 45);
            this.trackBarSpeed.TabIndex = 3;
            this.trackBarSpeed.Value = 2;
            this.trackBarSpeed.ValueChanged += new System.EventHandler(this.trackBarSpeed_ValueChanged);
            // 
            // LoadFileBtn
            // 
            this.LoadFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadFileBtn.Location = new System.Drawing.Point(6, 437);
            this.LoadFileBtn.Name = "LoadFileBtn";
            this.LoadFileBtn.Size = new System.Drawing.Size(75, 45);
            this.LoadFileBtn.TabIndex = 4;
            this.LoadFileBtn.Text = "Load";
            this.ToolTip.SetToolTip(this.LoadFileBtn, "F1");
            this.LoadFileBtn.UseVisualStyleBackColor = true;
            this.LoadFileBtn.Click += new System.EventHandler(this.LoadFileBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StopBtn.Location = new System.Drawing.Point(168, 437);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(75, 45);
            this.StopBtn.TabIndex = 5;
            this.StopBtn.Text = "Stop";
            this.ToolTip.SetToolTip(this.StopBtn, "F3");
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // RepeatTextBox
            // 
            this.RepeatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RepeatTextBox.Location = new System.Drawing.Point(250, 462);
            this.RepeatTextBox.Name = "RepeatTextBox";
            this.RepeatTextBox.Size = new System.Drawing.Size(74, 20);
            this.RepeatTextBox.TabIndex = 7;
            this.RepeatTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.RepeatTextBox, "Type in the number of seconds you want to repeat");
            this.RepeatTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RepeatTextBox_KeyPress);
            // 
            // timeStampBtn
            // 
            this.timeStampBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeStampBtn.Location = new System.Drawing.Point(330, 437);
            this.timeStampBtn.Name = "timeStampBtn";
            this.timeStampBtn.Size = new System.Drawing.Size(75, 45);
            this.timeStampBtn.TabIndex = 8;
            this.timeStampBtn.Text = "Timestamp";
            this.ToolTip.SetToolTip(this.timeStampBtn, "F5");
            this.timeStampBtn.UseVisualStyleBackColor = true;
            this.timeStampBtn.Click += new System.EventHandler(this.timeStampBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(0, 391);
            this.progressBar.Maximum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(621, 45);
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
            this.label1.Location = new System.Drawing.Point(7, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "0.5";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "1";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "2";
            // 
            // PlayPauseCheckboxBtn
            // 
            this.PlayPauseCheckboxBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayPauseCheckboxBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.PlayPauseCheckboxBtn.Location = new System.Drawing.Point(87, 437);
            this.PlayPauseCheckboxBtn.Name = "PlayPauseCheckboxBtn";
            this.PlayPauseCheckboxBtn.Size = new System.Drawing.Size(75, 45);
            this.PlayPauseCheckboxBtn.TabIndex = 14;
            this.PlayPauseCheckboxBtn.Text = "Play";
            this.PlayPauseCheckboxBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.PlayPauseCheckboxBtn, "F2");
            this.PlayPauseCheckboxBtn.UseVisualStyleBackColor = true;
            this.PlayPauseCheckboxBtn.Click += new System.EventHandler(this.PlayPauseCheckboxBtn_Click);
            // 
            // RepeatCheckBoxBtn
            // 
            this.RepeatCheckBoxBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RepeatCheckBoxBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.RepeatCheckBoxBtn.Location = new System.Drawing.Point(249, 437);
            this.RepeatCheckBoxBtn.Name = "RepeatCheckBoxBtn";
            this.RepeatCheckBoxBtn.Size = new System.Drawing.Size(75, 23);
            this.RepeatCheckBoxBtn.TabIndex = 15;
            this.RepeatCheckBoxBtn.Text = "Repeat";
            this.RepeatCheckBoxBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.RepeatCheckBoxBtn, "F4");
            this.RepeatCheckBoxBtn.UseVisualStyleBackColor = true;
            this.RepeatCheckBoxBtn.Click += new System.EventHandler(this.RepeatCheckBoxBtn_Click);
            // 
            // BoldCheckboxBtn
            // 
            this.BoldCheckboxBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.BoldCheckboxBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoldCheckboxBtn.Location = new System.Drawing.Point(12, 27);
            this.BoldCheckboxBtn.Name = "BoldCheckboxBtn";
            this.BoldCheckboxBtn.Size = new System.Drawing.Size(25, 21);
            this.BoldCheckboxBtn.TabIndex = 17;
            this.BoldCheckboxBtn.Text = "B";
            this.BoldCheckboxBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.BoldCheckboxBtn, "Bold");
            this.BoldCheckboxBtn.UseVisualStyleBackColor = true;
            this.BoldCheckboxBtn.Click += new System.EventHandler(this.BoldCheckboxBtn_Click);
            // 
            // ItalicCheckboxBtn
            // 
            this.ItalicCheckboxBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.ItalicCheckboxBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItalicCheckboxBtn.Location = new System.Drawing.Point(43, 27);
            this.ItalicCheckboxBtn.Name = "ItalicCheckboxBtn";
            this.ItalicCheckboxBtn.Size = new System.Drawing.Size(25, 21);
            this.ItalicCheckboxBtn.TabIndex = 18;
            this.ItalicCheckboxBtn.Text = "I";
            this.ItalicCheckboxBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.ItalicCheckboxBtn, "Italic");
            this.ItalicCheckboxBtn.UseVisualStyleBackColor = true;
            this.ItalicCheckboxBtn.Click += new System.EventHandler(this.ItalicCheckboxBtn_Click);
            // 
            // UnderlineCheckboxBtn
            // 
            this.UnderlineCheckboxBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.UnderlineCheckboxBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnderlineCheckboxBtn.Location = new System.Drawing.Point(74, 27);
            this.UnderlineCheckboxBtn.Name = "UnderlineCheckboxBtn";
            this.UnderlineCheckboxBtn.Size = new System.Drawing.Size(25, 21);
            this.UnderlineCheckboxBtn.TabIndex = 19;
            this.UnderlineCheckboxBtn.Text = "U";
            this.UnderlineCheckboxBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.UnderlineCheckboxBtn, "Underline");
            this.UnderlineCheckboxBtn.UseVisualStyleBackColor = true;
            this.UnderlineCheckboxBtn.Click += new System.EventHandler(this.UnderlineCheckboxBtn_Click);
            // 
            // FontcomboBox
            // 
            this.FontcomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.FontcomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.FontcomboBox.FormattingEnabled = true;
            this.FontcomboBox.Items.AddRange(new object[] {
            "Arial",
            "Calibri",
            "Times New Roman"});
            this.FontcomboBox.Location = new System.Drawing.Point(106, 27);
            this.FontcomboBox.Name = "FontcomboBox";
            this.FontcomboBox.Size = new System.Drawing.Size(121, 21);
            this.FontcomboBox.TabIndex = 20;
            this.ToolTip.SetToolTip(this.FontcomboBox, "Change Font");
            this.FontcomboBox.SelectionChangeCommitted += new System.EventHandler(this.FontcomboBox_SelectionChangeCommitted);
            this.FontcomboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FontcomboBox_KeyDown);
            // 
            // FontSizeCombobox
            // 
            this.FontSizeCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.FontSizeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FontSizeCombobox.FormattingEnabled = true;
            this.FontSizeCombobox.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.FontSizeCombobox.Location = new System.Drawing.Point(234, 27);
            this.FontSizeCombobox.Name = "FontSizeCombobox";
            this.FontSizeCombobox.Size = new System.Drawing.Size(38, 21);
            this.FontSizeCombobox.TabIndex = 21;
            this.ToolTip.SetToolTip(this.FontSizeCombobox, "Change Font Size");
            this.FontSizeCombobox.SelectionChangeCommitted += new System.EventHandler(this.FontSizeCombobox_SelectionChangeCommitted);
            // 
            // ColorChangerBtn
            // 
            this.ColorChangerBtn.Location = new System.Drawing.Point(279, 27);
            this.ColorChangerBtn.Name = "ColorChangerBtn";
            this.ColorChangerBtn.Size = new System.Drawing.Size(75, 21);
            this.ColorChangerBtn.TabIndex = 22;
            this.ColorChangerBtn.Text = "Color";
            this.ToolTip.SetToolTip(this.ColorChangerBtn, "Change Font color");
            this.ColorChangerBtn.UseVisualStyleBackColor = true;
            this.ColorChangerBtn.Click += new System.EventHandler(this.ColorChangerBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // length_Label
            // 
            this.length_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.length_Label.AutoEllipsis = true;
            this.length_Label.AutoSize = true;
            this.length_Label.Location = new System.Drawing.Point(630, 395);
            this.length_Label.Name = "length_Label";
            this.length_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.length_Label.Size = new System.Drawing.Size(88, 13);
            this.length_Label.TabIndex = 13;
            this.length_Label.Text = "Length: 00:00:00";
            this.length_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.trackBarSpeed);
            this.groupBox1.Location = new System.Drawing.Point(411, 421);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 61);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Speed";
            // 
            // CurrentTimeLabel
            // 
            this.CurrentTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentTimeLabel.AutoSize = true;
            this.CurrentTimeLabel.Location = new System.Drawing.Point(343, 421);
            this.CurrentTimeLabel.Name = "CurrentTimeLabel";
            this.CurrentTimeLabel.Size = new System.Drawing.Size(49, 13);
            this.CurrentTimeLabel.TabIndex = 23;
            this.CurrentTimeLabel.Text = "00:00:00";
            // 
            // tagComboBox
            // 
            this.tagComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tagComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tagComboBox.FormattingEnabled = true;
            this.tagComboBox.Location = new System.Drawing.Point(544, 27);
            this.tagComboBox.Name = "tagComboBox";
            this.tagComboBox.Size = new System.Drawing.Size(121, 21);
            this.tagComboBox.TabIndex = 24;
            this.ToolTip.SetToolTip(this.tagComboBox, "Search by tags or by word");
            this.tagComboBox.DropDown += new System.EventHandler(this.tagComboBox_DropDown);
            this.tagComboBox.Enter += new System.EventHandler(this.tagComboBox_Enter);
            this.tagComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tagComboBox_KeyDown);
            // 
            // findTagBtn
            // 
            this.findTagBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findTagBtn.Location = new System.Drawing.Point(671, 27);
            this.findTagBtn.Name = "findTagBtn";
            this.findTagBtn.Size = new System.Drawing.Size(37, 21);
            this.findTagBtn.TabIndex = 25;
            this.findTagBtn.Text = "Find";
            this.ToolTip.SetToolTip(this.findTagBtn, "Find first or next occurens of the word or tag");
            this.findTagBtn.UseVisualStyleBackColor = true;
            this.findTagBtn.Click += new System.EventHandler(this.findTagBtn_Click);
            // 
            // spellcheckBtn
            // 
            this.spellcheckBtn.Location = new System.Drawing.Point(360, 27);
            this.spellcheckBtn.Name = "spellcheckBtn";
            this.spellcheckBtn.Size = new System.Drawing.Size(80, 21);
            this.spellcheckBtn.TabIndex = 26;
            this.spellcheckBtn.Text = "Spell check";
            this.ToolTip.SetToolTip(this.spellcheckBtn, "Spell checks the text");
            this.spellcheckBtn.UseVisualStyleBackColor = true;
            this.spellcheckBtn.Click += new System.EventHandler(this.spellcheckBtn_Click);
            // 
            // FRMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 486);
            this.Controls.Add(this.spellcheckBtn);
            this.Controls.Add(this.findTagBtn);
            this.Controls.Add(this.tagComboBox);
            this.Controls.Add(this.CurrentTimeLabel);
            this.Controls.Add(this.ColorChangerBtn);
            this.Controls.Add(this.FontSizeCombobox);
            this.Controls.Add(this.FontcomboBox);
            this.Controls.Add(this.UnderlineCheckboxBtn);
            this.Controls.Add(this.ItalicCheckboxBtn);
            this.Controls.Add(this.BoldCheckboxBtn);
            this.Controls.Add(this.RepeatCheckBoxBtn);
            this.Controls.Add(this.PlayPauseCheckboxBtn);
            this.Controls.Add(this.timeStampBtn);
            this.Controls.Add(this.RepeatTextBox);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.LoadFileBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.length_Label);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.RTBText);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FRMMain";
            this.Text = "TextPoint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMMain_FormClosing);
            this.Load += new System.EventHandler(this.FRMMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Button LoadFileBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.TextBox RepeatTextBox;
        private System.Windows.Forms.Button timeStampBtn;
        private System.Windows.Forms.TrackBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label length_Label;
        private System.Windows.Forms.CheckBox PlayPauseCheckboxBtn;
        private System.Windows.Forms.CheckBox RepeatCheckBoxBtn;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox BoldCheckboxBtn;
        private System.Windows.Forms.CheckBox ItalicCheckboxBtn;
        private System.Windows.Forms.CheckBox UnderlineCheckboxBtn;
        private System.Windows.Forms.ComboBox FontcomboBox;
        private System.Windows.Forms.ComboBox FontSizeCombobox;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ColorChangerBtn;
        private System.Windows.Forms.Label CurrentTimeLabel;
        private System.Windows.Forms.ComboBox tagComboBox;
        private System.Windows.Forms.Button findTagBtn;
        private System.Windows.Forms.Button spellcheckBtn;
    }
}

