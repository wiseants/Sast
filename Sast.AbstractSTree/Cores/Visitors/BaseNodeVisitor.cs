using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sast.AbstractSTree.Interfaces;
using Sast.AbstractSTree.Models.Nodes;

namespace Sast.AbstractSTree.Cores.Visitors
{
	public class BaseNodeVisitor : AbstractParseTreeVisitor<BaseNode>
	{
		#region Override methods

		public override BaseNode VisitChildren([NotNull] IRuleNode node)
		{
			if (node.ChildCount > 1)
			{
				ITreeNode[] newChildren = new ITreeNode[node.ChildCount];
				for (int i = 0; i < node.ChildCount; i++)
				{
					newChildren[i] = new BaseNodeVisitor().Visit(node.GetChild(i));
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
