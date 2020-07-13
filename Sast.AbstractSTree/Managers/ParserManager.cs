using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using NLog;
using Sast.AbstractSTree.Cores;
using Sast.AbstractSTree.Interfaces;
using Sast.AbstractSTree.Models;
using Sast.Utility.Templates;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Unity.Resolution;

namespace Sast.AbstractSTree.Managers
{
    public class ParserManager : Singleton<ParserManager>
    {
        #region Properties

        /// <summary>
        /// 파일이름을 키워드로 하는 파스트리맵.
        /// </summary>
        public ConcurrentDictionary<string, IParseTree> ParseTreeMap
        {
            get;
			private set;
		} = new ConcurrentDictionary<string, IParseTree>();

		public ConcurrentDictionary<string, ITreeNode> AstTreeMap
		{
			get;
			private set;
		} = new ConcurrentDictionary<string, ITreeNode>();

		public ConcurrentDictionary<string, IRuleNode> FunctionBodyMap
        {
            get;
            private set;
        } = new ConcurrentDictionary<string, IRuleNode>();

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
        /// <returns>파싱 성공 여부.</returns>
        public void FileParse(string fileFullPath)
        {
            // 언어 타입 찾기.
			LanguageType type = LanguageType.GetLanguageType(new FileInfo(fileFullPath).Extension);
            if (type == LanguageType.None)
			{
                return;
			}

            // 코드 파싱.
            IParseTree currentParseTree = null;
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

                currentParseTree = ParseTreeUtility.GetNode(Bootstrapper.Instance.CreateContainer<IVisitorFactory>(type.Keyword).RootName, parser);
			}
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex.Message);
            }

            // 파싱 실패시.
            if (currentParseTree == null)
            {
                return;
            }
            LogManager.GetCurrentClassLogger().Debug("Success to parse : Path({0})", @fileFullPath);

            // 트리로 부터 데이터 생성.
   //         var funcDeclareVisitor = Bootstrapper.Instance.CreateContainer<IVisitorFactory>(type.Keyword).FunctionVisitor;
			//foreach (var pair in funcDeclareVisitor.Visit(currentParseTree))
			//{
			//	FunctionBodyMap.Add(pair.Key, pair.Value);
   //             LogManager.GetCurrentClassLogger().Debug("Success to extract : Name({0}), ParseTree({1})",
   //                 pair.Key,
   //                 pair.Value.ToString()); ;
			//}

			ParseTreeMap.AddOrUpdate(fileFullPath, currentParseTree, (key, value) =>
            {
                return value;
            });

            // 트리로부터 기본적인 AST 생성.
			var astVisitor = Bootstrapper.Instance.CreateContainer<IVisitorFactory>(type.Keyword).BaseNodeVisitor;
            if (astVisitor != null)
			{
				AstTreeMap.AddOrUpdate(fileFullPath, astVisitor.Visit(currentParseTree), (key, value) =>
    			{
					return value;
				});
			}
		}

		/// <summary>
		/// 폴더명을 전달하여 전체 파일을 파싱합니다.
		/// </summary>
		/// <param name="folderFullPath">파싱할 폴더 전체 경로.</param>
		/// <returns>파싱 성공 여부.</returns>
		public void FolderParse(string folderFullPath)
		{
            if (string.IsNullOrEmpty(folderFullPath) == true)
			{
                return;
			}

            string[] filePaths = Directory.GetFiles(@folderFullPath, "*.*", SearchOption.AllDirectories);

            foreach (string fileFullPath in filePaths)
			{
                FileParse(fileFullPath);
            }

            Parallel.ForEach(filePaths, (string fileFullPath) =>
            {
                FileParse(fileFullPath);
            });
        }

        #endregion
    }
}
