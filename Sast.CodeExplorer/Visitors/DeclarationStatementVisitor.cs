using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Cores;
using Sast.CodeExplorer.Models;
using System.Collections.Generic;

namespace Sast.CodeExplorer.Visitors
{
    public class DeclarationStatementVisitor : AbstractParseTreeVisitor<bool>
    {
        #region Fields

        private string _currentType;

        #endregion

        #region Constructors

        public DeclarationStatementVisitor()
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
            if (ParseTreeUtility.IsMatchedContext("typespecifier", node) == true)
            {
                TerminalVisitor typeVisitor = new TerminalVisitor();
                _currentType = typeVisitor.Visit(node);
            }
            else if (ParseTreeUtility.IsMatchedContext("declaratorid", node) == true)
            {
                TerminalVisitor typeVisitor = new TerminalVisitor();

                VariableInfoList.Add(new VariableInfo() 
                { 
                    TypeName = _currentType, 
                    Name = typeVisitor.Visit(node)
                });
            }

            return base.VisitChildren(node);
        }

        #endregion
    }
}
