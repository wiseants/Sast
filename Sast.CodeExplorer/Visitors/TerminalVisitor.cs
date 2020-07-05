using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Sast.CodeExplorer.Visitors
{
    public class TerminalVisitor : AbstractParseTreeVisitor<string>
    {
        #region Public mehtods

        public override string VisitTerminal([NotNull] ITerminalNode node)
        {
            return node.GetText();
        }

        #endregion
    }
}
