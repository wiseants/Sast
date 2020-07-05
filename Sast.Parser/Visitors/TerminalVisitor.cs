using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Sast.Parser.Visitors
{
    public class TerminalVisitor : AbstractParseTreeVisitor<string>
    {
        public override string VisitTerminal([NotNull] ITerminalNode node)
        {
            return node.GetText();
        }
    }
}
