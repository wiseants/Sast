using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Models;
using Sast.CodeExplorer.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sast.CodeExplorer.Interfaces
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