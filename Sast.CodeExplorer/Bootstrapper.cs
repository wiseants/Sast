using Antlr4.Runtime;
using NLog;
using Sast.Antlr.Grammars;
using System;
using Unity;
using Unity.Resolution;

namespace Sast.CodeExplorer
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
            //container.RegisterType<Lexer, ExprLexer>();
            //container.RegisterType<Lexer, CPP14Lexer>();
            container.RegisterType<Lexer, CSharpLexer>("csharp");
            container.RegisterType<Lexer, CPP14Lexer>("cpp");

            //container.RegisterType<Parser, ExprParser>();
            //container.RegisterType<Parser, CPP14Parser>();
            container.RegisterType<Parser, CSharpParser>("csharp");
            container.RegisterType<Parser, CPP14Parser>("cpp");
        }

        #endregion
    }
}
