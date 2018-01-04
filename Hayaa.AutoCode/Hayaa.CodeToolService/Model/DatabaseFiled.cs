using Hayaa.ModelService;

namespace Hayaa.CodeToolService
{
    /// <summary>
    /// 数据库模型字段
    /// </summary>
    public class DatabaseFiled
    {
        /// <summary>
        /// 展示名称
        /// </summary>
        public string Title { set; get; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 字段基础数据类型
        /// </summary>
        public DatabaseDataType DataType { set; get; }
        /// <summary>
        /// 字段说明
        /// </summary>
        public string Remark { set; get; }
        /// <summary>
        /// 数据约束规则
        /// </summary>
        public ModelPropeprtyRule CheckRule { set; get; }
    }
}