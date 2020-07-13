using NLog;
using Prism.Mvvm;
using Sast.Utility.Templates;
using Sast.Viewer.ViewModels;
using Sast.Viewer.Views;
using System;
using System.Windows;
using Unity;
using Unity.Resolution;

namespace Sast.Viewer
{
	public class Bootstrapper : Singleton<Bootstrapper>
    {
        #region Constructors

        private Bootstrapper()
        {
            BuildContainer();
		}

		#endregion

		#region Properties

		public IUnityContainer Container
		{
			get;
        } = new UnityContainer();

        #endregion

        #region Public methods

        public T CreateContainer<T>(params ResolverOverride[] overrides)
        {
            T result = default;

            try
            {
                result = Container.Resolve<T>(overrides);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex.Message);
            }

            return result;
        }

        public T CreateContainer<T>(string name, params ResolverOverride[] overrides)
        {
            T result = default;

            try
            {
                result = Container.Resolve<T>(name, overrides);
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
			Container.RegisterType<Window, MainView>("main");

            Container.RegisterType<BindableBase, MainViewModel>("main");
        }

        #endregion
    }
}
