using Sast.CodeExplorer.Interfaces;
using System.Collections.Generic;

namespace Sast.CodeExplorer.Models.Nodes
{
	public class BaseNode : ITreeNode
	{
		public IEnumerable<ITreeNode> Children { get; set; }
		public string Name { get; set; }
	}
}