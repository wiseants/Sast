using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Cores;

namespace Sast.CodeExplorer.Visitors
{
	public class FunctionNameVisitor : AbstractParseTreeVisitor<bool>
	{
		#region Properties

		public string Name
		{
			get;
			private set;
		}

		#endregion

		#region Public methods

		public override bool VisitChildren([NotNull] IRuleNode node)
		{
			if (ParseTreeUtility.IsMatchedContext("declaratorid", node) == true)
			{
				TerminalVisitor terminalVisitor = new TerminalVisitor();
				Name = terminalVisitor.Visit(node);
			}

			return base.VisitChildren(node);
		}

		#endregion
	}
}
