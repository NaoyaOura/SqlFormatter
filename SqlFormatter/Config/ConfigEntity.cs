namespace SqlFormatter.Config
{
    public enum IndentType
    {
        Tab,Space4
    }
    
    public enum CaseType
    {
        UpperCase,LowerCase,IniCap,UnChanged
    }

    public enum IndentPattern
    {
        Before,After
    }

    public enum TopReservedWordIndentType
    {
        Always,ExistsFunctionOnly,Invalid
    }

    public enum OuterJoinComplement
    {
        Left,Right,UnChanged
    }

    public class ConfigEntity
    {
        public string Name { get; set; }
        public bool IsDeleteComment { get; set; }
        public IndentType GeneralIndentType { get; set; }
        public TopReservedWordIndentType TopReservedWordAfterIndent { get; set; }
        public bool OneEqualOneComplement { get; set; }
        public OuterJoinComplement OuterJoinComplement { get; set; }
        public IndentPattern CommaIndentPattern { get; set; }
        public IndentPattern AndOrIndentPattern { get; set; }
        public CaseType TopReservedWordCase { get; set; }
        public CaseType ReservedWordCase { get; set; }
        public CaseType TableNameCase { get; set; }
        public CaseType ColumnNameCase { get; set; }
        public CaseType AliasNameCase { get; set; }
        public CaseType OtherWordCase { get; set; }
        public bool IsKeywordWhenIndent { get; set; }
        public bool IsReservedWordLineBreak { get; set; }

        //////////////////////////////////////////
        // Config画面非表示の設定項目(TODO 整理&拡張用)
        //////////////////////////////////////////
        [System.Xml.Serialization.XmlIgnore]
        public bool IsDeleteCommentBeforeWhiteSpace { get; set; }
        
        [System.Xml.Serialization.XmlIgnore]
        public bool IsDeleteCommentAfterWhiteSpace { get; set; }
        
        [System.Xml.Serialization.XmlIgnore]
        public bool IsDeleteOneLineComment { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public bool IsDeleteMultiLineComment { get; set; }
        /// <summary>
        /// Alias定義のASを補完する
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public bool IsReservedWordAsComplement { get; set; }
        /// <summary>
        /// Column AliasであればAS区のあとの空白スペース
        /// Table Aliasであれば定義前の空白
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public string BeforeAliasDefineWhiteSpace { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public string LineSeparator;
        [System.Xml.Serialization.XmlIgnore]
        public CaseType StatementSeparatorCase { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public int MaxIndenSize;
        public ConfigEntity()
        {
            IsDeleteCommentBeforeWhiteSpace = false;
            IsDeleteCommentAfterWhiteSpace = true;
            IsReservedWordAsComplement = true;
            LineSeparator = "\r\n";
            MaxIndenSize = 1000;
            IsDeleteOneLineComment = IsDeleteComment;
            IsDeleteMultiLineComment = IsDeleteComment;
            BeforeAliasDefineWhiteSpace = " ";
            StatementSeparatorCase = CaseType.UpperCase;
        }
    }
}
