namespace Sast.AbstractSTree.Interfaces
{
	public interface ITreeNode : INode
	{
		#region Properties

		ITreeNode[] Children { get; set; }

		#endregion
	}
}
