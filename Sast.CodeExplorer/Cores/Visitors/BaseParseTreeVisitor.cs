using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Models;

namespace Sast.CodeExplorer.Cores.Visitors
{
	/// <summary>
	/// 언어 타입을 포함하기 위한 추상 템플릿 클래스.
	/// </summary>
	/// <typeparam name="Result"></typeparam>
	public abstract class BaseParseTreeVisitor<Result> : AbstractParseTreeVisitor<Result>
	{
		#region Properties

		/// <summary>
		/// 언어 타입.
		/// </summary>
		public LanguageType Type
		{
			get;
			set;
		} = LanguageType.None;

		#endregion
	}
}