using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToolService
{
   public enum CodeFunctionDataRelationType
    {
        /// <summary>
        /// 其他函数产出,多对一
        /// </summary>
        Function,
        /// <summary>
        /// 直接赋值，一对一
        /// </summary>
        Evaluate,
        /// <summary>
        /// 公式计算,多对一
        /// </summary>
        Formula,
        /// <summary>
        /// 转换赋值，一对一
        /// </summary>
        ParseEvaluate
    }
}
