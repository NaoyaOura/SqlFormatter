using System.Text.RegularExpressions;
using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser.Tokenizer
{
    class EvaluationStringTokenizer : ITokenizer
    {
        private readonly Regex _regex = new Regex("^" + ReservedWords.RegexEvalutions);
        public IAstNode CreateIAstNode(IAstNode beforeNode, string token)
        {
            Match match = _regex.Match(token);
            if (match.Success)
            {
                return new EvaluationString(beforeNode,match.Value);
            }
            return null;
        }
    }
}
