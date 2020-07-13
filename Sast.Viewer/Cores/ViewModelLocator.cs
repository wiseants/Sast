using Prism.Mvvm;
using System;
using System.Collections.Generic;
using Unity;

namespace Sast.Viewer.Cores
{
	public class ViewModelLocator
	{
		#region Fields

		private readonly IUnityContainer _container = null;
		private readonly Dictionary<Type, object> _viewModelMap = new Dictionary<Type, object>();

		#endregion

		#region Constructors

		public ViewModelLocator(IUnityContainer container)
		{
			_container = container;
		}

		#endregion

		#region Properties

		public BindableBase MainViewModel
		{
			get
			{
				return CreateViewModel<BindableBase>("Main");
			}
		}

		#endregion

		#region Private methods

		private T CreateViewModel<T>(string name)
		{
			Type type = typeof(T);

			if (_viewModelMap.TryGetValue(type, out object existedValue) == false)
			{
				existedValue = _container.Resolve<T>(name);
				_viewModelMap[type] = existedValue;
			}

			return (T)existedValue;
		}

		#endregion
	}
}