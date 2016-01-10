using SqlFormatter.SQL.Ast.Transformer;
using SqlFormatter.SQL.Ast.Visitor;

namespace SqlFormatter.SQL.Ast.Definition
{
    public class MultiLineComment : BaseAstNode
    {
        public override void Initialize()
        {
            ParentNodeBecome = false;
        }

        //private static Reg
        public MultiLineComment(IAstNode preNode, string originalValue)
            : base(preNode, originalValue)
        {
        }

        public override void SetParentNode()
        {
            if (BeforeNode.GetType() == typeof(ReservedTopLevel))
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
