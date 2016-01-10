using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SqlFormatter.Config;
using SqlFormatter.SQL.Ast;
using SqlFormatter.SQL.Ast.Parser;
using SqlFormatter.SQL.Ast.Transformer;
using SqlFormatter.SQL.Ast.Visitor;
using SqlFormatter.Tools;

namespace SqlFormatter
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// configファイルを格納するディレクトリパス
        /// </summary>
        private readonly string _defaultDirectory = Directory.GetCurrentDirectory() + "\\config";

        public MainForm()
        {
            InitializeComponent();
            string filePah = _defaultDirectory + "\\" + SettingFileList.Text + ".xml";
            if (!File.Exists(filePah))
            {
                MessageBox.Show(@"[Setting File Name]が正しい値ではありません。"
                        , @"Warning"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);
                return;
            }
            _entity = Serializer.Load<ConfigEntity>(filePah);
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (HasNotParameter())
            {
                MessageBox.Show(@"[Setting File Name]が正しい値ではありません。"
                        ,   @"ERROR"
                        ,   MessageBoxButtons.OK
                        ,   MessageBoxIcon.Error);
                return;
            }
            Properties.Settings.Default.Save();
            SqlAstParser sqlAstParser = new SqlAstParser();
            SqlCompilationUnit unit = sqlAstParser.Parse(SqlTextBox.Text);
            SqlAstVisitor visitor = new SqlFormatVisitor(_entity);
            IList<ITransformer> transformers = new List<ITransformer>();
            transformers.Add(new CaseTransform(_entity));
            transformers.Add(new CommentTransform(_entity.IsDeleteComment));
            unit.Accept(visitor,transformers);
            ResultTextBox.Text = visitor.ResultSql;
        }

        private void OptionAndSettingsButton_Click(object sender, EventArgs e)
        {
            ConfigForm2 cf = new ConfigForm2();
            cf.Show();

            // リロードする
            string filePah = _defaultDirectory + "\\" + SettingFileList.Text + ".xml";
            if (File.Exists(filePah))
            {
                _entity = Serializer.Load<ConfigEntity>(filePah);
            }
        }

        private void SettingFileList_TextChanged(object sender, EventArgs e)
        {
            string filePah = _defaultDirectory + "\\" + SettingFileList.Text + ".xml";
            _entity = Serializer.Load<ConfigEntity>(filePah);
        }

        private bool HasNotParameter()
        {
            if (_entity == null)
            {
                return true;
            }
            return false;
        }

        private void SettingFileList_Click(object sender, EventArgs e)
        {
            
            if (!Directory.Exists(_defaultDirectory))
            {
                Directory.CreateDirectory(_defaultDirectory);
            }
            else if(SettingFileList.Items.Count == 0)
            {
                foreach (string path in Directory.GetFiles(_defaultDirectory))
                {
                    string fileName = Path.GetFileNameWithoutExtension(path);
                    if (fileName != null) SettingFileList.Items.Add(fileName);
                }
            }
        }
    }
}
