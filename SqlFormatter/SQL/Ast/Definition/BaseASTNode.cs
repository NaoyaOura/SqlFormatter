using System;
using System.Collections.Generic;
using SqlFormatter.SQL.Ast.Transformer;
using SqlFormatter.SQL.Ast.Visitor;

namespace SqlFormatter.SQL.Ast.Definition
{
    //public enum TokenType
    //{
    //    WHITESPACE, WORD, QUOTE_STRING, RESERVED,
    //    RESERVED_TOPLEVEL, RESERVED_NEWLINE, BOUNDARY, COMMENT,
    //    BLOCK_COMMENT, NUMBER, ERROR, VARIABLE, ALIAS_WITH_COLUMN,
    //    TABLE_OR_COLUMN,ALIAS_DEFINE,UNKNOWN
    //};

    public class BaseAstNode : IAstNode
    {
        public String OriginalValue { get; set; }
        public String Value { get; set; }
        public IAstNode BeforeNode { get; set; }
        public IAstNode AfterNode { get; set; }
        public int StartPosition { get; set; }
        public int StartLineNo { get; set; }
        public IAstNode ParentNode { get; set; }
        public List<IAstNode> ChildNodes { get; set; }
        public String ReservedToplevel { get; set; }
        public int Level { get; set; }

        /// <summary>
        /// 親ノードとなるか
        /// </summary>
        public bool ParentNodeBecome { get; set; }

        /// <summary>
        /// 親ノードを切り替えるか
        /// </summary>
        public bool ParentNodeToggleIs { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// 
        /// 初回のみ呼び出しされるコンストラクタ
        /// </summary>
        public BaseAstNode()
        {
            OriginalValue = string.Empty;
            StartLineNo = 1;
            StartPosition = 1;
            ParentNodeBecome = false;
            ParentNodeToggleIs = false;
            Level = 0;
        }

        /// <summary>
        /// コンストラクタ.
        /// 
        /// </summary>
        /// <param name="beforeNode"></param>
        /// <param name="originalValue"></param>
        public BaseAstNode(IAstNode beforeNode, String originalValue)
        {
            BeforeNode = beforeNode;
            BeforeNode.AfterNode = this;
            OriginalValue = originalValue;
            Value = OriginalValue;
            // ReSharper disable once VirtualMemberCallInContructor
            Initialize();
            StartPosition = beforeNode.StartPosition + beforeNode.OriginalValue.Length;
            StartLineNo = beforeNode.StartLineNo + (
                                    beforeNode.OriginalValue.Length - beforeNode.OriginalValue.Replace("\n", "").Length
                                    );
            // ReSharper disable once VirtualMemberCallInContructor
            SetParentNode();
        }

        public virtual void Initialize(){ }

        public virtual void SetParentNode()
        {
            // CloseBracket")"やカンマ、FROM句やWHERE句など直前の値より
            // 親ノードのレベルが上に切り替わるとき
            if (ParentNodeToggleIs)
            {
                if (ParentNodeBecome && BeforeNode.ParentNode != null && BeforeNode.ParentNode.ParentNode != null)
                {
                    // FROM句やWhere句のように直前の値より親ノードより高いとき（Statementから脱出するとき）
                    Level = BeforeNode.Level - 1;
                    ParentNode = BeforeNode.ParentNode.ParentNode.ParentNode;
                }
                else if (BeforeNode.ParentNode != null)
                {
                    // CloseBracket")"やカンマのように直前の値の親ノードと同列のとき
                    Level = BeforeNode.Level - 1;
                    ParentNode = BeforeNode.ParentNode.ParentNode;
                }
                else
                {
                    //文頭のMERGEやUPDATEなど親になり、階層も下がるが親ノードが存在しないとき
                    ParentNode = BeforeNode.ParentNode;
                    Level = BeforeNode.Level;
                }
            }
            else if (BeforeNode.ParentNodeBecome)
            {
                // OpenBracket"("、SELECTやFROMなど前のノードが親のとき
                ParentNode = BeforeNode;
                Level = BeforeNode.Level + 1;
            }
            // 他（エイリアスやカラムなど通常のカラム定義などほとんどがこれにあたる）
            else
            {
                ParentNode = BeforeNode.ParentNode;
                Level = BeforeNode.Level;
            }

            if (ParentNode != null)
            {
                ParentNode.SetParentInChildNode(this);
            }
        }

        public virtual void SetParentInChildNode(IAstNode node)
        {
            if (ChildNodes == null)
            {
                ChildNodes = new List<IAstNode>();
            }
            ChildNodes.Add(node);
        }

        public virtual bool Accept(ISqlAstVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public virtual bool Transform(ITransformer tranformer)
        {
            return tranformer.Transform(this);
        }

        public void CreateNewStatement()
        {
            // 一つ前がSelectやFromなどの宣言のとき
            // Selectであればエイリアスのつく一つ一つの取得カラムを取りまとめる単位
            // Fromであれば、テーブル宣言ひとつひとつの単位を取りまとめる単位
            // となるStatementオブジェクトを生成する
            Statement node = new Statement(BeforeNode, string.Empty, ParentNodeToggleIs);
            ParentNode = node;
            Level = node.Level + 1;
            node.SetParentInChildNode(this);
        }
    }
}
