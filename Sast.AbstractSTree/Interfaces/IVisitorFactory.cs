using Antlr4.Runtime.Tree;
using Sast.AbstractSTree.Models;
using Sast.AbstractSTree.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sast.AbstractSTree.Interfaces
{
	public interface IVisitorFactory
	{
		#region Properties

		string RootName { get; }
		IParseTreeVisitor<IDictionary<string, IRuleNode>> FunctionVisitor { get; }
		IParseTreeVisitor<BaseNode> BaseNodeVisitor { get; }

		#endregion
	}
}