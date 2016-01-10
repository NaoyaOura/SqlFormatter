using System.Text.RegularExpressions;
using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser.Tokenizer
{
    class ReservedWordTokenizer : ITokenizer
    {
        private readonly Regex _regex = new Regex(
                                    "^(?<target>" + ReservedWords.RegexReserved + "?)($|\\s|" + ReservedWords.Boundaries + ")"
                                    , RegexOptions.IgnoreCase);
        public IAstNode CreateIAstNode(IAstNode beforeNode, string token)
        {
            Match match = _regex.Match(token);
            if (match.Success)
            {
                return new ReservedWord(beforeNode, match.Groups["target"].Value);
            }
            return null;
        }
    }
}
