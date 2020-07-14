using Sast.AbstractSTree.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sast.AbstractSTree.Models.Values
{
	public struct Int32_A : IAbstractValue
	{
		public Int32_A(int value)
		{
			Min = Max = value;
		}

		public int Min { get; set; }

		public int Max { get; set; }

		public long NegBoundary { get => int.MinValue; }

		public long PosBoundary { get => int.MaxValue; }

		public object Add(object value)
		{
			if (!(value is Int32_A valueA))
			{
				throw new Exception("Not supported operation.");
			}

			Int32_A newValue = new Int32_A();
			newValue.Min += valueA.Min;
			newValue.Max += valueA.Max;

			return newValue;
		}

		public object Divide(object value)
		{
			throw new NotImplementedException();
		}

		public bool Equals(IAbstractValue other)
		{
			throw new NotImplementedException();
		}

		public object Intersection(object value)
		{
			throw new NotImplementedException();
		}

		public object Join(object value)
		{
			throw new NotImplementedException();
		}

		public object Multiply(object value)
		{
			throw new NotImplementedException();
		}

		public object Remainder(object value)
		{
			throw new NotImplementedException();
		}

		public object Substract(object value)
		{
			throw new NotImplementedException();
		}
	}
}