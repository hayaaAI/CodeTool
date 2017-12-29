namespace Hayaa.CodeToolService
{
    /// <summary>
    /// 函数输出数据
    /// </summary>
    public class CodeFunctioOutput
    {
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