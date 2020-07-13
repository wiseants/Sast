using Sast.AbstractSTree.Interfaces;

namespace Sast.AbstractSTree.Models.Nodes
{
	public class BaseNode : ITreeNode
	{
		public ITreeNode[] Children { get; set; }
		public string Name { get; set; }
	}
}