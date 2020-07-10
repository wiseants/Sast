using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.Antlr.Grammars;

namespace Sast.CodeExplorer.Cores.Visitors.Cpp
{
	public class UnqualifiedidVisitor : CPP14BaseVisitor<string>
	{
		#region Override methods

		public override string VisitUnqualifiedid([NotNull] CPP14Parser.UnqualifiedidContext context)
		{
			return string.Join("", new TerminalVisitor().Visit(context));
		}

		protected override bool ShouldVisitNextChild([NotNull] IRuleNode node, string currentResult)
		{
			return string.IsNullOrEmpty(currentResult);
		}

		#endregion
	}
}