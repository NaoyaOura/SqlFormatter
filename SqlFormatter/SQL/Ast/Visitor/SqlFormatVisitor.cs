using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using SqlFormatter.Config;
using SqlFormatter.SQL.Ast.Definition;
using SqlFormatter.Tools;

namespace SqlFormatter.SQL.Ast.Visitor
{
    public class SqlFormatVisitor : SqlAstVisitor
    {
        private ConfigEntity _entity;
        /// <summary>
        /// SELECTやFROMなどの予約語のあとに改行しないとき、開始位置となるタブの配置をもつ
        /// </summary>
        private int _invalidDeltaIndent = 0;
        private Stack<int> _LeftIndentSize = new Stack<int>();
        private int _evalutionIndentSize = 0;
        private Stack<string> _Indents = new Stack<string>(); 
        private string _currentLine;
        private readonly TabTool _tabTool;
        public sealed override string ResultSql { get; set; }


        public SqlFormatVisitor(ConfigEntity entity)
        {
            ResultSql = string.Empty;
            _entity = entity;
            _tabTool = new TabTool();
            _Indents.Push(string.Empty);
            _LeftIndentSize.Push(0);
        }

        public override void PreVisit()
        {
            Debug.WriteLine(@"START");
        }

        public override void PostVisit()
        {
            AddNewLineResultSql();
            Debug.WriteLine(@"END");
            Debug.WriteLine(ResultSql);
        }

        public override bool Visit(AliasDefine node)
        {
            if (node.Order == AliasDefine.OrderType.Table)
            {
                _currentLine = _tabTool.Pad(_currentLine, _LeftIndentSize.Peek());
            }
            else if(node.Order == AliasDefine.OrderType.Column)
            {
                if (node.BeforeNode.BeforeNode.OriginalValue.ToUpper().Equals("AS"))
                {
                    // AS区が存在するとき
                    AddResultSql(_entity.BeforeAliasDefineWhiteSpace);
                }
                else if (_entity.IsReservedWordAsComplement)
                {
                    // AS句が存在しないが補完するとき
                    _currentLine = _tabTool.Pad(_currentLine, _LeftIndentSize.Peek());
                    AddResultSql("AS");
                    AddResultSql(_entity.BeforeAliasDefineWhiteSpace);
                }
                else
                {
                    // AS句が存在しなくて、補完もしないとき
                    _currentLine = _tabTool.Pad(_currentLine, _LeftIndentSize.Peek());
                }
            }
            AddResultSql(node.Value);
            return base.Visit(node);
        }

        public override bool Visit(Boundaries node)
        {
            AddResultSql(node.OriginalValue);
            return base.Visit(node);
        }

        public override bool Visit(Bracket node)
        {
            // SQLをもたないかっこはそのまま
            if (!node.HasQuery)
            {
                AddResultSql(node.OriginalValue);
                return base.Visit(node);
            }

            if (node.Value[0] == '(')
            {
                //TODO 外だしする
                Regex regex = new Regex("(?<target>\\t*,?)\\t");
                Match match = regex.Match(_currentLine);
                if (match.Success)
                {
                    // カンマのあとのタブを消す
                    _currentLine = match.Groups["target"].Value;
                }
                AddResultSql(node.Value);
                // +3はPadが切り捨て処理なので切り上げになる
                _Indents.Push(_tabTool.Pad(string.Empty,_currentLine.Length+3));
                AddNewLineResultSql();
            }
            else
            {
                _Indents.Pop();
                _LeftIndentSize.Pop();
                AddNewLineResultSql();
                AddResultSql(node.Value);
            }
            return base.Visit(node);
        }

        /// <summary>
        /// statementがカンマとAND、ORの書き込みを行うため実装なし
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public override bool Visit(StatementSeparator node)
        {
            GetNewLine(_entity.CommaIndentPattern, node.Value); 
            return base.Visit(node);
        }

        public override bool Visit(FunctionWord node)
        {
            AddResultSql(node.Value);
            return base.Visit(node);
        }

        public override bool Visit(MultiLineComment node)
        {
            // ヒント句など、意図的に下げたインデントやスペースを無視してコメントがあるとき
            // もとのコメントを保持したうえで、そのあとに意図的なインデントを再度作成する
            if (_currentLine.Length > 0 
                && string.IsNullOrWhiteSpace(_currentLine)
                // コメント削除状態であれば、すでにnode.Valueが空
                && !string.IsNullOrEmpty(node.Value)
                )
            {
                string tmp = _currentLine;
                _currentLine = string.Empty;
                ResultSql = ResultSql.Remove(ResultSql.Length - _entity.LineSeparator.Length);
                AddResultSql(node.Value);
                AddResultSql(tmp);
            }
            else
            {
                AddResultSql(node.Value);
            }
            return base.Visit(node);
        }

        public override bool Visit(OneLineComment node)
        {
            AddResultSql(node.Value);
            return base.Visit(node);
        }

        public override bool Visit(Number node)
        {
            AddResultSql(node);
            return base.Visit(node);
        }

        public override bool Visit(QuateString node)
        {
            AddResultSql(node.Value);
            return base.Visit(node);
        }

