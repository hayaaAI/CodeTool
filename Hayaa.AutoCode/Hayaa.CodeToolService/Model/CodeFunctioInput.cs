namespace Hayaa.CodeToolService
{
    /// <summary>
    /// 函数输入参数
    /// </summary>
    public class CodeFunctioInput
    {
        /// <summary>
        /// 数据所属类
        /// 同一个类的数据参数要聚合
        /// </summary>
        public string ClassName { set; get; }
        /// <summary>
        /// 展示名称
        /// </summary>
        public string Title { set; get; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 参数数据类型
        /// </summary>
        public string DataType { set; get; }
        /// <summary>
        /// 参数说明
        /// </summary>
        public string Remark { set; get; }
    }
}