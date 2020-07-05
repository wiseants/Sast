using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Cores;
using Sast.CodeExplorer.Models;
using System.Collections.Generic;

namespace Sast.CodeExplorer.Visitors
{
    public class DeclarationVisitor : AbstractParseTreeVisitor<bool>
    {
        #region Constructors

        public DeclarationVisitor()
        {

        }

        #endregion

        #region Properties

        public List<VariableInfo> VariableInfoList
        {
            get;
        } = new List<VariableInfo>();

        #endregion

        #region Public methods

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

        #endregion
    }
}
