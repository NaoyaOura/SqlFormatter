
using SqlFormatter.SQL.Ast.Transformer;
using SqlFormatter.SQL.Ast.Visitor;

namespace SqlFormatter.SQL.Ast.Definition
{
    public class StatementIndent : BaseAstNode
    {
        public new Statement ParentNode { get; set; }
        public override void Initialize()
        {
            ParentNodeBecome = false;
            ParentNodeToggleIs = false;
        }

        public StatementIndent(IAstNode node)
        {
            BeforeNode = node.BeforeNode;
            AfterNode = node;
            node.BeforeNode = this;
            ParentNode = (Statement)node.ParentNode;
        }

        /// <summary>
        /// コンストラクタで親ノードは設定済み
        /// </summary>
        public override void SetParentNode()
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
