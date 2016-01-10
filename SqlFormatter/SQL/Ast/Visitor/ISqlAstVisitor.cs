using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Visitor
{
    public interface ISqlAstVisitor
    {
        string ResultSql { get;}
        void PreVisit();
        void PostVisit();
        bool Visit(AliasDefine node);
        bool Visit(BaseAstNode node);
        bool Visit(Boundaries node);
        bool Visit(Bracket node);
        bool Visit(StatementSeparator node);
        bool Visit(FunctionWord node);
        bool Visit(MultiLineComment node);
        bool Visit(Number node);
        bool Visit(OneLineComment node);
        bool Visit(QuateString node);
        bool Visit(ReservedTopLevel node);
        bool Visit(ReservedWord node);
        bool Visit(Statement node);
        bool Visit(TableOrColumnName node);
        bool Visit(WhiteSpace node);
        bool Visit(EvaluationString node);
    }
}
