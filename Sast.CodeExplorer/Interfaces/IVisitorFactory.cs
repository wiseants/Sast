using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sast.CodeExplorer.Interfaces
{
	public interface IVisitorFactory
	{
		string RootName { get; }
		IParseTreeVisitor<IDictionary<string, IRuleNode>> FunctionVisitor { get; }
	}
}