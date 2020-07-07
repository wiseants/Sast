using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Models;

namespace Sast.CodeExplorer.Cores.Visitors
{
	public abstract class BaseParseTreeVisitor<Result> : AbstractParseTreeVisitor<Result>
	{
		#region Properties

		public LanguageType Type
		{
			get;
			set;
		} = LanguageType.None;

		#endregion
	}
}
