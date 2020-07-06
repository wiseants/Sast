using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Interfaces;
using Sast.CodeExplorer.Models;

namespace Sast.CodeExplorer.Cores.Visitors
{
	public class TypeNameVisitor : BaseParseTreeVisitor<string>
	{
		#region Constructor

		public TypeNameVisitor(LanguageType type)
			: base(type)
		{

		}

		#endregion

		#region Override methods

		public override string VisitChildren([NotNull] IRuleNode node)
		{
			if (ParseTreeUtility.IsMatchedContext("typespecifier", node) == true)
			{
				return Bootstrapper.Instance.CreateContainer<IVisitorFactory>(LanguageType.Keyword).TerminalVisitor.Visit(node);
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
