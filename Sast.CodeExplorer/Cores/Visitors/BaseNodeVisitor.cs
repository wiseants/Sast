using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Interfaces;
using Sast.CodeExplorer.Models.Nodes;
using System.Collections.Generic;

namespace Sast.CodeExplorer.Cores.Visitors
{
	public class BaseNodeVisitor : AbstractParseTreeVisitor<BaseNode>
	{
		#region Override methods

		public override BaseNode VisitChildren([NotNull] IRuleNode node)
		{
			if (node.ChildCount > 1)
			{
				List<ITreeNode> newChildren = new List<ITreeNode>();
				for (int i = 0; i < node.ChildCount; i++)
				{
					newChildren.Add(new BaseNodeVisitor().Visit(node.GetChild(i)));
				}

				BaseNode newNode = new BaseNode()
				{
					Name = node.GetType().Name,
					Children = newChildren
				};

				return newNode;
			}
			else
			{
				return base.VisitChildren(node);
			}
		}

		public override BaseNode VisitTerminal([NotNull] ITerminalNode node)
		{
			return new BaseNode() { Name = node.GetText() };
		}

		#endregion
	}
}
