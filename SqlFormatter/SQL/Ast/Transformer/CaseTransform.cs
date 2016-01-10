using System;
using SqlFormatter.Config;
using SqlFormatter.SQL.Ast.Definition;

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
            ConvertCaseType(_entity.AliasNameCase, node);
            return base.Transform(node);
        }

        public override bool Transform(ReservedWord node)
        {
            ConvertCaseType(_entity.ReservedWordCase, node);
            return base.Transform(node);
        }

        public override bool Transform(ReservedTopLevel node)
        {
            ConvertCaseType(_entity.TopReservedWordCase, node);
            return base.Transform(node);
        }

        public override bool Transform(TableOrColumnName node)
        {
            if (node.Order == TableOrColumnName.OrderType.Table)
            {
                ConvertCaseType(_entity.ColumnNameCase, node);
            }
            else if (node.Order == TableOrColumnName.OrderType.Column)
            {
                ConvertCaseType(_entity.TableNameCase, node);
            }
            return base.Transform(node);
        }

        public override bool Transform(Statement node)
        {
            ConvertCaseType(_entity.StatementSeparatorCase, node);
            return base.Transform(node);
        }
        private void ConvertCaseType(CaseType type, IAstNode node)
        {
            string aliasStr = string.Empty;
            string value = node.Value;
            int aliasIdx = node.Value.LastIndexOf(".", StringComparison.Ordinal);
            if (aliasIdx >= 0)
            {
                aliasStr = node.Value.Substring(0, aliasIdx+1);
                value = node.Value.Substring(aliasIdx + 1);
            }
            switch (type)
            {
                case CaseType.LowerCase:
                    node.Value = aliasStr + value.ToLower();
                    return;
                case CaseType.UpperCase:
                    node.Value = aliasStr + value.ToUpper();
                    return ;
                case CaseType.IniCap:
                    node.Value = aliasStr + value[0].ToString().ToUpper() + value.Substring(1).ToLower();
                    return ;
                default:
                    return ;
            }
        }
    }
}