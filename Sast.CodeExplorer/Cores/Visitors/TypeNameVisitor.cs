using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Interfaces;

namespace Sast.CodeExplorer.Cores.Visitors
{
	public class TypeNameVisitor : BaseParseTreeVisitor<string>
	{
		#region Override methods

		public override string VisitChildren([NotNull] IRuleNode node)
		{
			if (ParseTreeUtility.IsMatchedContext("typespecifier", node) == true)
			{
				return Bootstrapper.Instance.CreateContainer<IVisitorFactory>(Type.Keyword).TerminalVisitor.Visit(node);
			}

			return base.VisitChildren(node);
		}

		protected override bool ShouldVisitNextChild([NotNull] IRuleNode node, string currentResult)
		{
			return string.IsNullOrEmpty(currentResult);
		}

		#endregion
	}
}
