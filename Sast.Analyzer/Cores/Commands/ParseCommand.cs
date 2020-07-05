using CommandLine;
using Sast.Analyzer.Interfaces;
using Sast.Parser.Managers;
using Sast.Parser.Visitors;
using System.Linq;

namespace Sast.Analyzer.Cores.Commands
{
    [Verb("parse", HelpText = "Parse to C# code.")]
    public class ParseCommand : IAction
    {
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

        public int Action()
        {
            ParserManager.Instance.FileParse(@FileFullPath);

            var parseTree = ParserManager.Instance.ParseTreeMap.Values.FirstOrDefault();
            if (parseTree != null)
            {
                DeclarationVisitor declareVisitor = new DeclarationVisitor();
                declareVisitor.Visit(parseTree);
            }

            return 1;
        }
    }
}
