using SqlFormatter.Config;

namespace SqlFormatter
{
    partial class MainForm
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
            this.GenerateButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionAndSettingsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.RichTextBox();
            this.SqlTextBox = new System.Windows.Forms.RichTextBox();
            this.SettingFileList = new System.Windows.Forms.ComboBox();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(513, 333);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(75, 41);
            this.GenerateButton.TabIndex = 2;
            this.GenerateButton.Text = "変換";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1298, 33);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionAndSettingsButton,
            this.exitToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(55, 29);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // OptionAndSettingsButton
            // 
            this.OptionAndSettingsButton.Name = "OptionAndSettingsButton";
            this.OptionAndSettingsButton.Size = new System.Drawing.Size(280, 30);
            this.OptionAndSettingsButton.Text = "Options And Settings...";
            this.OptionAndSettingsButton.Click += new System.EventHandler(this.OptionAndSettingsButton_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(280, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(22, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Setting File Name";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ResultTextBox.Location = new System.Drawing.Point(594, 84);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(669, 495);
            this.ResultTextBox.TabIndex = 4;
            this.ResultTextBox.Text = "";
            // 
            // SqlTextBox
            // 
            this.SqlTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SqlFormatter.Properties.Settings.Default, "InputText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SqlTextBox.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SqlTextBox.Location = new System.Drawing.Point(26, 84);
            this.SqlTextBox.Name = "SqlTextBox";
            this.SqlTextBox.Size = new System.Drawing.Size(481, 495);
            this.SqlTextBox.TabIndex = 6;
            this.SqlTextBox.Text = global::SqlFormatter.Properties.Settings.Default.InputText;
            // 
            // SettingFileList
            // 
            this.SettingFileList.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SqlFormatter.Properties.Settings.Default, "SettingFileName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SettingFileList.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SettingFileList.FormattingEnabled = true;
            this.SettingFileList.Location = new System.Drawing.Point(251, 45);
            this.SettingFileList.Name = "SettingFileList";
            this.SettingFileList.Size = new System.Drawing.Size(256, 31);
            this.SettingFileList.TabIndex = 5;
            this.SettingFileList.Text = global::SqlFormatter.Properties.Settings.Default.SettingFileName;
            this.SettingFileList.TextChanged += new System.EventHandler(this.SettingFileList_TextChanged);
            this.SettingFileList.Click += new System.EventHandler(this.SettingFileList_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 623);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.SqlTextBox);
            this.Controls.Add(this.SettingFileList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionAndSettingsButton;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SettingFileList;
        private ConfigEntity _entity;
        private System.Windows.Forms.RichTextBox SqlTextBox;
        private System.Windows.Forms.RichTextBox ResultTextBox;
    }
}

