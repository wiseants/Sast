namespace Sast.AbstractSTree.Interfaces
{
	public interface IOperable
	{
		#region Methods

		object Add(object value);
		object Substract(object value);
		object Multiply(object value);
		object Divide(object value);
		object Remainder(object value);
		object Join(object value);
		object Intersection(object value);

		#endregion
	}
}
