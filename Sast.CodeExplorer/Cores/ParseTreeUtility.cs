using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Reflection;

namespace Sast.CodeExplorer.Cores
{
    /// <summary>
    /// 파스트리에서 사용하는 유틸리티 메소드.
    /// </summary>
    public class ParseTreeUtility
    {
        #region Public methods

        /// <summary>
        /// 그래마에 정의된 룰이름으로 파스트리를 가져옵니다.
        /// </summary>
        /// <param name="ruleName">그래마의 룰 이름.</param>
        /// <param name="parser">파서 오브젝트.</param>
        /// <returns>결과 파스트리.</returns>
        public static IParseTree GetNode(string ruleName, Parser parser)
        {
            return parser.GetType().GetMethod(ruleName).Invoke(parser, null) as IParseTree;
        }

        /// <summary>
        /// 해당 노드의 룰 이름이 맞는지 확인합니다..
        /// </summary>
        /// <param name="ruleName">그래마의 룰 이름.</param>
        /// <param name="tree">해당 노드 오브젝트.</param>
        /// <returns>룰 이름 매칭 여부.</returns>
        public static bool IsMatchedContext(string ruleName, IParseTree tree)
        {
            return tree.GetType().Name.Equals(ruleName + "context", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 해당 노드의 차일드 노드를 가져옵니다.
        /// </summary>
        /// <param name="childRuleName">차일드 노드 이름.</param>
        /// <param name="tree">해당 노드 오브젝트.</param>
        /// <returns>차일드 노드 오브젝트.</returns>
        public static IParseTree GetChildContext(string childRuleName, IParseTree tree)
		{
            return tree.GetType().GetMethod(childRuleName).Invoke(tree, null) as IParseTree;
		}

        /// <summary>
        /// 해당 노드의 차일드 노르를 확인하고 가져옵니다.
        /// </summary>
        /// <param name="childRuleName">차일드 노드 이름.</param>
        /// <param name="tree">해당 노드 오브젝트.</param>
        /// <param name="matchedTree">차일드 노드 오브젝트.</param>
        /// <returns>차일드 노드 존재 여부.</returns>
        public static bool TryChildContext(string childRuleName, IParseTree tree, out IParseTree matchedTree)
		{
            MethodInfo info = tree.GetType().GetMethod(childRuleName);

			bool isExist = info != null;
			matchedTree = isExist ? info.Invoke(tree, null) as IParseTree : null;

            return isExist;
        }

        #endregion
    }
}
