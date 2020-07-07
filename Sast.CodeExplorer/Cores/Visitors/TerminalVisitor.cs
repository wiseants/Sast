using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Sast.CodeExplorer.Cores.Visitors
{
    /// <summary>
    /// 터미널 노드 비지터입니다.
    /// </summary>
	public class TerminalVisitor : AbstractParseTreeVisitor<ITerminalNode>
    {
		#region Override mehtods

		public override ITerminalNode VisitTerminal([NotNull] ITerminalNode node)
        {
            return node;
        }

        #endregion
    }
}