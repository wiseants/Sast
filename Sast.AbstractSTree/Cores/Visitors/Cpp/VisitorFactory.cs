using Antlr4.Runtime.Tree;
using Sast.AbstractSTree.Interfaces;
using Sast.AbstractSTree.Models.Nodes;
using System.Collections.Generic;

namespace Sast.AbstractSTree.Cores.Visitors.Cpp
{
	public class VisitorFactory : IVisitorFactory
	{
		#region Properties

		public string RootName => "translationunit";

		public IParseTreeVisitor<IDictionary<string, IRuleNode>> FunctionVisitor => new FunctionVisitor();

		public IParseTreeVisitor<BaseNode> BaseNodeVisitor => new BaseNodeVisitor();

		#endregion
	}
}
