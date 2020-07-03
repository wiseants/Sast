using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.Antlr.Models;
using System.Collections.Generic;
using static Sast.Antlr.Grammars.CPP14Parser;

namespace Sast.Analyzer.Antrl.Visitors
{
    public class DeclarationVisitor : AbstractParseTreeVisitor<bool>
    {
        public DeclarationVisitor()
        {

        }

        public List<VariableInfo> VariableInfoList
        {
            get;
        } = new List<VariableInfo>();

        public override bool VisitChildren([NotNull] IRuleNode node)
        {
            if (node is DeclarationstatementContext declarationstatementContext)
            {
                DeclarationStatementVisitor declarationStatementVisitor = new DeclarationStatementVisitor();
                declarationStatementVisitor.Visit(declarationstatementContext);

                VariableInfoList.AddRange(declarationStatementVisitor.VariableInfoList);
            }

            return base.VisitChildren(node);
        }
    }
}
