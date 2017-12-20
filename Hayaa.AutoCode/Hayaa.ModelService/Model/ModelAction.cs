using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeTool.Service
{
    /// <summary>
    /// 模型行为
    /// </summary>
   public class ModelAction:BaseData
    {
        /// <summary>
        /// 行为ID
        /// </summary>
        public int ActionID { set; get; }
        /// <summary>
        /// 行为名称
        /// </summary>
        public String ActionName { set; get; }
        /// <summary>
        /// 行为编程名称
        /// 不违反编程语言命名规则即可
        /// </summary>
        public String Code_ActionName { set; get; }
    }
}
