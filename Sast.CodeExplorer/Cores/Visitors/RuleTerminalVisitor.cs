using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;

namespace Sast.CodeExplorer.Cores.Visitors
{
	/// <summary>
	/// 노드에서 전달한 룰이름의 하위노드의 터미널노드를 모두 가져옵니다.
	/// </summary>
	public class RuleTerminalVisitor : AbstractParseTreeVisitor<List<ITerminalNode>>
	{
		#region Properties

		/// <summary>
		/// 룰 이름.
		/// </summary>
		public string RuleName
		{
			get;
			set;
		}

		#endregion

		#region Override methods

		public override List<ITerminalNode> VisitChildren([NotNull] IRuleNode node)
		{
			if (string.IsNullOrEmpty(RuleName) == false && ParseTreeUtility.IsMatchedContext(RuleName, node) == true)
			{
				return new List<ITerminalNode>() { new TerminalVisitor().Visit(node) };
			}

			return base.VisitChildren(node);
		}

		protected override List<ITerminalNode> AggregateResult(List<ITerminalNode> aggregate, List<ITerminalNode> nextResult)
		{
			List<ITerminalNode> results = null;
			if (aggregate != null)
			{
				results = results ?? new List<ITerminalNode>();
				results.AddRange(aggregate);
			}

			if (nextResult != null)
			{
				results = results ?? new List<ITerminalNode>();
				results.AddRange(nextResult);
			}

			return results;
		}

		#endregion
	}
}
