using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Interfaces;
using Sast.CodeExplorer.Models;
using System.Collections.Generic;

namespace Sast.CodeExplorer.Cores.Visitors.CSharp
{
	public class VisitorFactory : IVisitorFactory
	{
		#region Properties

		public string RootName => "compilation_unit";

		public IParseTreeVisitor<IDictionary<string, IRuleNode>> FunctionVisitor => new FunctionVisitor() { Type = LanguageType.CSharp };

		#endregion
	}
}