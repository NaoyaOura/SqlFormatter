using System;
using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser.Tokenizer
{
    class OneLineCommentTokenizer : ITokenizer
    {
        public IAstNode CreateIAstNode(IAstNode beforeNode, string token)
        {
            if (token[0] == '#' || (token.Length > 1 && (token[0] == '-' && token[1] == '-')))
            {
                // oneline comment
                int endIndex = token.IndexOf("\n", StringComparison.Ordinal);
                return new OneLineComment(beforeNode
                                , endIndex > 0 ? token.Substring(0, endIndex + "\n".Length) : token
                                );
            }
            return null;
        }
    }
}
