using NLog;
using System;
using Unity;
using Unity.Resolution;

namespace Sast.Utility
{
    internal class Bootstrapper
    {
        #region Fileds

        private static Bootstrapper instance = null;
        private IUnityContainer container = new UnityContainer();

        #endregion

        #region Constructors

        private Bootstrapper()
        {
            BuildContainer();
        }

        #endregion

        #region Properties

        public static Bootstrapper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Bootstrapper();
                }

                return instance;
            }
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

        }

        #endregion
    }
}
