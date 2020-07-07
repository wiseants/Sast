using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Cores.Visitors;
using Sast.CodeExplorer.Interfaces;
using Sast.CodeExplorer.Models;
using System.Collections.Generic;

namespace Sast.CodeExplorer.Cores.VisitorFactory
{
	public class CSharpVisitorFactory : IVisitorFactory
	{
		#region Properties

		public IParseTreeVisitor<string> TerminalVisitor => new TerminalVisitor() { Type = LanguageType.CSharp };

		public IParseTreeVisitor<string> TypeNameVisitor => new TypeNameVisitor() { Type = LanguageType.CSharp };

		public IParseTreeVisitor<string> FunctionNameVisitor => new FunctionNameVisitor() { Type = LanguageType.CSharp };

		public IParseTreeVisitor<IDictionary<string, IRuleNode>> FunctionVisitor => new FunctionVisitor() { Type = LanguageType.CSharp };

		public IParseTreeVisitor<IRuleNode> FunctionBodyVisitor => new FunctionBodyVisitor() { Type = LanguageType.CSharp };

		#endregion
	}
}
