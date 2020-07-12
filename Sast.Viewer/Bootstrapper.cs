using NLog;
using Prism.Mvvm;
using Sast.Utility.Templates;
using Sast.Viewer.ViewModels;
using System;
using System.Windows;
using Unity;
using Unity.Resolution;

namespace Sast.Viewer
{
	public class Bootstrapper : Singleton<Bootstrapper>
    {
        #region Fileds

        private readonly IUnityContainer container = new UnityContainer();

        #endregion

        #region Constructors

        private Bootstrapper()
        {
            BuildContainer();

			App.Current.Resources = new ResourceDictionary
			{
				{ App.LOCATOR_RESOURCE_KEY, container.Resolve<Cores.ViewModelLocator>() }
			};
		}

        #endregion

        #region Public methods

        public T CreateContainer<T>(params ResolverOverride[] overrides)
        {
            T result = default(T);

            try
            {
                result = container.Resolve<T>(overrides);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex.Message);
            }

            return result;
        }

        public T CreateContainer<T>(string name, params ResolverOverride[] overrides)
        {
            T result = default(T);

            try
            {
                result = container.Resolve<T>(name, overrides);
            }
            catch(Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex.Message);
            }

            return result;
        }

        #endregion

        #region Private methods

        private void BuildContainer()
        {
            container.RegisterType<BindableBase, MainViewModel>("MainViewModel");
        }

        #endregion
    }
}
