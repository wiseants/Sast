using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Cores;
using System.Collections.Generic;

namespace Sast.CodeExplorer.Visitors
{
	public class FunctionVisitor : AbstractParseTreeVisitor<IRuleNode>
	{
		#region Properties

		public Dictionary<string, IRuleNode> FunctionBodyMap
		{
			get;
		} = new Dictionary<string, IRuleNode>();

		#endregion

		#region Public methods

		public override IRuleNode VisitChildren([NotNull] IRuleNode node)
		{
			if (ParseTreeUtility.IsMatchedContext("functiondefinition", node) == true)
			{
				FunctionNameVisitor nameVisitor = new FunctionNameVisitor();
				if (ParseTreeUtility.TryChildContext("declarator", node, out IParseTree nameNode) == true)
				{
					nameVisitor.Visit(nameNode);

					FunctionBodyVisitor bodyVisitor = new FunctionBodyVisitor();
					if (ParseTreeUtility.TryChildContext("functionbody", node, out IParseTree bodynode) == true)
					{
						bodyVisitor.Visit(bodynode);
					}

					FunctionBodyMap.Add(nameVisitor.Name, bodyVisitor.Node);
				}
			}

			return base.VisitChildren(node);
		}

		#endregion
	}
}
