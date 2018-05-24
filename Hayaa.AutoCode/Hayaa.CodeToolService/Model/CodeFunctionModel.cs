using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToolService
{
    /// <summary>
    /// 代码函数类
    /// </summary>
   public class CodeFunctionModel
    {       
        /// <summary>
        /// 行为名称
        /// </summary>
        public String ActionName { set; get; }
        /// <summary>
        /// 函数注释      
        /// </summary>
        public String Remark { set; get; }
        /// <summary>
        /// 函数输入参数
        /// </summary>
        public List<CodeFunctioInput> InputPamarater { set; get; }      
        /// <summary>
        /// 函数输出结果
        /// </summary>
        public List<CodeFunctioOutput> OutPutData { set; get; }
        /// <summary>
        /// 数据逻辑关系
        /// </summary>
        public List<CodeFunctionDataRelation> DataRelation { set; get; }
        /// <summary>
        /// 函数代码模板
        /// </summary>
        public String CodeTemplate { set; get; }
        /// <summary>
        /// 数据输出类名
        /// </summary>
        public string OutputClass { set; get; }
    }
}
