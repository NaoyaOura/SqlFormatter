using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SqlFormatter.SQL.Ast.Definition;
using SqlFormatter.SQL.Ast.Parser.Tokenizer;

namespace SqlFormatter.SQL.Ast.Parser
{
    public class SqlAstParser
    {
        private readonly IList<ITokenizer> _tokenizers = new List<ITokenizer>();

        public SqlCompilationUnit Parse(String sqlText)
        {
            Initialize();
            List<IAstNode> tokens = Tokenize(sqlText);
            return new SqlCompilationUnit(tokens);
        }

        private void Initialize()
        {
            if (_tokenizers != null)
            {
                // スペースやコメントは解析のノイズになるため、最初に取り除く
                _tokenizers.Add(new WhiteSpaceTokenizer());
                _tokenizers.Add(new OneLineCommentTokenizer());
                _tokenizers.Add(new MultiLineCommentTokenizer());
                // 文字列や数値などリテラル
                _tokenizers.Add(new QuateStringTokenizer());
                _tokenizers.Add(new UserDefinedVariableTokenizer());
                _tokenizers.Add(new NumberTokenizer());
                // Boundarieに含まれるオペレータもFormat解析上処理が異なるものは別ものとして解析する
                _tokenizers.Add(new BracketTokenizer());
                _tokenizers.Add(new StatementSeparatorTokenizer());
                _tokenizers.Add(new EvaluationStringTokenizer());
                _tokenizers.Add(new BoundarieTokenizer());
                // 予約語を解析する
                _tokenizers.Add(new ReservedTopLevelTokenizer());
                _tokenizers.Add(new ReservedWordTokenizer());
                _tokenizers.Add(new FunctionTokenizer());
                // ユーザーによって作成されたテーブル定義を解析する
                _tokenizers.Add(new TableOrColumnNameTokenizer());
            }
        }

        private List<IAstNode> Tokenize(string str)
        {
            List<IAstNode> tokens = new List<IAstNode>();

            // Used to make sure the string keeps shrinking on each iteration
            int oldStringLen = str.Length + 1;
            int currentLength = str.Length;

            IAstNode preToken = new BaseAstNode();

            // Keep processing the string until it is empty
            while (currentLength > 0)
            {
                if (oldStringLen <= currentLength)
                {
                    // If the string stopped shrinking, there was a problem
                    MessageBox.Show( @"SQL Parseエラーが発生しました。" + Environment.NewLine
                                    + @"入力SQLとともに管理者に問い合わせください。"
                                     ,   @"重大なエラー [Line:" +preToken.StartLineNo + @"]"
                                     , MessageBoxButtons.OK
                                     , MessageBoxIcon.Error);
                    return tokens;
                }

                oldStringLen = currentLength;

                IAstNode token = GetNextToken(str, preToken);
                tokens.Add(token);

                int tokenStrLength = token.OriginalValue.Length;
                str = str.Substring(tokenStrLength);
                currentLength -= tokenStrLength;

                preToken = token;
            }
            tokens.Add(new BaseAstNode(preToken, string.Empty));
            return tokens;
        }

        private IAstNode GetNextToken(string token, IAstNode beforeNode)
        {
            foreach (ITokenizer tokenizer in _tokenizers)
            {
                IAstNode node = tokenizer.CreateIAstNode(beforeNode, token);
                if (node != null)
                {
                    // nullでないとき、Tokenizerの条件と一致している
                    return node;
                }
            }
            return new BaseAstNode(beforeNode,string.Empty);
        }
    }
}
