using System.Collections.Generic;
using System.Diagnostics;
using SqlFormatter.SQL.Ast.Definition;
using SqlFormatter.SQL.Ast.Transformer;
using SqlFormatter.SQL.Ast.Visitor;

namespace SqlFormatter.SQL.Ast
{
    public class SqlCompilationUnit
    {
        private readonly IList<IAstNode> _compilationUnitList;
        public SqlCompilationUnit(IList<IAstNode> unit)
        {
            _compilationUnitList = unit;
        }

        public void Accept(SqlAstVisitor visitor, IList<ITransformer> tranformers)
        {
            visitor.PreVisit();
            foreach (IAstNode node in _compilationUnitList)
            {
                // 開始地点は親が存在しないもののみ
                if (node.ParentNode == null)
                {
                    Debug.WriteLine("[IN]");
                    Accept(visitor, tranformers, node);
                }
            }
            visitor.PostVisit();
        }

        private void Accept(SqlAstVisitor visitor, IList<ITransformer> tranformers, IAstNode parent)
        {
            Debug.WriteLine(parent.Level+"\t"+parent.ParentNode + "\t" + parent +"\t" + parent.OriginalValue);

            foreach (ITransformer transformer in tranformers)
            {
                parent.Transform(transformer);
            }
            parent.Accept(visitor);

            IList<IAstNode> childs = parent.ChildNodes;
            if (childs == null)
            {
                return;
            }

            foreach(IAstNode child in childs)
            {
                Accept(visitor, tranformers, child);
            }
        }
    }
}
