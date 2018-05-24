using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToolService
{
   public class CodeTemplate : BaseData
    {
        /// <summary>
        /// 模板ID
        /// </summary>
        public int CodeTemplateId { set; get; }
        /// <summary>
        /// 模板名字
        /// </summary>
        public String Name { set; get; }
        /// <summary>
        /// 模板内容
        /// </summary>
       public String Content { set; get; }
        /// <summary>
        /// 包或者命名空间名
        /// </summary>
        public String SpaceName { set; get; }
        /// <summary>
        /// 编程语言
        /// </summary>
        public CodeLanaguage Language { set; get; }
        /// <summary>
        /// 模板生成代码类型
        /// </summary>
        public CodeType GenCodeType { set; get; }
    }
}
