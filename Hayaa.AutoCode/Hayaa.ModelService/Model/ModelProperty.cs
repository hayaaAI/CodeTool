using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ModelService
{
    /// <summary>
    /// 业务模型数据属性
    /// </summary>
  public  class ModelProperty:BaseData
    {
        /// <summary>
        /// 属性ID
        /// </summary>
        public int PropertyID { set; get; }
        /// <summary>
        /// 属性名称
        /// </summary>
        public String PropertyName { set; get; }
        /// <summary>
        /// 属性编程名称
        /// 展示为英文名称
        /// 不违反编程语言命名规则即可
        /// </summary>
        public String CodePropertyName { set; get; }
    }
}
