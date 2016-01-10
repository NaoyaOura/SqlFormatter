using SqlFormatter.SQL.Ast.Transformer;
using SqlFormatter.SQL.Ast.Visitor;

namespace SqlFormatter.SQL.Ast.Definition
{
    /// <summary>
    /// 評価記号
    /// example)
    ///     =,!=,>,<,LIKE,BETWEEN
    /// </summary>
    public class EvaluationString : BaseAstNode
    {
        public EvaluationString(IAstNode beforeNode, string value)
            : base(beforeNode, value)
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
