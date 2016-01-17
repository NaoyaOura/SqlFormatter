using System;
using System.IO;
using System.Windows.Forms;

namespace SqlFormatter.Config
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ConfigForm2 : Form
    {
        /// <summary>
        /// configファイルを格納するディレクトリパス
        /// </summary>
        private readonly string _defaultDirectory = Directory.GetCurrentDirectory() + "\\config";

        /// <summary>
        /// 現在読み込んでいるファイルパス
        /// </summary>
        private string _filePath;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ConfigForm2()
        {
            InitializeComponent();

            if (!Directory.Exists(_defaultDirectory))
            {
                Directory.CreateDirectory(_defaultDirectory);
                return;
            }

            foreach (string path in Directory.GetFiles(_defaultDirectory))
            {
                string fileName = Path.GetFileNameWithoutExtension(path);
                if (fileName != null) SettingFileList.Items.Add(item: fileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigEntity entity = GetSaveData();
            if (entity == null)
            {
                // エラーのとき
                return;
            }
            if (_filePath == null)
            {
                // 保存先を指定するダイアログを表示
                _filePath = ShowSaveFileDialog();

                if (_filePath == null)
                {
                    // キャンセルや文字列が入力されなかったとき
                    return;
                }
            }
            Tools.Serializer.Save(entity, _filePath);
            MessageBox.Show(@"保存しました", @"Success");
        }

        private ConfigEntity GetSaveData()
        {
            try
            {
                ConfigEntity entity = new ConfigEntity
                {
                    IsDeleteComment = DeleteComment.Checked,
                    GeneralIndentType = (IndentType)Enum.Parse(typeof(IndentType), GeneralIndentType.Text),
                    TopReservedWordAfterIndent = (TopReservedWordIndentType)Enum.Parse(typeof(TopReservedWordIndentType), TopReservedWordAfterIndent.Text),
                    OneEqualOneComplement = OneEqualOneCompletion.Checked,
                    CommaIndentPattern = (IndentPattern)Enum.Parse(typeof(IndentPattern), LinebreaksWithComma.Text),
                    AndOrIndentPattern = (IndentPattern)Enum.Parse(typeof(IndentPattern), AndOrIndentPattern.Text),
                    OuterJoinComplement = (OuterJoinComplement)Enum.Parse(typeof(OuterJoinComplement), OuterJoinSymbolCompretion.Text),
                    TopReservedWordCase = (CaseType)Enum.Parse(typeof(CaseType), TopReservedWordCase.Text),
                    ReservedWordCase = (CaseType)Enum.Parse(typeof(CaseType), ReserveWordCase.Text),
                    TableNameCase = (CaseType)Enum.Parse(typeof(CaseType), TableNameCase.Text),
                    ColumnNameCase = (CaseType)Enum.Parse(typeof(CaseType), ColumnNameCase.Text),
                    AliasNameCase = (CaseType)Enum.Parse(typeof(CaseType), AliaseNameCase.Text),
                    OtherWordCase = (CaseType)Enum.Parse(typeof(CaseType), OtherWordCase.Text),
                    IsKeywordWhenIndent = IsKeywordWhenIndent.Checked,
                    IsReservedWordLineBreak = IsReservedWordLineBreak.Checked
                };
                return entity;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"入力項目が不足しています", @"Exception");
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        private string ShowSaveFileDialog()
        {
            string fileName = SettingFileList.Text;
            if (string.IsNullOrEmpty(fileName)) fileName = "config";
            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = fileName + ".xml",
                InitialDirectory = _defaultDirectory,
                Filter = @"設定ファイル(*.xml)|*.*",
                FilterIndex = 1,
                Title = @"保存先のファイルを選択してください"
            };

            return sfd.ShowDialog() == DialogResult.OK ? sfd.FileName : null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingFileList_TextChanged(object sender, EventArgs e)
        {
            string filePath = _defaultDirectory + "\\" + SettingFileList.Text + ".xml";

            // 入力された文字列が新規文字列かチェックする
            if (!File.Exists(filePath))
            {
                _filePath = null;
                return;
            }
            if (MessageBox.Show(@"編集中の内容があれば、その入力内容が消えますがよろしいでしょうか？"
                , @"Warning"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _filePath = filePath;
            SetConfigData();
        }

        private void SetConfigData()
        {
            ConfigEntity entity = Tools.Serializer.Load<ConfigEntity>(_filePath);
            DeleteComment.Checked = entity.IsDeleteComment;
            GeneralIndentType.Text = entity.GeneralIndentType.ToString();
            LinebreaksWithComma.Text = entity.CommaIndentPattern.ToString();
            AndOrIndentPattern.Text = entity.AndOrIndentPattern.ToString();
            OneEqualOneCompletion.Checked = entity.OneEqualOneComplement;
            TopReservedWordCase.Text = entity.TopReservedWordCase.ToString();
            OuterJoinSymbolCompretion.Text = entity.OuterJoinComplement.ToString();
            OtherWordCase.Text = entity.OtherWordCase.ToString();
            TableNameCase.Text = entity.TableNameCase.ToString();
            ColumnNameCase.Text = entity.ColumnNameCase.ToString();
            AliaseNameCase.Text = entity.AliasNameCase.ToString();
            ReserveWordCase.Text = entity.ReservedWordCase.ToString();
            TopReservedWordAfterIndent.Text = entity.TopReservedWordAfterIndent.ToString();
            IsKeywordWhenIndent.Checked = entity.IsKeywordWhenIndent;
            IsReservedWordLineBreak.Checked = entity.IsReservedWordLineBreak;
        }
    }
}
