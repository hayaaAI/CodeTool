using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeTool.Service
{
    /// <summary>
    /// 业务模型
    /// </summary>
   public class BussinessModel:BaseData
    {
        /// <summary>
        /// 业务模型ID      
        /// </summary>
        public int ModelID { set; get; }
        /// <summary>
        /// 模型名称
        /// </summary>
        public String ModelName { set; get; }
        /// <summary>
        /// 模型编程名称
        /// 不违反编程语言命名规则即可
        /// </summary>
        public String Code_ModelName { set; get; }
        /// <summary>
        /// 模型备注
        /// </summary>
        public String ModelRemark { set; get; }
        /// <summary>
        /// 数据属性
        /// </summary>
        public List<ModelProperty> Properties { set; get; }
        /// <summary>
        /// 模型行为
        /// </summary>
        public List<ModelAction> Actions { set; get; }
    }
}
