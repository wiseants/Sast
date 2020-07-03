using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;

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
