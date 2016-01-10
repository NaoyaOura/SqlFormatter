using SqlFormatter.SQL.Ast.Transformer;
using SqlFormatter.SQL.Ast.Visitor;

namespace SqlFormatter.SQL.Ast.Definition
{
    /// <summary>
    /// 式となる単位、またはテーブルやカラム名を定義できる単位
    /// TODO class名はformulaのほうが適切？
    /// </summary>
    public class Statement : BaseAstNode
    {
        /// <summary>
        /// カンマやAND、ORを含むか（予約語直後のときはfalse）
        /// </summary>
        public bool HasStatementSeparator { get; set; }

        /// <summary>
        /// カンマかAND、ORの文字列を格納
        /// </summary>
        public string StatementSeparatorValue { get; set; }

        /// <summary>
        /// かっこなどでネストした構造をもっているか
        /// </summary>
        public bool HasNestStatement { get; set; }
 
        /// <summary>
        /// イコールが出現するか否か
        /// </summary>
        public string EvaluationValue { get; set; }

        /// <summary>
        /// 通常はLeftIndentのみだが、Where句やCase句などイコールが出現するとき、
        /// LeftIndentLengthにはイコールが出現するまでの文字列数のみがカウントされる
        /// </summary>
        public int LeftIndentLength { get; set; }

        public override void Initialize()
        {
            ParentNodeBecome = true;
            ParentNodeToggleIs = false;
            HasNestStatement = false;
            HasStatementSeparator = false;
            EvaluationValue = string.Empty;
            LeftIndentLength = 0;
        }

        public Statement(IAstNode beforeNode, string originalValue, bool parentNodeToggleIs)
            :base(beforeNode, originalValue)
        {
            ParentNodeToggleIs = parentNodeToggleIs;
            SetParentWithChildNode();
        }

        /// <summary>
        /// baseクラスのコンストラクタにない引数のparentNodeToggleIsが利用できないため、
        /// SetParentWithChildNodeで実行
        /// </summary>
        public override void SetParentNode(){ }

        private void SetParentWithChildNode()
        {
            if (ParentNodeToggleIs)
            {
                if (BeforeNode.ParentNode.ParentNode != null)
                {
                    // カンマやAND、ORによりエイリアスの単位が異なるが定義群の単位が同一階層のとき
                    ParentNode = BeforeNode.ParentNode.ParentNode;
                    Level = BeforeNode.Level - 1;
                    BeforeNode.ParentNode.ParentNode.SetParentInChildNode(this);
                }
                else
                {
                    // 第一階層のFrom句などは、親がないためParentノードがnullのとき
                    Level = 0;
                }
            }
            else
            {
                // SELECTのあとなど予約語の直後のStatementのとき
                ParentNode = BeforeNode;
                Level = BeforeNode.Level + 1;
                BeforeNode.SetParentInChildNode(this);
            }
        }

        /// <summary>
        /// Statementの子供を設定するとき、
        /// 子供の内容からStatementの構成情報を作成
        /// </summary>
        /// <param name="node"></param>
        public override void SetParentInChildNode(IAstNode node)
        {
            if (node.GetType() == typeof (Bracket))
            {
                HasNestStatement = true;
            }
            else if (node.GetType() == typeof (StatementSeparator))
            {
                HasStatementSeparator = true;
                StatementSeparatorValue = node.OriginalValue;
            }
            else if (node.GetType() == typeof (EvaluationString))
            {
                EvaluationValue = node.OriginalValue;
            }
            else if (   // =やLIKEなど評価等号が出現したあとは文字数をカウントしない
                        !string.IsNullOrEmpty(EvaluationValue)
                        // コメントやAS句はインデントを決定する文字列に利用しない
                     || node.OriginalValue.Equals("AS")
                     || node.GetType() == typeof (AliasDefine)
                     || node.GetType() == typeof (WhiteSpace)
                     || node.GetType() == typeof (OneLineComment)
                     || node.GetType() == typeof (MultiLineComment))
            {
            }
            else
            {
                LeftIndentLength += node.OriginalValue.Length;
            }
            base.SetParentInChildNode(node);
        }

        public override bool Accept(ISqlAstVisitor visitor)
        {
            return visitor.Visit(this);
        }
        public override bool Transform(ITransformer transformer)
        {
            return transformer.Transform(this);
        }
    }
}
