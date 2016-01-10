using SqlFormatter.SQL.Ast.Transformer;
using SqlFormatter.SQL.Ast.Visitor;

namespace SqlFormatter.SQL.Ast.Definition
{
    /// <summary>
    /// カンマとAND、ORなど定義を分割する文字列
    /// </summary>
    public class StatementSeparator : BaseAstNode
    {
        public override void Initialize()
        {
            ParentNodeBecome = false;
            ParentNodeToggleIs = true;
        }

        public StatementSeparator(IAstNode beforeNode, string originalValue)
            : base(beforeNode, originalValue)
        {
        }

        public override void SetParentNode()
        {
            if (BeforeNode.ParentNode.GetType() == typeof(Statement)
                || BeforeNode.ParentNode.GetType() == typeof(ReservedTopLevel))
            {
                CreateNewStatement();
            }
            else
            {
                base.SetParentNode();
            }
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
