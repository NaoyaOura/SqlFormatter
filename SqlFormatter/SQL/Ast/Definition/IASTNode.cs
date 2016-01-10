using System;
using System.Collections.Generic;
using SqlFormatter.SQL.Ast.Transformer;
using SqlFormatter.SQL.Ast.Visitor;

namespace SqlFormatter.SQL.Ast.Definition
{
    public interface IAstNode
    {
        String OriginalValue { get; }
        String Value { get; set; }
        IAstNode BeforeNode { get; }
        IAstNode AfterNode { get; set; }
        int StartPosition { get; }
        int StartLineNo { get; }
        IAstNode ParentNode { get; }
        List<IAstNode> ChildNodes { get; }
        String ReservedToplevel { get; }
        bool ParentNodeBecome { get; }
        bool ParentNodeToggleIs { get; set; }
        int Level { get; set; }
        void Initialize();
        void SetParentNode();
        void SetParentInChildNode(IAstNode node);
        bool Accept(ISqlAstVisitor visitor);
        bool Transform(ITransformer tranformer);
    }
}
