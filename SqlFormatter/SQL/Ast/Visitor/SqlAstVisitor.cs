using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Visitor
{
    public class SqlAstVisitor : ISqlAstVisitor
    {
        public virtual string ResultSql { get; set; }
        public virtual void PreVisit() { }
        public virtual void PostVisit() { }

        public virtual bool Visit(AliasDefine node)
        {
            return true;
        }

        public virtual bool Visit(BaseAstNode node)
        {
            return true;
        }

        public virtual bool Visit(Boundaries node)
        {
            return true;
        }

        public virtual bool Visit(Bracket node)
        {
            return true;
        }

        public virtual bool Visit(StatementSeparator node)
        {
            return true;
        }

        public virtual bool Visit(FunctionWord node)
        {
            return true;
        }

        public virtual bool Visit(MultiLineComment node)
        {
            return true;
        }

        public virtual bool Visit(Number node)
        {
            return true;
        }

        public virtual bool Visit(OneLineComment node)
        {
            return true;
        }

        public virtual bool Visit(QuateString node)
        {
            return true;
        }

        public virtual bool Visit(ReservedTopLevel node)
        {
            return true;
        }

        public virtual bool Visit(ReservedWord node)
        {
            return true;
        }

        public virtual bool Visit(Statement node)
        {
            return true;
        }

        public virtual bool Visit(TableOrColumnName node)
        {
            return true;
        }

        public virtual bool Visit(WhiteSpace node)
        {
            return true;
        }

        public virtual bool Visit(EvaluationString node)
        {
            return true;
        }

        public virtual bool Visit(StatementIndent node)
        {
            return true;
        }
    }
}