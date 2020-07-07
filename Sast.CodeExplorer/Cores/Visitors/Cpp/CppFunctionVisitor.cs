using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using System.Linq;

namespace Sast.CodeExplorer.Cores.Visitors.Cpp
{
	public class CppFunctionVisitor : BaseParseTreeVisitor<Dictionary<string, IRuleNode>>
	{
		#region Override methods

		public override Dictionary<string, IRuleNode> VisitChildren([NotNull] IRuleNode node)
		{
			if (ParseTreeUtility.IsMatchedContext("functiondefinition", node) == true)
			{
				string functionName = string.Empty;
				IRuleNode functionBody = null;

				if (ParseTreeUtility.TryChildContext("declarator", node, out IParseTree nameNode) == true)
				{
					functionName = ParseTreeUtility.GetTerminals("declaratorid", nameNode).FirstOrDefault().GetText();
				}

				if (ParseTreeUtility.TryChildContext("functionbody", node, out IParseTree bodynode) == true)
				{
					functionBody = ParseTreeUtility.GetChildren("compoundstatement", bodynode).FirstOrDefault();
				}

				return string.IsNullOrEmpty(functionName) == false && functionBody != null ? new Dictionary<string, IRuleNode>()
				{
					{ functionName, functionBody }
				} : null;
			}

			return base.VisitChildren(node);
		}

		protected override Dictionary<string, IRuleNode> AggregateResult(
			Dictionary<string, IRuleNode> aggregate, 
			Dictionary<string, IRuleNode> nextResult)
		{
			Dictionary<string, IRuleNode> results = null;
			if (aggregate != null)
			{
				results = results ?? new Dictionary<string, IRuleNode>();
				foreach(var pair in aggregate)
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
