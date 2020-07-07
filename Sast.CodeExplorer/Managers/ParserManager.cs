using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using NLog;
using Sast.CodeExplorer.Cores;
using Sast.CodeExplorer.Interfaces;
using Sast.CodeExplorer.Models;
using Sast.Utility.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.Resolution;

namespace Sast.CodeExplorer.Managers
{
    public class ParserManager : Singleton<ParserManager>
    {
        #region Properties

        /// <summary>
        /// 파일이름을 키워드로 하는 파스트리맵.
        /// </summary>
        public IDictionary<string, IParseTree> ParseTreeMap
        {
            get;
			private set;
		} = new Dictionary<string, IParseTree>();

        public IDictionary<string, IRuleNode> FunctionBodyMap
        {
            get;
            private set;
        } = new Dictionary<string, IRuleNode>();

        #endregion

        #region Constructors

        private ParserManager()
        {

        }

        #endregion

        #region Public methods

        /// <summary>
        /// 파일을 전달하여 파일을 파싱합니다.
        /// </summary>
        /// <param name="fileFullPath">파싱할 파일 전체 경로.</param>
        /// <returns>참:파싱 성공, 거짓:파싱 실패.</returns>
        public bool FileParse(string fileFullPath)
        {
            bool isSuccess = false;

			LanguageType type = LanguageType.GetLanguageType(new FileInfo(fileFullPath).Extension);
            if (type == LanguageType.None)
			{
                return isSuccess;
			}

			try
			{
                var lexer = Bootstrapper.Instance.CreateContainer<Lexer>(type.Keyword, new ResolverOverride[]
                {
                new ParameterOverride("input", new AntlrInputStream(File.ReadAllText(@fileFullPath)))
                });

                var parser = Bootstrapper.Instance.CreateContainer<Parser>(type.Keyword, new ResolverOverride[]
                {
                new ParameterOverride("input", new CommonTokenStream(lexer))
                });
                parser.BuildParseTree = true;

                ParseTreeMap.Add(fileFullPath, ParseTreeUtility.GetNode(
                    Bootstrapper.Instance.CreateContainer<IVisitorFactory>(type.Keyword).RootName, 
                    parser));

                isSuccess = true;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex.Message);
            }

			var parseTree = ParseTreeMap.Values.FirstOrDefault();
			if (parseTree != null)
			{
                var funcDeclareVisitor = Bootstrapper.Instance.CreateContainer<IVisitorFactory>(type.Keyword).FunctionVisitor;
                FunctionBodyMap = funcDeclareVisitor.Visit(parseTree);
            }


			return isSuccess;
        }

        #endregion
    }
}
