using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.Parser.Cores;
using Sast.Parser.Models;
using System.Collections.Generic;

namespace Sast.Parser.Visitors
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
            if (ParseTreeUtility.IsMatchedContext("declarationstatement", node) == true)
            {
                DeclarationStatementVisitor declarationStatementVisitor = new DeclarationStatementVisitor();
                declarationStatementVisitor.Visit(node);

                VariableInfoList.AddRange(declarationStatementVisitor.VariableInfoList);
            }

            return base.VisitChildren(node);
        }
    }
}
