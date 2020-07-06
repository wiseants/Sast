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

		public IParseTreeVisitor<string> TerminalVisitor
		{
			get { return new TerminalVisitor(LanguageType.CSharp); }
		}

		public IParseTreeVisitor<string> TypeNameVisitor
		{
			get { return new TypeNameVisitor(LanguageType.CSharp); }
		}

		public IParseTreeVisitor<string> FunctionNameVisitor
		{
			get { return new FunctionNameVisitor(LanguageType.CSharp); }
		}

		public IParseTreeVisitor<IDictionary<string, IRuleNode>> FunctionVisitor
		{
			get { return new FunctionVisitor(LanguageType.CSharp); }
		}

		public IParseTreeVisitor<IRuleNode> FunctionBodyVisitor
		{
			get { return new FunctionBodyVisitor(LanguageType.CSharp); }
		}

		#endregion
	}
}
