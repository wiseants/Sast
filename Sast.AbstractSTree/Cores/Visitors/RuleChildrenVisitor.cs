using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;

namespace Sast.AbstractSTree.Cores.Visitors
{
	/// <summary>
	/// 전달한 룰이름의 하위노드를 모두 가져옵니다.
	/// </summary>
	public class RuleChildrenVisitor : AbstractParseTreeVisitor<List<IRuleNode>>
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

		public override List<IRuleNode> VisitChildren([NotNull] IRuleNode node)
		{
			if (ParseTreeUtility.IsMatchedContext(RuleName, node) == true)
			{
				return new List<IRuleNode>() { node };
			}

			return base.VisitChildren(node);
		}

		protected override List<IRuleNode> AggregateResult(List<IRuleNode> aggregate, List<IRuleNode> nextResult)
		{
			List<IRuleNode> results = null;
			if (aggregate != null)
			{
				results = results ?? new List<IRuleNode>();
				results.AddRange(aggregate);
			}

			if (nextResult != null)
			{
				results = results ?? new List<IRuleNode>();
				results.AddRange(nextResult);
			}

			return results;
		}

		#endregion
	}
}
