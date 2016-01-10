using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Transformer
{
    public interface ITransformer
    {
        bool Transform(IAstNode node);
        bool Transform(AliasDefine node);
        bool Transform(BaseAstNode node);
        bool Transform(Boundaries node);
        bool Transform(Bracket node);
        bool Transform(StatementSeparator node);
        bool Transform(FunctionWord node);
        bool Transform(MultiLineComment node);
        bool Transform(Number node);
        bool Transform(OneLineComment node);
        bool Transform(QuateString node);
        bool Transform(ReservedTopLevel node);
        bool Transform(ReservedWord node);
        bool Transform(Statement node);
        bool Transform(TableOrColumnName node);
        bool Transform(WhiteSpace node);
        bool Transform(EvaluationString node);
    }
}
