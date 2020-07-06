﻿using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Models;

namespace Sast.CodeExplorer.Cores.Visitors
{
	public class TerminalVisitor : BaseParseTreeVisitor<string>
    {
		#region Constructor

		public TerminalVisitor(LanguageType type)
			: base(type)
		{

		}

		#endregion

		#region Override mehtods

		public override string VisitTerminal([NotNull] ITerminalNode node)
        {
            return node.GetText();
        }

        #endregion
    }
}