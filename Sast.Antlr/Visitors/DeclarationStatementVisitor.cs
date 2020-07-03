﻿using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.Antlr.Models;
using System.Collections.Generic;
using static Sast.Antlr.Grammars.CPP14Parser;

namespace Sast.Analyzer.Antrl.Visitors
{
    public class DeclarationStatementVisitor : AbstractParseTreeVisitor<bool>
    {
        private string currentType;

        public DeclarationStatementVisitor()
        {
        }

        public List<VariableInfo> VariableInfoList
        {
            get;
        } = new List<VariableInfo>();

        public override bool VisitChildren([NotNull] IRuleNode node)
        {
            if (node is TypespecifierContext typespecifierContext)
            {
                TerminalVisitor typeVisitor = new TerminalVisitor();
                currentType = typeVisitor.Visit(typespecifierContext);
            }
            else if (node is DeclaratoridContext declaratoridContext)
            {
                TerminalVisitor typeVisitor = new TerminalVisitor();

                VariableInfoList.Add(new VariableInfo() 
                { 
                    TypeName = currentType, 
                    Name = typeVisitor.Visit(declaratoridContext)
                });
            }

            return base.VisitChildren(node);
        }
    }
}
