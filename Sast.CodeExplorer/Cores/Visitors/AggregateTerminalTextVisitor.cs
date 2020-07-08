using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Sast.CodeExplorer.Cores.Visitors
{
	public class AggregateTerminalTextVisitor : AbstractParseTreeVisitor<string>
	{
		public override string VisitTerminal([NotNull] ITerminalNode node)
		{
			return node.GetText();
		}

		protected override string AggregateResult(string aggregate, string nextResult)
		{
			return string.Format("{0}{1}", aggregate, nextResult);
		}
	}
}