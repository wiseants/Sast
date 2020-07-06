using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Cores;
using System;
using System.Collections.Generic;
using System.Text;

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
				var typeNode = ParseTreeUtility.GetMatchedContext("declspecifierseq", node);
				TypeNameVisitor typeVisitor = new TypeNameVisitor();
				typeVisitor.Visit(typeNode);

				var nameNode = ParseTreeUtility.GetMatchedContext("declarator", node);
				FunctionNameVisitor nameVisitor = new FunctionNameVisitor();
				nameVisitor.Visit(nameNode);

				var bodyode = ParseTreeUtility.GetMatchedContext("functionbody", node);
				FunctionBodyVisitor bodyVisitor = new FunctionBodyVisitor();
				bodyVisitor.Visit(bodyode);

				FunctionBodyMap.Add(nameVisitor.Name, bodyVisitor.Node);
			}

			return base.VisitChildren(node);
		}

		#endregion
	}
}
