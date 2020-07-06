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

		public IParseTreeVisitor<string> TerminalVisitor
		{
			get { return new TerminalVisitor(LanguageType.CPP); }
		}

		public IParseTreeVisitor<string> TypeNameVisitor
		{
			get { return new TypeNameVisitor(LanguageType.CPP); }
		}

		public IParseTreeVisitor<string> FunctionNameVisitor
		{
			get { return new FunctionNameVisitor(LanguageType.CPP); }
		}

		public IParseTreeVisitor<IDictionary<string, IRuleNode>> FunctionVisitor
		{
			get { return new FunctionVisitor(LanguageType.CPP); }
		}

		public IParseTreeVisitor<IRuleNode> FunctionBodyVisitor
		{
			get { return new FunctionBodyVisitor(LanguageType.CPP); }
		}

		#endregion
	}
}
