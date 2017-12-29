using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToolService
{
    /// <summary>
    /// 函数内参数与输出数据关系
    /// </summary>
  public  class CodeFunctionDataRelation
    {
        /// <summary>
        /// 输出数据名
        /// </summary>
        public String OutputName { set; get; }
        /// <summary>
        /// 参数
        /// </summary>
        public List<String> ParamaterNames { set; get; }
        /// <summary>
        /// 数据关系
        /// </summary>
        public CodeFunctionDataRelationType RelationtType { set; get; }
        /// <summary>
        /// 数据过程媒介
        /// 类.函数名
        /// 公式代码模板
        /// 转换代码模板
        /// </summary>
        public String Medium { set; get; }
    }
}
