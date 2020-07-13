using System.Collections.Generic;

namespace Sast.CodeExplorer.Interfaces
{
	public interface ITreeNode : INode
	{
		#region Properties

		ITreeNode[] Children { get; set; }

		#endregion
	}
}
