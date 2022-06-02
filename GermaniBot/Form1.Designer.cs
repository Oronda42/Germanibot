namespace GermaniBot
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.GermanicusChekBox = new System.Windows.Forms.CheckBox();
            this.SullaChekBox = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ElapsedTime = new System.Windows.Forms.Label();
            this.GamePLayed_Label = new System.Windows.Forms.Label();
            this.ElapsedTime_Label = new System.Windows.Forms.Label();
            this.GamePlayed = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KeyboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aZERTYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qWERTYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.showStatsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CaesarCheckBox = new System.Windows.Forms.CheckBox();
            this.ScipioChekbox = new System.Windows.Forms.CheckBox();
            this.FactionComboBox = new System.Windows.Forms.ComboBox();
            this.RomanPanel = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.GreecePanel = new System.Windows.Forms.Panel();
            this.CynaneChekBox = new System.Windows.Forms.CheckBox();
            this.LeonidasChekBox = new System.Windows.Forms.CheckBox();
            this.AlexanderChekBox = new System.Windows.Forms.CheckBox();
            this.MilitiadesChekBox = new System.Windows.Forms.CheckBox();
            this.BarbarianPanel = new System.Windows.Forms.Panel();
            this.ArminiusChekBox = new System.Windows.Forms.CheckBox();
            this.boudicaChekbox = new System.Windows.Forms.CheckBox();
            this.vercingetorixChekBox = new System.Windows.Forms.CheckBox();
            this.AmbiorixChekbox = new System.Windows.Forms.CheckBox();
            this.CarthagePanel = new System.Windows.Forms.Panel();
            this.HannibalChekBox = new System.Windows.Forms.CheckBox();
            this.HasdrubalChekBox = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.TestWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.RomanPanel.SuspendLayout();
            this.GreecePanel.SuspendLayout();
            this.BarbarianPanel.SuspendLayout();
            this.CarthagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Aquamarine;
            this.label1.Location = new System.Drawing.Point(181, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Germanibot";
            // 
            // button2
            // 
            this.button2.AccessibleDescription = "stopButton";
            this.button2.AccessibleName = "stopButton";
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(112, 478);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.Color.White;
            this.richTextBox.CausesValidation = false;
            this.richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.richTextBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.richTextBox.Location = new System.Drawing.Point(269, 183);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox.Size = new System.Drawing.Size(316, 284);
            this.richTextBox.TabIndex = 4;
            this.richTextBox.Text = "";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // GermanicusChekBox
            // 
            this.GermanicusChekBox.AutoSize = true;
            this.GermanicusChekBox.Checked = true;
            this.GermanicusChekBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GermanicusChekBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GermanicusChekBox.Location = new System.Drawing.Point(3, 3);
            this.GermanicusChekBox.Name = "GermanicusChekBox";
            this.GermanicusChekBox.Size = new System.Drawing.Size(114, 24);
            this.GermanicusChekBox.TabIndex = 0;
            this.GermanicusChekBox.Text = "Germanicus";
            this.GermanicusChekBox.UseVisualStyleBackColor = true;
            // 
            // SullaChekBox
            // 
            this.SullaChekBox.AutoSize = true;
            this.SullaChekBox.Checked = true;
            this.SullaChekBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SullaChekBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SullaChekBox.Location = new System.Drawing.Point(3, 33);
            this.SullaChekBox.Name = "SullaChekBox";
            this.SullaChekBox.Size = new System.Drawing.Size(63, 24);
            this.SullaChekBox.TabIndex = 1;
            this.SullaChekBox.Text = "Sulla";
            this.SullaChekBox.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ElapsedTime
            // 
            this.ElapsedTime.AutoSize = true;
            this.ElapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElapsedTime.Location = new System.Drawing.Point(398, 509);
            this.ElapsedTime.Name = "ElapsedTime";
            this.ElapsedTime.Size = new System.Drawing.Size(71, 20);
            this.ElapsedTime.TabIndex = 5;
            this.ElapsedTime.Text = "00:00:00";
            // 
            // GamePLayed_Label
            // 
            this.GamePLayed_Label.AutoSize = true;
            this.GamePLayed_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GamePLayed_Label.Location = new System.Drawing.Point(275, 478);
            this.GamePLayed_Label.Name = "GamePLayed_Label";
            this.GamePLayed_Label.Size = new System.Drawing.Size(112, 20);
            this.GamePLayed_Label.TabIndex = 6;
            this.GamePLayed_Label.Text = "GamePlayed : ";
            // 
            // ElapsedTime_Label
            // 
            this.ElapsedTime_Label.AutoSize = true;
            this.ElapsedTime_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElapsedTime_Label.Location = new System.Drawing.Point(275, 509);
            this.ElapsedTime_Label.Name = "ElapsedTime_Label";
            this.ElapsedTime_Label.Size = new System.Drawing.Size(117, 20);
            this.ElapsedTime_Label.TabIndex = 7;
            this.ElapsedTime_Label.Text = "Elapsed Time : ";
            // 
            // GamePlayed
            // 
            this.GamePlayed.AutoSize = true;
            this.GamePlayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GamePlayed.Location = new System.Drawing.Point(398, 478);
            this.GamePlayed.Name = "GamePlayed";
            this.GamePlayed.Size = new System.Drawing.Size(18, 20);
            this.GamePlayed.TabIndex = 8;
            this.GamePlayed.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filerToolStripMenuItem1,
            this.settingToolStripMenuItem,
            this.StatsToolStripMenuItem2,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(607, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filerToolStripMenuItem1
            // 
            this.filerToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.filerToolStripMenuItem1.Name = "filerToolStripMenuItem1";
            this.filerToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.filerToolStripMenuItem1.Text = "File";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.KeyboardToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingToolStripMenuItem.Text = "Settings";
            // 
            // KeyboardToolStripMenuItem
            // 
            this.KeyboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aZERTYToolStripMenuItem,
            this.qWERTYToolStripMenuItem});
            this.KeyboardToolStripMenuItem.Name = "KeyboardToolStripMenuItem";
            this.KeyboardToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.KeyboardToolStripMenuItem.Text = "Keyboard";
            this.KeyboardToolStripMenuItem.Click += new System.EventHandler(this.showStatsToolStripMenuItem_Click);
            // 
            // aZERTYToolStripMenuItem
            // 
            this.aZERTYToolStripMenuItem.Checked = true;
            this.aZERTYToolStripMenuItem.CheckOnClick = true;
            this.aZERTYToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aZERTYToolStripMenuItem.Name = "aZERTYToolStripMenuItem";
            this.aZERTYToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.aZERTYToolStripMenuItem.Text = "AZERTY";
            this.aZERTYToolStripMenuItem.Click += new System.EventHandler(this.aZERTYToolStripMenuItem_Click);
            // 
            // qWERTYToolStripMenuItem
            // 
            this.qWERTYToolStripMenuItem.CheckOnClick = true;
            this.qWERTYToolStripMenuItem.Name = "qWERTYToolStripMenuItem";
            this.qWERTYToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.qWERTYToolStripMenuItem.Text = "QWERTY";
            this.qWERTYToolStripMenuItem.Click += new System.EventHandler(this.qWERTYToolStripMenuItem_Click);
            // 
            // StatsToolStripMenuItem2
            // 
            this.StatsToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showStatsToolStripMenuItem1});
            this.StatsToolStripMenuItem2.Name = "StatsToolStripMenuItem2";
            this.StatsToolStripMenuItem2.Size = new System.Drawing.Size(44, 20);
            this.StatsToolStripMenuItem2.Text = "Stats";
            // 
            // showStatsToolStripMenuItem1
            // 
            this.showStatsToolStripMenuItem1.Name = "showStatsToolStripMenuItem1";
            this.showStatsToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.showStatsToolStripMenuItem1.Text = "Show Stats";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // CaesarCheckBox
            // 
            this.CaesarCheckBox.AutoSize = true;
            this.CaesarCheckBox.Checked = true;
            this.CaesarCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CaesarCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaesarCheckBox.Location = new System.Drawing.Point(3, 63);
            this.CaesarCheckBox.Name = "CaesarCheckBox";
            this.CaesarCheckBox.Size = new System.Drawing.Size(123, 24);
            this.CaesarCheckBox.TabIndex = 11;
            this.CaesarCheckBox.Text = "Julius Caesar";
            this.CaesarCheckBox.UseVisualStyleBackColor = true;
            // 
            // ScipioChekbox
            // 
            this.ScipioChekbox.AutoSize = true;
            this.ScipioChekbox.Checked = true;
            this.ScipioChekbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ScipioChekbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScipioChekbox.Location = new System.Drawing.Point(3, 93);
            this.ScipioChekbox.Name = "ScipioChekbox";
            this.ScipioChekbox.Size = new System.Drawing.Size(142, 24);
            this.ScipioChekbox.TabIndex = 12;
            this.ScipioChekbox.Text = "Scipio Africanus";
            this.ScipioChekbox.UseVisualStyleBackColor = true;
            // 
            // FactionComboBox
            // 
            this.FactionComboBox.FormattingEnabled = true;
            this.FactionComboBox.Items.AddRange(new object[] {
            "Roman",
            "Greece",
            "Barbarian",
            "Carthage"});
            this.FactionComboBox.Location = new System.Drawing.Point(16, 133);
            this.FactionComboBox.Name = "FactionComboBox";
            this.FactionComboBox.Size = new System.Drawing.Size(183, 21);
            this.FactionComboBox.TabIndex = 13;
            this.FactionComboBox.Text = "Roman";
            this.FactionComboBox.SelectedIndexChanged += new System.EventHandler(this.FactionComboBox_SelectedIndexChanged);
            this.FactionComboBox.DropDownClosed += new System.EventHandler(this.FactionComboBox_DropDownClosed);
            // 
            // RomanPanel
            // 
            this.RomanPanel.Controls.Add(this.GermanicusChekBox);
            this.RomanPanel.Controls.Add(this.SullaChekBox);
            this.RomanPanel.Controls.Add(this.ScipioChekbox);
            this.RomanPanel.Controls.Add(this.CaesarCheckBox);
            this.RomanPanel.Location = new System.Drawing.Point(16, 183);
            this.RomanPanel.Name = "RomanPanel";
            this.RomanPanel.Size = new System.Drawing.Size(183, 122);
            this.RomanPanel.TabIndex = 14;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(12, 321);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(187, 21);
            this.comboBox2.TabIndex = 15;
            // 
            // GreecePanel
            // 
            this.GreecePanel.Controls.Add(this.CynaneChekBox);
            this.GreecePanel.Controls.Add(this.LeonidasChekBox);
            this.GreecePanel.Controls.Add(this.AlexanderChekBox);
            this.GreecePanel.Controls.Add(this.MilitiadesChekBox);
            this.GreecePanel.Location = new System.Drawing.Point(16, 183);
            this.GreecePanel.Name = "GreecePanel";
            this.GreecePanel.Size = new System.Drawing.Size(183, 122);
            this.GreecePanel.TabIndex = 15;
            // 
            // CynaneChekBox
            // 
            this.CynaneChekBox.AutoSize = true;
            this.CynaneChekBox.Checked = true;
            this.CynaneChekBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CynaneChekBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CynaneChekBox.Location = new System.Drawing.Point(3, 3);
            this.CynaneChekBox.Name = "CynaneChekBox";
            this.CynaneChekBox.Size = new System.Drawing.Size(82, 24);
            this.CynaneChekBox.TabIndex = 0;
            this.CynaneChekBox.Text = "Cynane";
            this.CynaneChekBox.UseVisualStyleBackColor = true;
            // 
            // LeonidasChekBox
            // 
            this.LeonidasChekBox.AutoSize = true;
            this.LeonidasChekBox.Checked = true;
            this.LeonidasChekBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LeonidasChekBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeonidasChekBox.Location = new System.Drawing.Point(3, 33);
            this.LeonidasChekBox.Name = "LeonidasChekBox";
            this.LeonidasChekBox.Size = new System.Drawing.Size(93, 24);
            this.LeonidasChekBox.TabIndex = 1;
            this.LeonidasChekBox.Text = "Leonidas";
            this.LeonidasChekBox.UseVisualStyleBackColor = true;
            // 
            // AlexanderChekBox
            // 
            this.AlexanderChekBox.AutoSize = true;
            this.AlexanderChekBox.Checked = true;
            this.AlexanderChekBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AlexanderChekBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlexanderChekBox.Location = new System.Drawing.Point(3, 93);
            this.AlexanderChekBox.Name = "AlexanderChekBox";
            this.AlexanderChekBox.Size = new System.Drawing.Size(99, 24);
            this.AlexanderChekBox.TabIndex = 12;
            this.AlexanderChekBox.Text = "Alexander";
            this.AlexanderChekBox.UseVisualStyleBackColor = true;
            // 
            // MilitiadesChekBox
            // 
            this.MilitiadesChekBox.AutoSize = true;
            this.MilitiadesChekBox.Checked = true;
            this.MilitiadesChekBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MilitiadesChekBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MilitiadesChekBox.Location = new System.Drawing.Point(3, 63);
            this.MilitiadesChekBox.Name = "MilitiadesChekBox";
            this.MilitiadesChekBox.Size = new System.Drawing.Size(93, 24);
            this.MilitiadesChekBox.TabIndex = 11;
            this.MilitiadesChekBox.Text = "Militiades";
            this.MilitiadesChekBox.UseVisualStyleBackColor = true;
            // 
            // BarbarianPanel
            // 
            this.BarbarianPanel.Controls.Add(this.ArminiusChekBox);
            this.BarbarianPanel.Controls.Add(this.boudicaChekbox);
            this.BarbarianPanel.Controls.Add(this.vercingetorixChekBox);
            this.BarbarianPanel.Controls.Add(this.AmbiorixChekbox);
            this.BarbarianPanel.Location = new System.Drawing.Point(16, 183);
            this.BarbarianPanel.Name = "BarbarianPanel";
            this.BarbarianPanel.Size = new System.Drawing.Size(183, 122);
            this.BarbarianPanel.TabIndex = 15;
            // 
            // ArminiusChekBox
            // 
            this.ArminiusChekBox.AutoSize = true;
            this.ArminiusChekBox.Checked = true;
            this.ArminiusChekBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ArminiusChekBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArminiusChekBox.Location = new System.Drawing.Point(3, 3);
            this.ArminiusChekBox.Name = "ArminiusChekBox";
            this.ArminiusChekBox.Size = new System.Drawing.Size(89, 24);
            this.ArminiusChekBox.TabIndex = 0;
            this.ArminiusChekBox.Text = "Arminius";
            this.ArminiusChekBox.UseVisualStyleBackColor = true;
            // 
            // boudicaChekbox
            // 
            this.boudicaChekbox.AutoSize = true;
            this.boudicaChekbox.Checked = true;
            this.boudicaChekbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boudicaChekbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boudicaChekbox.Location = new System.Drawing.Point(3, 33);
            this.boudicaChekbox.Name = "boudicaChekbox";
            this.boudicaChekbox.Size = new System.Drawing.Size(86, 24);
            this.boudicaChekbox.TabIndex = 1;
            this.boudicaChekbox.Text = "Boudica";
            this.boudicaChekbox.UseVisualStyleBackColor = true;
            // 
            // vercingetorixChekBox
            // 
            this.vercingetorixChekBox.AutoSize = true;
            this.vercingetorixChekBox.Checked = true;
            this.vercingetorixChekBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vercingetorixChekBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vercingetorixChekBox.Location = new System.Drawing.Point(3, 93);
            this.vercingetorixChekBox.Name = "vercingetorixChekBox";
            this.vercingetorixChekBox.Size = new System.Drawing.Size(120, 24);
            this.vercingetorixChekBox.TabIndex = 12;
            this.vercingetorixChekBox.Text = "Vercingetorix";
            this.vercingetorixChekBox.UseVisualStyleBackColor = true;
            // 
            // AmbiorixChekbox
            // 
            this.AmbiorixChekbox.AutoSize = true;
            this.AmbiorixChekbox.Checked = true;
            this.AmbiorixChekbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AmbiorixChekbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiorixChekbox.Location = new System.Drawing.Point(3, 63);
            this.AmbiorixChekbox.Name = "AmbiorixChekbox";
            this.AmbiorixChekbox.Size = new System.Drawing.Size(88, 24);
            this.AmbiorixChekbox.TabIndex = 11;
            this.AmbiorixChekbox.Text = "Ambiorix";
            this.AmbiorixChekbox.UseVisualStyleBackColor = true;
            // 
            // CarthagePanel
            // 
            this.CarthagePanel.Controls.Add(this.HannibalChekBox);
            this.CarthagePanel.Controls.Add(this.HasdrubalChekBox);
            this.CarthagePanel.Location = new System.Drawing.Point(16, 183);
            this.CarthagePanel.Name = "CarthagePanel";
            this.CarthagePanel.Size = new System.Drawing.Size(183, 122);
            this.CarthagePanel.TabIndex = 15;
            // 
            // HannibalChekBox
            // 
            this.HannibalChekBox.AutoSize = true;
            this.HannibalChekBox.Checked = true;
            this.HannibalChekBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HannibalChekBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HannibalChekBox.Location = new System.Drawing.Point(3, 3);
            this.HannibalChekBox.Name = "HannibalChekBox";
            this.HannibalChekBox.Size = new System.Drawing.Size(91, 24);
            this.HannibalChekBox.TabIndex = 0;
            this.HannibalChekBox.Text = "Hannibal";
            this.HannibalChekBox.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.HannibalChekBox.UseVisualStyleBackColor = true;
            // 
            // HasdrubalChekBox
            // 
            this.HasdrubalChekBox.AutoSize = true;
            this.HasdrubalChekBox.Checked = true;
            this.HasdrubalChekBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HasdrubalChekBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HasdrubalChekBox.Location = new System.Drawing.Point(3, 33);
            this.HasdrubalChekBox.Name = "HasdrubalChekBox";
            this.HasdrubalChekBox.Size = new System.Drawing.Size(101, 24);
            this.HasdrubalChekBox.TabIndex = 1;
            this.HasdrubalChekBox.Text = "Hasdrubal";
            this.HasdrubalChekBox.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.OrangeRed;
            this.button4.Location = new System.Drawing.Point(332, 100);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(165, 54);
            this.button4.TabIndex = 17;
            this.button4.Text = "TESTING";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // TestWorker
            // 
            this.TestWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.TestingWorker);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(607, 562);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.CarthagePanel);
            this.Controls.Add(this.BarbarianPanel);
            this.Controls.Add(this.GreecePanel);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.RomanPanel);
            this.Controls.Add(this.FactionComboBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.GamePlayed);
            this.Controls.Add(this.ElapsedTime_Label);
            this.Controls.Add(this.GamePLayed_Label);
            this.Controls.Add(this.ElapsedTime);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Germanibot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.RomanPanel.ResumeLayout(false);
            this.RomanPanel.PerformLayout();
            this.GreecePanel.ResumeLayout(false);
            this.GreecePanel.PerformLayout();
            this.BarbarianPanel.ResumeLayout(false);
            this.BarbarianPanel.PerformLayout();
            this.CarthagePanel.ResumeLayout(false);
            this.CarthagePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.CheckBox SullaChekBox;
        private System.Windows.Forms.CheckBox GermanicusChekBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label ElapsedTime;
        private System.Windows.Forms.Label GamePLayed_Label;
        private System.Windows.Forms.Label ElapsedTime_Label;
        private System.Windows.Forms.Label GamePlayed;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KeyboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StatsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showStatsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.CheckBox CaesarCheckBox;
        private System.Windows.Forms.CheckBox ScipioChekbox;
        private System.Windows.Forms.ComboBox FactionComboBox;
        private System.Windows.Forms.Panel RomanPanel;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Panel GreecePanel;
        private System.Windows.Forms.CheckBox CynaneChekBox;
        private System.Windows.Forms.CheckBox LeonidasChekBox;
        private System.Windows.Forms.CheckBox AlexanderChekBox;
        private System.Windows.Forms.CheckBox MilitiadesChekBox;
        private System.Windows.Forms.Panel BarbarianPanel;
        private System.Windows.Forms.CheckBox ArminiusChekBox;
        private System.Windows.Forms.CheckBox boudicaChekbox;
        private System.Windows.Forms.CheckBox vercingetorixChekBox;
        private System.Windows.Forms.CheckBox AmbiorixChekbox;
        private System.Windows.Forms.Panel CarthagePanel;
        private System.Windows.Forms.CheckBox HannibalChekBox;
        private System.Windows.Forms.CheckBox HasdrubalChekBox;
        public System.Windows.Forms.ToolStripMenuItem qWERTYToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aZERTYToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker TestWorker;
    }
}

