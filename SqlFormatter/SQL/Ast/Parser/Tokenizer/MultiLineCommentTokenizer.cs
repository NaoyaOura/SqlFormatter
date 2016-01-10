using System;
using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser.Tokenizer
{
    public class MultiLineCommentTokenizer : ITokenizer
    {
        public IAstNode CreateIAstNode(IAstNode beforeNode, string token)
        {
            if (token.Length > 1 && (token[0] == '/' && token[1] == '*'))
            {
                int endIndex = token.IndexOf("*/", StringComparison.Ordinal);
                return new MultiLineComment(beforeNode
                                , endIndex > 0 ? token.Substring(0, endIndex + "*/".Length) : token
                                );
            }
            return null;
        }
    }
}