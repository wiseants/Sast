using Antlr4.Runtime;
using CommandLine;
using Sast.Analyzer.Antrl.Visitors;
using Sast.Analyzer.Interfaces;
using Sast.Antlr.Cores;
using System.IO;
using Unity.Resolution;

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
            var targetStream = new AntlrInputStream(File.ReadAllText(@FileFullPath));
            var lexer = Bootstrapper.Instance.CreateContainer<Lexer>(new ResolverOverride[]
            {
                new ParameterOverride("input", targetStream)
            });

            var tokens = new CommonTokenStream(lexer);
            var parser = Bootstrapper.Instance.CreateContainer<Antlr4.Runtime.Parser>(new ResolverOverride[]
            {
                new ParameterOverride("input", tokens)
            });
            parser.BuildParseTree = true;

            var rootNode = ParseTreeUtility.GetNode("translationunit", parser);
            if (rootNode != null)
            {
                DeclarationVisitor declareVisitor = new DeclarationVisitor();
                declareVisitor.Visit(rootNode);
            }

            return 1;
        }
    }
}
