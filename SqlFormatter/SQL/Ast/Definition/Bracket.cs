using System;
using SqlFormatter.SQL.Ast.Transformer;
using SqlFormatter.SQL.Ast.Visitor;

namespace SqlFormatter.SQL.Ast.Definition
{
    public class Bracket : BaseAstNode
    {
        public bool HasQuery { get; set; }
        public override void Initialize()
        {
            switch (OriginalValue[0])
            {
                case '(':
                    ParentNodeBecome = true;
                    ParentNodeToggleIs = false;
                    break;
                case ')':
                    ParentNodeBecome = false;
                    ParentNodeToggleIs = true;
                    break;
                default:
                    throw new ArgumentException("Bracket以外の値がvalueに設定されています");
            }
        }

        public override void SetParentNode()
        {
            switch (OriginalValue[0])
            {
                case '(':
                    base.SetParentNode();
                    break;
                case ')':
                    SetParentOpenBracket(BeforeNode.ParentNode);
                    break;
            }
        }

        public override void SetParentInChildNode(IAstNode node)
        {
            if (node.GetType() == typeof (ReservedTopLevel))
            {
                // SELECTなどの予約語をもつことからネスト構造のSQLをもつ
                HasQuery = true;
            }
            base.SetParentInChildNode(node);
        }

        private void SetParentOpenBracket(IAstNode node)
        {
            // Statementなど接続ノードはValueが空なのでBracket判定が必要
            if (node.GetType() == typeof(Bracket)
                && node.Value[0] == '(')
            {
                Bracket openNode = (Bracket)node;
                // 自分に対応するOpenかっこをみつけたら終了
                HasQuery = openNode.HasQuery;
                ParentNode = openNode.ParentNode;
                Level = openNode.ParentNode.Level;
                ParentNode.SetParentInChildNode(this);
            }
            else if (node.ParentNode != null) 
            {
                // みつかるまで、親を探す
                SetParentOpenBracket(node.ParentNode);
            }
            // なにもみつからなければ、親はからになる
        }

        public Bracket(IAstNode preNode, string originalValue)
            : base(preNode, originalValue)
        {
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
