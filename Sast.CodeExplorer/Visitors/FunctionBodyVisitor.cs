using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Cores;

namespace Sast.CodeExplorer.Visitors
{
	public class FunctionBodyVisitor : AbstractParseTreeVisitor<bool>
	{
		#region Properties

		public IRuleNode Node
		{
			get;
			private set;
		}

		#endregion

		#region Public methods

		public override bool VisitChildren([NotNull] IRuleNode node)
		{
			if (ParseTreeUtility.IsMatchedContext("compoundstatement", node) == true)
			{
				Node = node;
			}

			return base.VisitChildren(node);
		}

		#endregion
	}
}