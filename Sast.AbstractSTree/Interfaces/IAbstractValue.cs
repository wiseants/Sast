using System;
using System.Collections.Generic;
using System.Text;

namespace Sast.AbstractSTree.Interfaces
{
	public interface IAbstractValue : IEquatable<IAbstractValue>, IBounded, IOperable
	{
	}
}
