using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Interfaces;
using Sast.CodeExplorer.Models;
using System.Collections.Generic;

namespace Sast.CodeExplorer.Cores.Visitors.CSharp
{
	public class CSharpVisitorFactory : IVisitorFactory
	{
		#region Properties

		public string RootName => "compilation_unit";

		public IParseTreeVisitor<IDictionary<string, IRuleNode>> FunctionVisitor => new CSharpFunctionVisitor() { Type = LanguageType.CSharp };

		#endregion
	}
}