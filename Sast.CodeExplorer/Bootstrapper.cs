using Antlr4.Runtime;
using NLog;
using Sast.Antlr.Grammars;
using Sast.CodeExplorer.Cores.Visitors.Cpp;
using Sast.CodeExplorer.Cores.Visitors.CSharp;
using Sast.CodeExplorer.Interfaces;
using Sast.CodeExplorer.Models;
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
            T result = default;

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
            T result = default;

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
            container.RegisterType<Lexer, CPP14Lexer>(LanguageType.CPP.Keyword);
            container.RegisterType<Lexer, CSharpLexer>(LanguageType.CSharp.Keyword);

            // 파서.
            container.RegisterType<Parser, CPP14Parser>(LanguageType.CPP.Keyword);
            container.RegisterType<Parser, CSharpParser>(LanguageType.CSharp.Keyword);

			// 비지터.
			container.RegisterType<IVisitorFactory, Cores.Visitors.Cpp.VisitorFactory>(LanguageType.CPP.Keyword);
			container.RegisterType<IVisitorFactory, Cores.Visitors.CSharp.VisitorFactory>(LanguageType.CSharp.Keyword);
		}

		#endregion
	}
}
