using Antlr4.Runtime;
using NLog;
using Sast.Antlr.Grammars;
using Sast.CodeExplorer.Cores.VisitorFactory;
using Sast.CodeExplorer.Interfaces;
using Sast.Utility.Templates;
using System;
using Unity;
using Unity.Resolution;

namespace Sast.CodeExplorer
{
	internal class Bootstrapper : Singleton<Bootstrapper>
    {
        #region Fileds

        private readonly IUnityContainer container = new UnityContainer();

        #endregion

        #region Constructors

        private Bootstrapper()
        {
            BuildContainer();
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
            // 렉서.
            container.RegisterType<Lexer, CSharpLexer>("csharp");
            container.RegisterType<Lexer, CPP14Lexer>("cpp");

            // 파서.
            container.RegisterType<Parser, CSharpParser>("csharp");
            container.RegisterType<Parser, CPP14Parser>("cpp");

            // 비지터.
			container.RegisterType<IVisitorFactory, CppVisitorFactory>("csharp");
			container.RegisterType<IVisitorFactory, CppVisitorFactory>("cpp");
		}

		#endregion
	}
}
