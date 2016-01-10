using System;
using System.Text.RegularExpressions;
using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser.Tokenizer
{
    public class TableOrColumnNameTokenizer : ITokenizer
    {
        private readonly Regex _regex = new Regex(@"^[A-z0-9_\$]+(\.[A-z0-9_\$\*]+)?");
        public IAstNode CreateIAstNode(IAstNode beforeNode, string token)
        {
            Match match = _regex.Match(token);
            if (match.Success)
            {
                string value = match.Value;
                if (value.IndexOf(".", StringComparison.Ordinal) < 0
                    && ParseUtils.ShouldAliasNameNode(beforeNode))
                {
                    return new AliasDefine(beforeNode
                                    , value
                                    );
                }
                return new TableOrColumnName(beforeNode, value);
            }
            return null;
        }
    }
}