using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Cores;
using Sast.CodeExplorer.Models;
using System.Collections.Generic;

namespace Sast.CodeExplorer.Visitors
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
            if (ParseTreeUtility.IsMatchedContext("typespecifier", node) == true)
            {
                TerminalVisitor typeVisitor = new TerminalVisitor();
                currentType = typeVisitor.Visit(node);
            }
            else if (ParseTreeUtility.IsMatchedContext("declaratorid", node) == true)
            {
                TerminalVisitor typeVisitor = new TerminalVisitor();

                VariableInfoList.Add(new VariableInfo() 
                { 
                    TypeName = currentType, 
                    Name = typeVisitor.Visit(node)
                });
            }

            return base.VisitChildren(node);
        }
    }
}
