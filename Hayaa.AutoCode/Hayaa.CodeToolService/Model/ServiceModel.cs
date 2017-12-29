using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToolService
{
    /// <summary>
    /// 服务数据容器类模型
    /// </summary>
    public class ServiceDataModel
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
        public List<ServiceDataProperty> Fileds { set; get; }
        /// <summary>
        /// 模型说明
        /// </summary>
        public String Remark { set; get; }
    }
}
