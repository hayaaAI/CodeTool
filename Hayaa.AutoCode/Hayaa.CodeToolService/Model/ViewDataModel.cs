using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToolService
{
    /// <summary>
    /// 展示数据模型类
    /// </summary>
   public class ViewDataModel
    {
        /// <summary>
        /// 模型展示名
        /// </summary>
        public String Title { set; get; }
        /// <summary>
        /// 模型名称
        /// </summary>
        public String Name { set; get; }
        /// <summary>
        /// 模型拥有的数据属性
        /// </summary>
        public List<ViewDataProperty> Fileds { set; get; }
        /// <summary>
        /// 模型说明
        /// </summary>
        public String Remark { set; get; }
    }
}
