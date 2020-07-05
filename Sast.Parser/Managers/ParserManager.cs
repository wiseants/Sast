using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Sast.Parser.Cores;
using Sast.Parser.Visitors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using Unity.Resolution;

namespace Sast.Parser.Managers
{
    public class ParserManager
    {
        private static readonly Lazy<ParserManager> _instance = new Lazy<ParserManager>(() =>
        {
            // Get non-public constructors for T.
            var ctors = typeof(ParserManager).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

            // If we can't find the right type of constructor, throw an exception.
            if (!Array.Exists(ctors, (ci) => ci.GetParameters().Length == 0))
            {
                throw new ConstructorNotFoundException("Non-public ctor() note found.");
            }

            // Get reference to default non-public constructor.
            var ctor = Array.Find(ctors, (ci) => ci.GetParameters().Length == 0);

            // Invoke constructor and return resulting object.
            return ctor.Invoke(new object[] { }) as ParserManager;
        }, LazyThreadSafetyMode.ExecutionAndPublication);

        public Dictionary<string, IParseTree> ParseTreeMap
        {
            get;
        } = new Dictionary<string, IParseTree>();

        private ParserManager()
        {

        }

        public static ParserManager Instance
        {
            get { return _instance.Value; }
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

    /// <summary>
    /// Exception thrown by Singleton&lt;T&gt; when derived type does not contain a non-public default constructor.
    /// </summary>
    public class ConstructorNotFoundException : Exception
    {
        private const string ConstructorNotFoundMessage = "Singleton<T> derived types require a non-public default constructor.";
        public ConstructorNotFoundException() : base(ConstructorNotFoundMessage) { }
        public ConstructorNotFoundException(string auxMessage) : base(String.Format("{0} - {1}", ConstructorNotFoundMessage, auxMessage)) { }
        public ConstructorNotFoundException(string auxMessage, Exception inner) : base(String.Format("{0} - {1}", ConstructorNotFoundMessage, auxMessage), inner) { }
    }
}
