using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.Antlr.Grammars;
using System.Collections.Generic;

namespace Sast.AbstractSTree.Cores.Visitors.Cpp
{
	public class FunctionVisitor : CPP14BaseVisitor<Dictionary<string, IRuleNode>>
	{
		#region Override methods

		public override Dictionary<string, IRuleNode> VisitFunctiondefinition([NotNull] CPP14Parser.FunctiondefinitionContext context)
		{
			return new Dictionary<string, IRuleNode>()
			{
				{ new UnqualifiedidVisitor().Visit(context.declarator()), context.functionbody() }
			};
		}

		protected override Dictionary<string, IRuleNode> AggregateResult(
			Dictionary<string, IRuleNode> aggregate,
			Dictionary<string, IRuleNode> nextResult)
		{
			Dictionary<string, IRuleNode> results = null;
			if (aggregate != null)
			{
				results = results ?? new Dictionary<string, IRuleNode>();
				foreach (var pair in aggregate)
				{
					results.Add(pair.Key, pair.Value);
				}
			}

			if (nextResult != null)
			{
				results = results ?? new Dictionary<string, IRuleNode>();
				foreach (var pair in nextResult)
				{
					results.Add(pair.Key, pair.Value);
				}
			}

			return results;
		}

		#endregion
	}
}