using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Sast.Analyzer.Antrl.Visitors;
using Sast.Antlr.Grammars;
using Sast.Antlr.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Sast.Antlr.Cores
{
    public class ParseTreeUtility
    {
        public static IParseTree GetNode(string ruleName, Parser parser)
        {
            return parser.GetType().GetMethod(ruleName).Invoke(parser, null) as IParseTree;
        }

        public static bool IsMatchedContext(string ruleName, IParseTree tree)
        {
            return tree.GetType().Name.Equals(ruleName + "context", StringComparison.OrdinalIgnoreCase);
        }
    }
}
