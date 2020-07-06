using CommandLine;
using Sast.Analyzer.Interfaces;
using Sast.CodeExplorer.Managers;
using Sast.CodeExplorer.Visitors;
using System.Linq;

namespace Sast.Analyzer.Cores.Commands
{
    [Verb("parse", HelpText = "Parse to C# code.")]
    public class ParseCommand : IAction
    {
        #region Properties

        public bool IsValid => true;

        /// <summary>
        /// 필수 옵션.
        /// </summary>
        [Option('f', "file", Required = true, HelpText = "file-name.")]
        public string @FileFullPath
        {
            get;
            set;
        }

        #endregion

        #region Public emthods

        public int Action()
        {
            ParserManager.Instance.FileParse(@FileFullPath);

            var parseTree = ParserManager.Instance.ParseTreeMap.Values.FirstOrDefault();
            if (parseTree != null)
            {
                FunctionVisitor funcDeclareVisitor = new FunctionVisitor();
                funcDeclareVisitor.Visit(parseTree);
            }

            return 1;
        }

        #endregion
    }
}
