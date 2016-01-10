using System.Text.RegularExpressions;
using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser.Tokenizer
{
    /// <summary>
    /// TODO 未実装
    /// </summary>
    public class UserDefinedVariableTokenizer : ITokenizer
    {
        private readonly Regex _regex = new Regex(@"^(@|:)[A-z0-9\._\$]+");
        public IAstNode CreateIAstNode(IAstNode beforeNode, string token)
        {
            if ((token[0] == '@' || token[0] == ':') && token.Length > 1)
            {
                // If the variable name is quoted
                if (token[1] == '"' || token[1] == '\'')
                {
                    //_regex r2 = new _regex(@"^(((""[^""\\]*(?:\\.[^""\\]*)*(""|$))+)|(('[^'\\]*(?:\\.[^'\\]*)*('|$))+))\s");
                    //TODO Valiable Node
                    //return new ASTNode(   TokenType.VARIABLE
                    //                ,   token[0] + r2.Match(token.Substring(1)).OriginalValue);
                }
                else
                {
                    Match match = _regex.Match(token);
                    if (match.Success)
                    {
                        //TODO ValiableNode
                        //return new ASTNode(   TokenType.VARIABLE
                        //                ,   m3.OriginalValue
                        //                );
                    }
                }
            }
            return null;
        }
    }
}