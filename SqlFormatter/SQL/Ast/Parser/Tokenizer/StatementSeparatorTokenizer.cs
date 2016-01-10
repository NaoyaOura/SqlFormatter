using System.Text.RegularExpressions;
using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser.Tokenizer
{
    class StatementSeparatorTokenizer : ITokenizer
    {
        private readonly Regex _regex = new Regex("^(?<target>,|AND|OR?)($|\\s|" + ReservedWords.RegexBoundaries + ")");
        public IAstNode CreateIAstNode(IAstNode beforeNode, string token)
        {
            Match match = _regex.Match(token);
            if (match.Success)
            {
                return new StatementSeparator(beforeNode, match.Groups["target"].Value);
            }
            return null;
        }
    }
}
