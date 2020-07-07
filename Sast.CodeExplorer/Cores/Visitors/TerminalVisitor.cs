using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Sast.CodeExplorer.Cores.Visitors
{
	public class TerminalVisitor : BaseParseTreeVisitor<string>
    {
		#region Override mehtods

		public override string VisitTerminal([NotNull] ITerminalNode node)
        {
            return node.GetText();
        }

        #endregion
    }
}
