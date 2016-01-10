using System.Text.RegularExpressions;
using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser.Tokenizer
{
    public class BoundarieTokenizer : ITokenizer
    {
        private readonly Regex _regex = new Regex("^" + ReservedWords.RegexBoundaries);
        public IAstNode CreateIAstNode(IAstNode beforeNode, string token)
        {
            Match match = _regex.Match(token);
            if (match.Success)
            {
                return new Boundaries(beforeNode, match.Value);
            }
            return null;
        }
    }
}