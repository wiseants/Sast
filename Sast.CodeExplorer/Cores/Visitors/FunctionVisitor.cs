using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sast.CodeExplorer.Cores.Visitors
{
	public class FunctionVisitor : BaseParseTreeVisitor<IDictionary<string, IRuleNode>>
	{
		#region Override methods

		public override IDictionary<string, IRuleNode> VisitChildren([NotNull] IRuleNode node)
		{
			if (ParseTreeUtility.IsMatchedContext("functiondefinition", node) == true)
			{
				string functionName = string.Empty;
				IRuleNode functionBody = null;

				if (ParseTreeUtility.TryChildContext("declarator", node, out IParseTree nameNode) == true)
				{
					var nameVisitor = Bootstrapper.Instance.CreateContainer<IVisitorFactory>(Type.Keyword).FunctionNameVisitor;
					functionName = nameVisitor.Visit(nameNode);
				}

				if (ParseTreeUtility.TryChildContext("functionbody", node, out IParseTree bodynode) == true)
				{
					var bodyVisitor = Bootstrapper.Instance.CreateContainer<IVisitorFactory>(Type.Keyword).FunctionBodyVisitor;
					functionBody = bodyVisitor.Visit(bodynode);
				}

				return string.IsNullOrEmpty(functionName) == false && functionBody != null ? new Dictionary<string, IRuleNode>()
				{
					{ functionName, functionBody }
				} : null;
			}

			return base.VisitChildren(node);
		}

		protected override IDictionary<string, IRuleNode> AggregateResult(
			IDictionary<string, IRuleNode> aggregate, 
			IDictionary<string, IRuleNode> nextResult)
		{
			if (aggregate != null && nextResult == null)
			{
				return aggregate;
			}
			else if (aggregate == null && nextResult != null)
			{
				return nextResult;
			}
			else if (aggregate != null && nextResult != null)
			{
				return aggregate.Concat(nextResult).GroupBy(x => x.Key).ToDictionary(x => x.Key, x => x.First().Value);
			}
			else
			{
				return null;
			}
		}

		#endregion
	}
}
