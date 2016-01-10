using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser.Tokenizer
{
    public interface ITokenizer
    {
        IAstNode CreateIAstNode(IAstNode beforeNode, string token);
    }
}