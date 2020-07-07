using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Cores.Visitors;
using Sast.CodeExplorer.Interfaces;
using Sast.CodeExplorer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sast.CodeExplorer.Cores.VisitorFactory
{
	public class NoneVisitorFactory : IVisitorFactory
	{
		#region Properties

		public IParseTreeVisitor<string> TerminalVisitor => new TerminalVisitor();

		public IParseTreeVisitor<string> TypeNameVisitor => new TypeNameVisitor();

		public IParseTreeVisitor<string> FunctionNameVisitor => new FunctionNameVisitor();

		public IParseTreeVisitor<IDictionary<string, IRuleNode>> FunctionVisitor => new FunctionVisitor();

		public IParseTreeVisitor<IRuleNode> FunctionBodyVisitor => new FunctionBodyVisitor();

		#endregion
	}
}
