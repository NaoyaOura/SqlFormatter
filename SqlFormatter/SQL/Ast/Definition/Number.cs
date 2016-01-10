using SqlFormatter.SQL.Ast.Transformer;
using SqlFormatter.SQL.Ast.Visitor;

namespace SqlFormatter.SQL.Ast.Definition
{
    public class Number : BaseAstNode
    {
        public override void Initialize()
        {
        }
        
        public Number(IAstNode beforeNode, string originalValue)
            : base(beforeNode, originalValue)
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
