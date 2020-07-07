using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Cores.Visitors;
using Sast.CodeExplorer.Interfaces;
using Sast.CodeExplorer.Models;
using System.Collections.Generic;

namespace Sast.CodeExplorer.Cores.VisitorFactory
{
	public class CppVisitorFactory : IVisitorFactory
	{
		#region Properties

		public IParseTreeVisitor<string> TerminalVisitor => new TerminalVisitor() { Type = LanguageType.CPP };

		public IParseTreeVisitor<string> TypeNameVisitor => new TypeNameVisitor() { Type = LanguageType.CPP };

		public IParseTreeVisitor<string> FunctionNameVisitor => new FunctionNameVisitor() { Type = LanguageType.CPP };

		public IParseTreeVisitor<IDictionary<string, IRuleNode>> FunctionVisitor => new FunctionVisitor() { Type = LanguageType.CPP };

		public IParseTreeVisitor<IRuleNode> FunctionBodyVisitor => new FunctionBodyVisitor() { Type = LanguageType.CPP };

		#endregion
	}
}
