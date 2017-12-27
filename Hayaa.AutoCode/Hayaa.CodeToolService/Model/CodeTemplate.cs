using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToolService
{
   public class CodeTemplate
    {
        /// <summary>
        /// 模板ID
        /// </summary>
        public int CodeTemplateID { set; get; }
        /// <summary>
        /// 模板名字
        /// </summary>
        public String Name { set; get; }
        /// <summary>
        /// 模板内容
        /// </summary>
       public String Content { set; get; }
        /// <summary>
        /// 编程语言
        /// </summary>
        public CodeLanaguage Language { set; get; }
    }
}
