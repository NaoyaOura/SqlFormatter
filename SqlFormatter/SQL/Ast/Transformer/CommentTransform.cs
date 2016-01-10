using System;
using System.Text;
using SqlFormatter.SQL.Ast.Definition;

namespace SqlFormatter.SQL.Ast.Transformer
{
    public class CommentTransform : BaseTransform
    {
        private readonly bool _deleteComment;
        public CommentTransform(bool deleteComment)
        {
            _deleteComment = deleteComment;
        }

        public override bool Transform(MultiLineComment node)
        {
            node.Value = TransformComment(node);
            return base.Transform(node);
        }

        public override bool Transform(OneLineComment node)
        {
            node.Value = TransformComment(node);
            return base.Transform(node);
        }

        /// <summary>
        /// コメントのあとの意図的なスペースをコメントにくっつける
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        //public override bool Transform(WhiteSpace node)
        //{
        //    if (node.BeforeNode.GetType() == typeof (MultiLineComment))
        //    {
        //        if (!_deleteComment)
        //        {
        //            node.BeforeNode.Value += node.OriginalValue;
        //        }
        //    }
        //    return base.Transform(node);
        //}

        private string TransformComment(MultiLineComment node)
        {
            if (_deleteComment)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            if (node.BeforeNode.GetType() == typeof (WhiteSpace))
            {
                // コメントの前の意図的なインデントや空白を残す
                sb.Append(node.BeforeNode.Value);
            }
            sb.Append(node.Value);
            if (node.AfterNode.GetType() == typeof (WhiteSpace))
            {
                string value = node.AfterNode.Value;
                int lineSeparateIdx = value.IndexOf("\n", StringComparison.Ordinal);
                if (lineSeparateIdx>= 0)
                {
                    // 改行以降は意図的なものがほとんど考えられないため対象外
                    value = value.Substring(0, lineSeparateIdx+1);
                }
                sb.Append(value);
            }
            return sb.ToString();
        }

        private string TransformComment(OneLineComment node)
        {
            if (_deleteComment)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            if (node.BeforeNode.GetType() == typeof (WhiteSpace))
            {
                // コメントの前の意図的なインデントや空白を残す
                sb.Append(node.BeforeNode.Value);
            }
            sb.Append(node.Value);
            return sb.ToString();
        }
    }
}