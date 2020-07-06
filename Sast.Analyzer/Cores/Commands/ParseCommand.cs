using CommandLine;
using Sast.Analyzer.Interfaces;
using Sast.CodeExplorer.Managers;

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

            return 1;
        }

        #endregion
    }
}
