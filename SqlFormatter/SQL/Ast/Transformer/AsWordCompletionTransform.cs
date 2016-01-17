
using SqlFormatter.Config;
using SqlFormatter.SQL.Ast.Definition;
using SqlFormatter.Tools;

namespace SqlFormatter.SQL.Ast.Transformer
{
    /// <summary>
    /// AS句を補完するための変換クラス
    /// </summary>
    class AsWordCompletionTransform : BaseTransform
    {
        private readonly ConfigEntity _entity;
        public AsWordCompletionTransform(ConfigEntity entity)
        {
            _entity = entity;
        }

        public override bool Transform(AliasDefine node)
        {
            if (node.Order == AliasDefine.OrderType.Column)
            {
                string tmpVal = node.Value;
                node.Value = CaseFormatUtils.Convert(_entity.ReservedWordCase, "AS");
                node.Value += _entity.BeforeAliasDefineWhiteSpace;
                node.Value += tmpVal;
            }
            return base.Transform(node);
        }

        public override bool Transform(ReservedWord node)
        {
            if (node.OriginalValue.ToUpper() == "AS")
            {
                node.Value = string.Empty;
            }
            return base.Transform(node);
        }
    }
}
