using System.Text.RegularExpressions;
using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser.Tokenizer
{
    public class FunctionTokenizer : ITokenizer
    {
        // A function must be suceeded by '('
        // this makes it so "count(" is considered a function, but "count" alone is not
        private readonly Regex _regex = new Regex("^(?<target>" + ReservedWords.RegexFunction + "?)([(]|\\s|[)])"
                        , RegexOptions.IgnoreCase);
        public IAstNode CreateIAstNode(IAstNode beforeNode, string token)
        {
            Match match = _regex.Match(token);
            if (match.Success)
            {
                return new FunctionWord(beforeNode, match.Groups["target"].Value);
            }
            return null;
        }
    }
}