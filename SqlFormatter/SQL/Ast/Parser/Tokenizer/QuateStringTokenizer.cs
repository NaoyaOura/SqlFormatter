using System.Text.RegularExpressions;
using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser.Tokenizer
{
    public class QuateStringTokenizer : ITokenizer
    {
        // original
        // ^(((`[^`]*($|`))+)|((\[[^\]]*($|\]))(\][^\]]*($|\]))*)|((""[^""\\]*(?:\\.[^""\\]*)*(""|$))+)|(('[^'\\]*(?:\\.[^'\\]*)*('|$))+))/s
        private readonly Regex _regex = new Regex(@"^(?<target>((""[^""\\]*(?:\\.[^""\\]*)*(""|$))+)|(('[^'\\]*(?:\\.[^'\\]*)*('|$))+)?)\s");
        public IAstNode CreateIAstNode(IAstNode beforeNode, string token)
        {
            // ifは初期判定（処理の高速化）
            if (token[0] == '"' || token[0] == '\'')
            {
                Match match = _regex.Match(token);
                if (match.Success)
                {
                    if (ParseUtils.ShouldAliasNameNode(beforeNode))
                    {
                        return new AliasDefine(beforeNode
                                        , match.Groups["target"].Value
                                        );
                    }
                    // 初期statement判定
                    return new QuateString(beforeNode
                                    , match.Groups["target"].Value
                                    );
                }
            }
            return null;
        }
    }
}