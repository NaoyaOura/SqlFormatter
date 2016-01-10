
using SqlFormatter.SQL.Ast.Transformer;
using SqlFormatter.SQL.Ast.Visitor;

namespace SqlFormatter.SQL.Ast.Definition
{
    public class FunctionWord :BaseAstNode
    {
        public override void Initialize()
        {
            ParentNodeBecome = true;
        }

        public FunctionWord(IAstNode preNode, string originalValue)
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
