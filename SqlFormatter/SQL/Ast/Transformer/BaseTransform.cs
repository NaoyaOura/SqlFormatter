using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Transformer
{
    public class BaseTransform : ITransformer
    {
        public virtual bool Transform(IAstNode node)
        {
            return true;
        }

        public virtual bool Transform(AliasDefine node)
        {
            return true;
        }

        public virtual bool Transform(BaseAstNode node)
        {
            return true;
        }

        public virtual bool Transform(Boundaries node)
        {
            return true;
        }

        public virtual bool Transform(Bracket node)
        {
            return true;
        }

        public virtual bool Transform(StatementSeparator node)
        {
            return true;
        }

        public virtual bool Transform(FunctionWord node)
        {
            return true;
        }

        public virtual bool Transform(Number node)
        {
            return true;
        }

        public virtual bool Transform(MultiLineComment node)
        {
            return true;
        }

        public virtual bool Transform(OneLineComment node)
        {
            return true;
        }

        public virtual bool Transform(QuateString node)
        {
            return true;
        }

        public virtual bool Transform(ReservedTopLevel node)
        {
            return true;
        }

        public virtual bool Transform(ReservedWord node)
        {
            return true;
        }

        public virtual bool Transform(Statement node)
        {
            return true;
        }

        public virtual bool Transform(TableOrColumnName node)
        {
            return true;
        }

        public virtual bool Transform(WhiteSpace node)
        {
            return true;
        }

        public virtual bool Transform(EvaluationString node)
        {
            return true;
        }
    }
}