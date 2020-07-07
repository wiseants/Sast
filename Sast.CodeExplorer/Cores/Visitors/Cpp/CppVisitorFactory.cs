using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Cores.Visitors.Cpp;
using Sast.CodeExplorer.Interfaces;
using Sast.CodeExplorer.Models;
using System.Collections.Generic;

namespace Sast.CodeExplorer.Cores.Visitors.Cpp
{
	public class CppVisitorFactory : IVisitorFactory
	{
		#region Properties

		public string RootName => "translationunit";

		public IParseTreeVisitor<IDictionary<string, IRuleNode>> FunctionVisitor => new CppFunctionVisitor() { Type = LanguageType.CPP };

		#endregion
	}
}
