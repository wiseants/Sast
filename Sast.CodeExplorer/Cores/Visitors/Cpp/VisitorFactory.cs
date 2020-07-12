using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Interfaces;
using Sast.CodeExplorer.Models.Nodes;
using System.Collections.Generic;

namespace Sast.CodeExplorer.Cores.Visitors.Cpp
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
