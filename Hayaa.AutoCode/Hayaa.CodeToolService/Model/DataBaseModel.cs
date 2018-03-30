using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToolService
{
    /// <summary>
    /// 数据库模型
    /// </summary>
  public  class DatabaseTable
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
        /// 模型拥有的数据属性字段
        /// </summary>
        public List<DatabaseFiled> Fileds { set; get; }
        /// <summary>
        /// 模型说明
        /// </summary>
        public String Remark { set; get; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseType DatabaseType { set; get; }
    }
}
