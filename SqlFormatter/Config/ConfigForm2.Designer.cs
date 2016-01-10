namespace SqlFormatter.Config
{
    partial class ConfigForm2
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
            this.TopReservedWordCase = new System.Windows.Forms.ComboBox();
            this.ReserveWordCase = new System.Windows.Forms.ComboBox();
            this.OtherWordCase = new System.Windows.Forms.ComboBox();
            this.SettingFileList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteComment = new System.Windows.Forms.CheckBox();
            this.GeneralIndentType = new System.Windows.Forms.ComboBox();
            this.GeneralIndentTypeLabel = new System.Windows.Forms.Label();
            this.TopReservedWordCaseLabel = new System.Windows.Forms.Label();
            this.ReservedWordCaseLabel = new System.Windows.Forms.Label();
            this.OtherWordCaseLabel = new System.Windows.Forms.Label();
            this.LinebreaksWithCommaLabel = new System.Windows.Forms.Label();
            this.LinebreaksWithComma = new System.Windows.Forms.ComboBox();
            this.AliasCaseLabel = new System.Windows.Forms.Label();
            this.TableNameCaseLabel = new System.Windows.Forms.Label();
            this.ColumnNameCaseLabel = new System.Windows.Forms.Label();
            this.TableNameCase = new System.Windows.Forms.ComboBox();
            this.ColumnNameCase = new System.Windows.Forms.ComboBox();
            this.AliaseNameCase = new System.Windows.Forms.ComboBox();
            this.TopReservedWordAfterIndentLabel = new System.Windows.Forms.Label();
            this.TopReservedWordAfterIndent = new System.Windows.Forms.ComboBox();
            this.WordsCaseType = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IsReservedWordLineBreak = new System.Windows.Forms.CheckBox();
            this.IsKeywordWhenIndent = new System.Windows.Forms.CheckBox();
            this.WhereClause = new System.Windows.Forms.GroupBox();
            this.AndOrIndentPattern = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OuterJoinSymbolCompretion = new System.Windows.Forms.ComboBox();
            this.OuterJoinSymbolCompretionLabel = new System.Windows.Forms.Label();
            this.OneEqualOneCompletion = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.WordsCaseType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.WhereClause.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopReservedWordCase
            // 
            this.TopReservedWordCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TopReservedWordCase.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TopReservedWordCase.FormattingEnabled = true;
            this.TopReservedWordCase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TopReservedWordCase.Items.AddRange(new object[] {
            "UpperCase",
            "LowerCase",
            "IniCap",
            "UnChanged"});
            this.TopReservedWordCase.Location = new System.Drawing.Point(306, 34);
            this.TopReservedWordCase.Name = "TopReservedWordCase";
            this.TopReservedWordCase.Size = new System.Drawing.Size(225, 31);
            this.TopReservedWordCase.TabIndex = 8;
            // 
            // ReserveWordCase
            // 
            this.ReserveWordCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ReserveWordCase.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ReserveWordCase.FormattingEnabled = true;
            this.ReserveWordCase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ReserveWordCase.Items.AddRange(new object[] {
            "UpperCase",
            "LowerCase",
            "IniCap",
            "UnChanged"});
            this.ReserveWordCase.Location = new System.Drawing.Point(306, 81);
            this.ReserveWordCase.Name = "ReserveWordCase";
            this.ReserveWordCase.Size = new System.Drawing.Size(225, 31);
            this.ReserveWordCase.TabIndex = 11;
            // 
            // OtherWordCase
            // 
            this.OtherWordCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OtherWordCase.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OtherWordCase.FormattingEnabled = true;
            this.OtherWordCase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OtherWordCase.Items.AddRange(new object[] {
            "UpperCase",
            "LowerCase",
            "IniCap",
            "UnChanged"});
            this.OtherWordCase.Location = new System.Drawing.Point(306, 272);
            this.OtherWordCase.Name = "OtherWordCase";
            this.OtherWordCase.Size = new System.Drawing.Size(225, 31);
            this.OtherWordCase.TabIndex = 12;
            // 
            // SettingFileList
            // 
            this.SettingFileList.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SettingFileList.FormattingEnabled = true;
            this.SettingFileList.Location = new System.Drawing.Point(342, 54);
            this.SettingFileList.Name = "SettingFileList";
            this.SettingFileList.Size = new System.Drawing.Size(225, 31);
            this.SettingFileList.TabIndex = 0;
            this.SettingFileList.TextChanged += new System.EventHandler(this.SettingFileList_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(39, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Setting File Name";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1238, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "configMenuStrip";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(55, 29);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F11)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // DeleteComment
            // 
            this.DeleteComment.AutoSize = true;
            this.DeleteComment.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DeleteComment.Location = new System.Drawing.Point(42, 102);
            this.DeleteComment.Name = "DeleteComment";
            this.DeleteComment.Size = new System.Drawing.Size(182, 27);
            this.DeleteComment.TabIndex = 3;
            this.DeleteComment.Text = "Delete Comment";
            this.DeleteComment.UseVisualStyleBackColor = true;
            // 
            // GeneralIndentType
            // 
            this.GeneralIndentType.DisplayMember = "Tab";
            this.GeneralIndentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GeneralIndentType.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GeneralIndentType.FormattingEnabled = true;
            this.GeneralIndentType.Items.AddRange(new object[] {
            "Tab",
            "4Space"});
            this.GeneralIndentType.Location = new System.Drawing.Point(342, 148);
            this.GeneralIndentType.Name = "GeneralIndentType";
            this.GeneralIndentType.Size = new System.Drawing.Size(225, 31);
            this.GeneralIndentType.TabIndex = 5;
            this.GeneralIndentType.Tag = "Tab";
            this.GeneralIndentType.ValueMember = "Tab";
            // 
            // GeneralIndentTypeLabel
            // 
            this.GeneralIndentTypeLabel.AutoSize = true;
            this.GeneralIndentTypeLabel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneralIndentTypeLabel.Location = new System.Drawing.Point(39, 152);
            this.GeneralIndentTypeLabel.Name = "GeneralIndentTypeLabel";
            this.GeneralIndentTypeLabel.Size = new System.Drawing.Size(193, 23);
            this.GeneralIndentTypeLabel.TabIndex = 6;
            this.GeneralIndentTypeLabel.Text = "General Indent Type:";
            // 
            // TopReservedWordCaseLabel
            // 
            this.TopReservedWordCaseLabel.AutoSize = true;
            this.TopReservedWordCaseLabel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopReservedWordCaseLabel.Location = new System.Drawing.Point(13, 34);
            this.TopReservedWordCaseLabel.Name = "TopReservedWordCaseLabel";
            this.TopReservedWordCaseLabel.Size = new System.Drawing.Size(215, 23);
            this.TopReservedWordCaseLabel.TabIndex = 7;
            this.TopReservedWordCaseLabel.Text = "TopReservedWordCase:";
            // 
            // ReservedWordCaseLabel
            // 
            this.ReservedWordCaseLabel.AutoSize = true;
            this.ReservedWordCaseLabel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReservedWordCaseLabel.Location = new System.Drawing.Point(13, 81);
            this.ReservedWordCaseLabel.Name = "ReservedWordCaseLabel";
            this.ReservedWordCaseLabel.Size = new System.Drawing.Size(184, 23);
            this.ReservedWordCaseLabel.TabIndex = 9;
            this.ReservedWordCaseLabel.Text = "ReservedWordCase:";
            // 
            // OtherWordCaseLabel
            // 
            this.OtherWordCaseLabel.AutoSize = true;
            this.OtherWordCaseLabel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherWordCaseLabel.Location = new System.Drawing.Point(635, 374);
            this.OtherWordCaseLabel.Name = "OtherWordCaseLabel";
            this.OtherWordCaseLabel.Size = new System.Drawing.Size(154, 23);
            this.OtherWordCaseLabel.TabIndex = 10;
            this.OtherWordCaseLabel.Text = "OtherWordCase:";
            // 
            // LinebreaksWithCommaLabel
            // 
            this.LinebreaksWithCommaLabel.AutoSize = true;
            this.LinebreaksWithCommaLabel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinebreaksWithCommaLabel.Location = new System.Drawing.Point(39, 201);
            this.LinebreaksWithCommaLabel.Name = "LinebreaksWithCommaLabel";
            this.LinebreaksWithCommaLabel.Size = new System.Drawing.Size(225, 23);
            this.LinebreaksWithCommaLabel.TabIndex = 13;
            this.LinebreaksWithCommaLabel.Text = "Linebreaks with comma:";
            // 
            // LinebreaksWithComma
            // 
            this.LinebreaksWithComma.DisplayMember = "Tab";
            this.LinebreaksWithComma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LinebreaksWithComma.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LinebreaksWithComma.FormattingEnabled = true;
            this.LinebreaksWithComma.Items.AddRange(new object[] {
            "Before",
            "After"});
            this.LinebreaksWithComma.Location = new System.Drawing.Point(342, 198);
            this.LinebreaksWithComma.Name = "LinebreaksWithComma";
            this.LinebreaksWithComma.Size = new System.Drawing.Size(225, 31);
            this.LinebreaksWithComma.TabIndex = 14;
            this.LinebreaksWithComma.Tag = "Tab";
            this.LinebreaksWithComma.ValueMember = "Tab";
            // 
            // AliasCaseLabel
            // 
            this.AliasCaseLabel.AutoSize = true;
            this.AliasCaseLabel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AliasCaseLabel.Location = new System.Drawing.Point(13, 225);
            this.AliasCaseLabel.Name = "AliasCaseLabel";
            this.AliasCaseLabel.Size = new System.Drawing.Size(100, 23);
            this.AliasCaseLabel.TabIndex = 15;
            this.AliasCaseLabel.Text = "AliasCase:";
            // 
            // TableNameCaseLabel
            // 
            this.TableNameCaseLabel.AutoSize = true;
            this.TableNameCaseLabel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableNameCaseLabel.Location = new System.Drawing.Point(13, 126);
            this.TableNameCaseLabel.Name = "TableNameCaseLabel";
            this.TableNameCaseLabel.Size = new System.Drawing.Size(154, 23);
            this.TableNameCaseLabel.TabIndex = 16;
            this.TableNameCaseLabel.Text = "TableNameCase:";
            // 
            // ColumnNameCaseLabel
            // 
            this.ColumnNameCaseLabel.AutoSize = true;
            this.ColumnNameCaseLabel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnNameCaseLabel.Location = new System.Drawing.Point(15, 175);
            this.ColumnNameCaseLabel.Name = "ColumnNameCaseLabel";
            this.ColumnNameCaseLabel.Size = new System.Drawing.Size(176, 23);
            this.ColumnNameCaseLabel.TabIndex = 17;
            this.ColumnNameCaseLabel.Text = "ColumnNameCase:";
            // 
            // TableNameCase
            // 
            this.TableNameCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TableNameCase.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TableNameCase.FormattingEnabled = true;
            this.TableNameCase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TableNameCase.Items.AddRange(new object[] {
            "UpperCase",
            "LowerCase",
            "IniCap",
            "UnChanged"});
            this.TableNameCase.Location = new System.Drawing.Point(306, 123);
            this.TableNameCase.Name = "TableNameCase";
            this.TableNameCase.Size = new System.Drawing.Size(225, 31);
            this.TableNameCase.TabIndex = 18;
            // 
            // ColumnNameCase
            // 
            this.ColumnNameCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColumnNameCase.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ColumnNameCase.FormattingEnabled = true;
            this.ColumnNameCase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ColumnNameCase.Items.AddRange(new object[] {
            "UpperCase",
            "LowerCase",
            "IniCap",
            "UnChanged"});
            this.ColumnNameCase.Location = new System.Drawing.Point(306, 172);
            this.ColumnNameCase.Name = "ColumnNameCase";
            this.ColumnNameCase.Size = new System.Drawing.Size(225, 31);
            this.ColumnNameCase.TabIndex = 19;
            // 
            // AliaseNameCase
            // 
            this.AliaseNameCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AliaseNameCase.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AliaseNameCase.FormattingEnabled = true;
            this.AliaseNameCase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AliaseNameCase.Items.AddRange(new object[] {
            "UpperCase",
            "LowerCase",
            "IniCap",
            "UnChanged"});
            this.AliaseNameCase.Location = new System.Drawing.Point(306, 222);
            this.AliaseNameCase.Name = "AliaseNameCase";
            this.AliaseNameCase.Size = new System.Drawing.Size(225, 31);
            this.AliaseNameCase.TabIndex = 20;
            // 
            // TopReservedWordAfterIndentLabel
            // 
            this.TopReservedWordAfterIndentLabel.AutoSize = true;
            this.TopReservedWordAfterIndentLabel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopReservedWordAfterIndentLabel.Location = new System.Drawing.Point(34, 247);
            this.TopReservedWordAfterIndentLabel.Name = "TopReservedWordAfterIndentLabel";
            this.TopReservedWordAfterIndentLabel.Size = new System.Drawing.Size(273, 23);
            this.TopReservedWordAfterIndentLabel.TabIndex = 23;
            this.TopReservedWordAfterIndentLabel.Text = "TopReservedWordAfterIndent:";
            // 
            // TopReservedWordAfterIndent
            // 
            this.TopReservedWordAfterIndent.DisplayMember = "Tab";
            this.TopReservedWordAfterIndent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TopReservedWordAfterIndent.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TopReservedWordAfterIndent.FormattingEnabled = true;
            this.TopReservedWordAfterIndent.Items.AddRange(new object[] {
            "Always",
            "ExistsFunctionOnly",
            "Invalid"});
            this.TopReservedWordAfterIndent.Location = new System.Drawing.Point(342, 244);
            this.TopReservedWordAfterIndent.Name = "TopReservedWordAfterIndent";
            this.TopReservedWordAfterIndent.Size = new System.Drawing.Size(225, 31);
            this.TopReservedWordAfterIndent.TabIndex = 24;
            this.TopReservedWordAfterIndent.Tag = "Tab";
            this.TopReservedWordAfterIndent.ValueMember = "Tab";
            // 
            // WordsCaseType
            // 
            this.WordsCaseType.Controls.Add(this.OtherWordCase);
            this.WordsCaseType.Controls.Add(this.AliasCaseLabel);
            this.WordsCaseType.Controls.Add(this.ColumnNameCaseLabel);
            this.WordsCaseType.Controls.Add(this.AliaseNameCase);
            this.WordsCaseType.Controls.Add(this.TableNameCaseLabel);
            this.WordsCaseType.Controls.Add(this.ColumnNameCase);
            this.WordsCaseType.Controls.Add(this.TableNameCase);
            this.WordsCaseType.Controls.Add(this.TopReservedWordCase);
            this.WordsCaseType.Controls.Add(this.ReserveWordCase);
            this.WordsCaseType.Controls.Add(this.TopReservedWordCaseLabel);
            this.WordsCaseType.Controls.Add(this.ReservedWordCaseLabel);
            this.WordsCaseType.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.WordsCaseType.Location = new System.Drawing.Point(622, 102);
            this.WordsCaseType.Name = "WordsCaseType";
            this.WordsCaseType.Size = new System.Drawing.Size(573, 323);
            this.WordsCaseType.TabIndex = 26;
            this.WordsCaseType.TabStop = false;
            this.WordsCaseType.Text = "Words Case Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IsReservedWordLineBreak);
            this.groupBox1.Controls.Add(this.IsKeywordWhenIndent);
            this.groupBox1.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(622, 437);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 89);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Case Formula Settings";
            // 
            // IsReservedWordLineBreak
            // 
            this.IsReservedWordLineBreak.AutoSize = true;
            this.IsReservedWordLineBreak.Enabled = false;
            this.IsReservedWordLineBreak.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IsReservedWordLineBreak.Location = new System.Drawing.Point(293, 40);
            this.IsReservedWordLineBreak.Name = "IsReservedWordLineBreak";
            this.IsReservedWordLineBreak.Size = new System.Drawing.Size(250, 27);
            this.IsReservedWordLineBreak.TabIndex = 30;
            this.IsReservedWordLineBreak.Text = "Reserved word linebreak";
            this.IsReservedWordLineBreak.UseVisualStyleBackColor = true;
            // 
            // IsKeywordWhenIndent
            // 
            this.IsKeywordWhenIndent.AutoSize = true;
            this.IsKeywordWhenIndent.Enabled = false;
            this.IsKeywordWhenIndent.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IsKeywordWhenIndent.Location = new System.Drawing.Point(19, 40);
            this.IsKeywordWhenIndent.Name = "IsKeywordWhenIndent";
            this.IsKeywordWhenIndent.Size = new System.Drawing.Size(230, 27);
            this.IsKeywordWhenIndent.TabIndex = 28;
            this.IsKeywordWhenIndent.Text = "Keyword When Indent";
            this.IsKeywordWhenIndent.UseVisualStyleBackColor = true;
            // 
            // WhereClause
            // 
            this.WhereClause.Controls.Add(this.AndOrIndentPattern);
            this.WhereClause.Controls.Add(this.label3);
            this.WhereClause.Controls.Add(this.OuterJoinSymbolCompretion);
            this.WhereClause.Controls.Add(this.OuterJoinSymbolCompretionLabel);
            this.WhereClause.Controls.Add(this.OneEqualOneCompletion);
            this.WhereClause.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.WhereClause.Location = new System.Drawing.Point(27, 296);
            this.WhereClause.Name = "WhereClause";
            this.WhereClause.Size = new System.Drawing.Size(567, 233);
            this.WhereClause.TabIndex = 31;
            this.WhereClause.TabStop = false;
            this.WhereClause.Text = "Where Clause Settings";
            // 
            // AndOrIndentPattern
            // 
            this.AndOrIndentPattern.DisplayMember = "Tab";
            this.AndOrIndentPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AndOrIndentPattern.Enabled = false;
            this.AndOrIndentPattern.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AndOrIndentPattern.FormattingEnabled = true;
            this.AndOrIndentPattern.Items.AddRange(new object[] {
            "Before",
            "After"});
            this.AndOrIndentPattern.Location = new System.Drawing.Point(315, 159);
            this.AndOrIndentPattern.Name = "AndOrIndentPattern";
            this.AndOrIndentPattern.Size = new System.Drawing.Size(225, 31);
            this.AndOrIndentPattern.TabIndex = 32;
            this.AndOrIndentPattern.Tag = "Tab";
            this.AndOrIndentPattern.ValueMember = "Tab";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 23);
            this.label3.TabIndex = 32;
            this.label3.Text = "Linebreaks with And&&Or Words:";
            // 
            // OuterJoinSymbolCompretion
            // 
            this.OuterJoinSymbolCompretion.DisplayMember = "Tab";
            this.OuterJoinSymbolCompretion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OuterJoinSymbolCompretion.Enabled = false;
            this.OuterJoinSymbolCompretion.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OuterJoinSymbolCompretion.FormattingEnabled = true;
            this.OuterJoinSymbolCompretion.Items.AddRange(new object[] {
            "Left",
            "Right",
            "UnChanged"});
            this.OuterJoinSymbolCompretion.Location = new System.Drawing.Point(315, 103);
            this.OuterJoinSymbolCompretion.Name = "OuterJoinSymbolCompretion";
            this.OuterJoinSymbolCompretion.Size = new System.Drawing.Size(225, 31);
            this.OuterJoinSymbolCompretion.TabIndex = 32;
            this.OuterJoinSymbolCompretion.Tag = "Tab";
            this.OuterJoinSymbolCompretion.ValueMember = "Tab";
            // 
            // OuterJoinSymbolCompretionLabel
            // 
            this.OuterJoinSymbolCompretionLabel.AutoSize = true;
            this.OuterJoinSymbolCompretionLabel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OuterJoinSymbolCompretionLabel.Location = new System.Drawing.Point(12, 106);
            this.OuterJoinSymbolCompretionLabel.Name = "OuterJoinSymbolCompretionLabel";
            this.OuterJoinSymbolCompretionLabel.Size = new System.Drawing.Size(266, 23);
            this.OuterJoinSymbolCompretionLabel.TabIndex = 32;
            this.OuterJoinSymbolCompretionLabel.Text = "(+) - Outer Join Compretion:";
            // 
            // OneEqualOneCompletion
            // 
            this.OneEqualOneCompletion.AutoSize = true;
            this.OneEqualOneCompletion.Enabled = false;
            this.OneEqualOneCompletion.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OneEqualOneCompletion.Location = new System.Drawing.Point(19, 50);
            this.OneEqualOneCompletion.Name = "OneEqualOneCompletion";
            this.OneEqualOneCompletion.Size = new System.Drawing.Size(178, 27);
            this.OneEqualOneCompletion.TabIndex = 28;
            this.OneEqualOneCompletion.Text = "1=1 Completion";
            this.OneEqualOneCompletion.UseVisualStyleBackColor = true;
            // 
            // ConfigForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1238, 555);
            this.Controls.Add(this.WhereClause);
            this.Controls.Add(this.TopReservedWordAfterIndent);
            this.Controls.Add(this.TopReservedWordAfterIndentLabel);
            this.Controls.Add(this.LinebreaksWithComma);
            this.Controls.Add(this.LinebreaksWithCommaLabel);
            this.Controls.Add(this.OtherWordCaseLabel);
            this.Controls.Add(this.GeneralIndentTypeLabel);
            this.Controls.Add(this.GeneralIndentType);
            this.Controls.Add(this.DeleteComment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SettingFileList);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.WordsCaseType);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ConfigForm2";
            this.Text = "ConfigForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.WordsCaseType.ResumeLayout(false);
            this.WordsCaseType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.WhereClause.ResumeLayout(false);
            this.WhereClause.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SettingFileList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox DeleteComment;
        private System.Windows.Forms.ComboBox GeneralIndentType;
        private System.Windows.Forms.Label GeneralIndentTypeLabel;
        private System.Windows.Forms.Label TopReservedWordCaseLabel;
        private System.Windows.Forms.Label ReservedWordCaseLabel;
        private System.Windows.Forms.Label OtherWordCaseLabel;
        private System.Windows.Forms.Label LinebreaksWithCommaLabel;
        private System.Windows.Forms.ComboBox LinebreaksWithComma;
        private System.Windows.Forms.ComboBox TopReservedWordCase;
        private System.Windows.Forms.ComboBox ReserveWordCase;
        private System.Windows.Forms.ComboBox OtherWordCase;
        private System.Windows.Forms.Label AliasCaseLabel;
        private System.Windows.Forms.Label TableNameCaseLabel;
        private System.Windows.Forms.Label ColumnNameCaseLabel;
        private System.Windows.Forms.ComboBox TableNameCase;
        private System.Windows.Forms.ComboBox ColumnNameCase;
        private System.Windows.Forms.ComboBox AliaseNameCase;
        private System.Windows.Forms.Label TopReservedWordAfterIndentLabel;
        private System.Windows.Forms.ComboBox TopReservedWordAfterIndent;
        private System.Windows.Forms.GroupBox WordsCaseType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox IsReservedWordLineBreak;
        private System.Windows.Forms.CheckBox IsKeywordWhenIndent;
        private System.Windows.Forms.GroupBox WhereClause;
        private System.Windows.Forms.ComboBox OuterJoinSymbolCompretion;
        private System.Windows.Forms.Label OuterJoinSymbolCompretionLabel;
        private System.Windows.Forms.CheckBox OneEqualOneCompletion;
        private System.Windows.Forms.ComboBox AndOrIndentPattern;
        private System.Windows.Forms.Label label3;
    }
}