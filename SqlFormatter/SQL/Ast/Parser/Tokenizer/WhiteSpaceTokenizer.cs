using System.Text.RegularExpressions;
using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser.Tokenizer
{
    public class WhiteSpaceTokenizer : ITokenizer
    {
        private readonly Regex _regex = new Regex(@"^\s+");
        public IAstNode CreateIAstNode(IAstNode beforeNode, string token)
        {
            Match match = _regex.Match(token);
            if (match.Success)
            {
                return new WhiteSpace(beforeNode, match.Value);
            }
            return null;
        }
    }
}