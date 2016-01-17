using SqlFormatter.Config;
using SqlFormatter.SQL.Ast.Definition;
using SqlFormatter.Tools;

namespace SqlFormatter.SQL.Ast.Transformer
{
    public class CaseTransform : BaseTransform
    {
        private readonly ConfigEntity _entity;
        public CaseTransform(ConfigEntity entity)
        {
            _entity = entity;
        }

        public override bool Transform(AliasDefine node)
        {
            node.Value = CaseFormatUtils.Convert(_entity.AliasNameCase, node.Value);
            return base.Transform(node);
        }

        public override bool Transform(ReservedWord node)
        {
            node.Value = CaseFormatUtils.Convert(_entity.ReservedWordCase, node.Value);
            return base.Transform(node);
        }

        public override bool Transform(ReservedTopLevel node)
        {
            node.Value = CaseFormatUtils.Convert(_entity.TopReservedWordCase, node.Value);
            return base.Transform(node);
        }

        public override bool Transform(TableOrColumnName node)
        {
            if (node.Order == TableOrColumnName.OrderType.Table)
            {
                node.Value = CaseFormatUtils.Convert(_entity.ColumnNameCase, node.Value);
            }
            else if (node.Order == TableOrColumnName.OrderType.Column)
            {
                node.Value = CaseFormatUtils.Convert(_entity.TableNameCase, node.Value);
            }
            return base.Transform(node);
        }

        public override bool Transform(Statement node)
        {
            node.Value = CaseFormatUtils.Convert(_entity.StatementSeparatorCase, node.Value);
            return base.Transform(node);
        }

    }
}