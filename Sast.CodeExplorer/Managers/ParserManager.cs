using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Sast.CodeExplorer.Cores;
using Sast.CodeExplorer.Visitors;
using Sast.Utility.Templates;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.Resolution;

namespace Sast.CodeExplorer.Managers
{
    public class ParserManager : Singleton<ParserManager>
    {
        public Dictionary<string, IParseTree> ParseTreeMap
        {
            get;
        } = new Dictionary<string, IParseTree>();

        private ParserManager()
        {

        }

        public bool FileParse(string fileFullPath)
        {
            bool isSuccess = false;

            var lexer = Bootstrapper.Instance.CreateContainer<Lexer>(new ResolverOverride[]
            {
                new ParameterOverride("input", new AntlrInputStream(File.ReadAllText(@fileFullPath)))
            });

            var parser = Bootstrapper.Instance.CreateContainer<Antlr4.Runtime.Parser>(new ResolverOverride[]
            {
                new ParameterOverride("input", new CommonTokenStream(lexer))
            });
            parser.BuildParseTree = true;

            ParseTreeMap.Add(fileFullPath, ParseTreeUtility.GetNode("translationunit", parser));

                DeclarationVisitor declareVisitor = new DeclarationVisitor();
                declareVisitor.Visit(ParseTreeMap.Values.FirstOrDefault());

            return isSuccess;
        }
    }
}
