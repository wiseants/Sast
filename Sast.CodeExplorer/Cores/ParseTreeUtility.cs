﻿using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;

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
        /// 해당 노드에 그래마에 정의된 룰이름으로 된 자식노드가 있는지 확인합니다.
        /// </summary>
        /// <param name="ruleName">그래마의 룰 이름.</param>
        /// <param name="tree">해당 노드 오브젝트.</param>
        /// <returns>참:자식노드 있음, 거짓:자식노드 없음.</returns>
        public static bool IsMatchedContext(string ruleName, IParseTree tree)
        {
            return tree.GetType().Name.Equals(ruleName + "context", StringComparison.OrdinalIgnoreCase);
        }

        #endregion
    }
}