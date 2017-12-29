namespace Hayaa.CodeToolService
{
    /// <summary>
    /// 服务数据容器类属性
    /// </summary>
    public class ServiceDataProperty
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
        public string DataType { set; get; }
        /// <summary>
        /// 字段说明
        /// </summary>
        public string Remark { set; get; }
    }
}