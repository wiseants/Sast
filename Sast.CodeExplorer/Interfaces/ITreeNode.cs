using System.Collections.Generic;

namespace Sast.CodeExplorer.Interfaces
{
	public interface ITreeNode : INode
	{
		#region Properties

		IEnumerable<ITreeNode> Children { get; set; }

		#endregion
	}
}
