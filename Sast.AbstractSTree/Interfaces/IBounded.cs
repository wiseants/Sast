namespace Sast.AbstractSTree.Interfaces
{
	public interface IBounded
	{
		#region Properties

		long NegBoundary { get; }

		long PosBoundary { get; }

		#endregion
	}
}
