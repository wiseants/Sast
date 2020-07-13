using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;

namespace Sast.AbstractSTree.Cores.Visitors
{
    /// <summary>
    /// 터미널 노드 비지터입니다.
    /// </summary>
	public class TerminalVisitor : AbstractParseTreeVisitor<List<ITerminalNode>>
    {
		#region Override mehtods

		public override List<ITerminalNode> VisitTerminal([NotNull] ITerminalNode node)
        {
			return new List<ITerminalNode>() { node };
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