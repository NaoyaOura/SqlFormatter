using System;
using System.Text.RegularExpressions;
using SqlFormatter.SQL.Ast.Transformer;
using SqlFormatter.SQL.Ast.Visitor;

namespace SqlFormatter.SQL.Ast.Definition
{
    public class TableOrColumnName : BaseAstNode
    {
        //TODO 外側のファイルに切り離す
        private readonly Regex _regex = new Regex("^(FROM|MERGE|INSERT|UPDATE)$",RegexOptions.IgnoreCase);
        public enum OrderType
        {
            Table, Column, Unknown
        }
        public OrderType Order { get; set; }

        public override void Initialize()
        {
            ParentNodeBecome = false;
            ParentNodeToggleIs = false;
        }

        public TableOrColumnName(IAstNode preNode, string originalValue)
            : base(preNode, originalValue)
        {
            // SQLが成立していないとき
            if (ParentNode == null || ParentNode.ParentNode == null)
            {
                Order = OrderType.Unknown;
                throw new Exception("SQLが成立していません");
            }

            // 定義の親がStatementでその親が予約語
            if (ParentNode.ParentNode.GetType() == typeof (ReservedTopLevel))
            {
                string reservedWord = ParentNode.ParentNode.OriginalValue;
                Match m = _regex.Match(reservedWord);
                if (m.Success)
                {
                    // FROMやUPDATEなど、カラム名称が定義されない予約語ならテーブル名
                    Order = OrderType.Table;
                }
                else
                {
                    // SELECT句やWHERE区ででてきたカラム定義
                    Order = OrderType.Column;
                }
            }
            else
            {
                // JOIN句など、予約語とは違うネスト階層により出現する定義
                Order = OrderType.Column;
            }
        }

        public override bool Accept(ISqlAstVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public override bool Transform(ITransformer transformer)
        {
            return transformer.Transform(this);
        }
    }
}
