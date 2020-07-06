﻿using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Models;

namespace Sast.CodeExplorer.Cores.Visitors
{
	public class FunctionBodyVisitor : BaseParseTreeVisitor<IRuleNode>
	{
		#region Constructors

		public FunctionBodyVisitor(LanguageType type)
			: base(type)
		{

		}

		#endregion

		#region Override methods

		public override IRuleNode VisitChildren([NotNull] IRuleNode node)
		{
			if (ParseTreeUtility.IsMatchedContext("compoundstatement", node) == true)
			{
				return node;
			}

			return base.VisitChildren(node);
		}

		protected override bool ShouldVisitNextChild([NotNull] IRuleNode node, IRuleNode currentResult)
		{
			return currentResult == null;
		}

		#endregion
	}
}