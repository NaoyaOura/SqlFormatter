using System.Text.RegularExpressions;
using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser.Tokenizer
{
    public class NumberTokenizer : ITokenizer
    {
        private readonly Regex _regex = new Regex(@"^([0-9]+(\.[0-9]+)?|0x[0-9a-fA-F]+|0b[01]+)");
        public IAstNode CreateIAstNode(IAstNode beforeNode, string token)
        {
            Match match = _regex.Match(token);
            if (match.Success)
            {
                return new Number(beforeNode, match.Value);
            }
            return null;
        }
    }
}