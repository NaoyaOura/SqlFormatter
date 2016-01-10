using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Parser
{
    public static class ParseUtils
    {

        public static bool ShouldAliasNameNode(IAstNode beforeNode)
        {
            // エイリアス定義の直前は必ずスペースかタブか改行
            if (!(beforeNode.GetType() == typeof(WhiteSpace)))
            {
                return false;
            }

            // beforeはWhiteSpaceなので、beforeのbeforeを参照
            IAstNode node = beforeNode.BeforeNode;
            if (node.OriginalValue.ToUpper().Equals("AS")
                || node.GetType() == typeof(TableOrColumnName)
                || node.GetType() == typeof(Number)
                || node.GetType() == typeof(QuateString)
                // ROWNUMなどの予約語の後にエイリアス定義が行われる場合
                || node.GetType() == typeof(ReservedWord)
                || (node.GetType() == typeof(Bracket) && node.Value[0]==')')
                )
            {
                return true;
            }
            return false;
        } 
    }
}