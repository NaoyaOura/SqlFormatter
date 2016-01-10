using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser.Tokenizer
{
    class BracketTokenizer : ITokenizer
    {
        public IAstNode CreateIAstNode(IAstNode beforeNode, string token)
        {
            if (token[0] == '(' || token[0] == ')')
            {
                return new Bracket(beforeNode, token[0].ToString());
            }
            return null;
        }
    }
}