        public override bool Visit(ReservedTopLevel node)
        {
            // FROMやWHEREなどの前には必ず改行を入れる
            _invalidDeltaIndent = 0;
            if (node.ParentNodeToggleIs)
            {
                _LeftIndentSize.Pop();
                AddNewLineResultSql();
            }
            AddResultSql(node.Value);

            if(_entity.TopReservedWordAfterIndent == TopReservedWordIndentType.Invalid)
            {
                _invalidDeltaIndent = node.OriginalValue.Length;
            }
            // 予約語のあとはインデントをひとつ下げる
            _invalidDeltaIndent += 4;

            // indentのタブ(_invalidDeltaIndent)+最大文字列数+切り上げのタブ分(4)
            int max = _invalidDeltaIndent + GetLeftMaxIndent(node.ChildNodes) + 4;
            _LeftIndentSize.Push(_entity.MaxIndenSize > max ? max : _entity.MaxIndenSize);

            _evalutionIndentSize = GetMaxEvaluationSize(node.ChildNodes) + 4;
            return base.Visit(node);
        }

        public override bool Visit(ReservedWord node)
        {
            Regex regex = new Regex("^(AS|DESC|ASC)$", RegexOptions.IgnoreCase);
            Match m = regex.Match(node.OriginalValue);
            if (m.Success)
            {
                _currentLine = _tabTool.Pad(_currentLine, _LeftIndentSize.Peek());
            }

            //TODO CASE式のパターン実装が難しいので、ひとまずべた書き
            if (node.Value.Equals("CASE", StringComparison.CurrentCultureIgnoreCase))
            {
                _Indents.Push(_tabTool.Pad(string.Empty, _currentLine.Length+3));
                AddResultSql(node.Value);
            }
            else if (node.Value.Equals("WHEN" ,StringComparison.CurrentCultureIgnoreCase)
                || node.Value.Equals("THEN",StringComparison.CurrentCultureIgnoreCase)
                || node.Value.Equals("ELSE",StringComparison.CurrentCultureIgnoreCase))
            {
                AddNewLineResultSql();
                AddResultSql("\t");
                AddResultSql(node.Value);
                AddNewLineResultSql();
                AddResultSql("\t\t\t");
            }
            else if (node.Value.Equals("END", StringComparison.CurrentCultureIgnoreCase))
            {
                AddNewLineResultSql();
                AddResultSql(node.Value);
                _Indents.Pop();
            }
            else
            {
                AddResultSql(node.Value);
            }

            return base.Visit(node);
        }

        public override bool Visit(Statement node)
        {
            if (!node.HasStatementSeparator)
            {
                if (_entity.TopReservedWordAfterIndent == TopReservedWordIndentType.Always)
                {
                    AddNewLineResultSql();
                }
                AddResultSql("\t");
            }
            return base.Visit(node);
        }


        public override bool Visit(TableOrColumnName node)
        {
            AddResultSql(node.Value);
            return base.Visit(node);
        }

        public override bool Visit(WhiteSpace node)
        {
            return base.Visit(node);
        }

        public override bool Visit(EvaluationString node)
        {
            _currentLine = _tabTool.Pad(_currentLine, _LeftIndentSize.Peek());
            AddResultSql(_tabTool.Pad(node.Value,_evalutionIndentSize));
            return base.Visit(node);
        }


        private void AddResultSql(IAstNode node)
        {
            //_caseUtil.Convert(node);
            AddResultSql(node.Value);
        }

        private void AddNewLineResultSql()
        {
            if (string.IsNullOrWhiteSpace(_currentLine))
            {
                //現在行が空であれば、空行を増やさない
                return;
            }
            AddResultSql(_entity.LineSeparator);
            AddResultSql(_Indents.Peek());
        }

        private void AddResultSql(string sql)
        {
            int lastIndex = sql.LastIndexOf("\n", StringComparison.Ordinal);
            if (lastIndex < 0)
            {
                _currentLine += sql;
            }
            else
            {
                ResultSql += _currentLine;
                ResultSql += sql.Substring(0, lastIndex + 1);
                _currentLine = sql.Substring(lastIndex + 1);
            }
        }

        private void GetNewLine(IndentPattern ptn, string separator)
        {
            //TODO tabのインデントに揃えた実装
            if (ptn == IndentPattern.Before)
            {
                AddResultSql(" " + separator);
                AddNewLineResultSql();
                AddResultSql(_tabTool.Pad("", _invalidDeltaIndent));
            }
            else //if (ptn == IndentPattern.After)
            {
                AddNewLineResultSql();
                AddResultSql(separator);
                AddResultSql("\t");
            }
        }

        private int GetMaxEvaluationSize(IList<IAstNode> nodes)
        {
            int max = 0;
            foreach (IAstNode node in nodes)
            {
                // ネスト階層があるとき、インデントの最大値の参考にならないため、計算対象外
                if (node.GetType() == typeof(Statement))
                {
                    int currentIndentLength = ((Statement)node).EvaluationValue.Length;
                    if (max < currentIndentLength)
                    {
                        max = currentIndentLength;
                    }
                }
            }
            return max;
        }

        private int GetLeftMaxIndent(IList<IAstNode> nodes)
        {
            int max = 0;
            foreach (IAstNode node in nodes)
            {
                // ネスト階層があるとき、インデントの最大値の参考にならないため、計算対象外
                if (node.GetType() == typeof(Statement)
                    && !((Statement)node).HasNestStatement)
                {
                    int currentIndentLength = ((Statement)node).LeftIndentLength;
                    if (max < currentIndentLength)
                    {
                        max = currentIndentLength;
                    }
                }
            }
            return max;
        }

    }
}