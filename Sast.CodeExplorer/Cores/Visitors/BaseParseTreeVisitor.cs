using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Models;

namespace Sast.CodeExplorer.Cores.Visitors
{
	public abstract class BaseParseTreeVisitor<Result> : AbstractParseTreeVisitor<Result>
	{
		#region Properties

		public LanguageType LanguageType
		{
			get;
			private set;
		}

		#endregion

		#region Constructors

		public BaseParseTreeVisitor(LanguageType type)
			: base()
		{
			LanguageType = type;
		}

		#endregion
	}
}
