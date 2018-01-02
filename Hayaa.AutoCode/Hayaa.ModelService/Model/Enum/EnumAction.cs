namespace Hayaa.ModelService
{
    /// <summary>
    /// 行为输出类型
    /// </summary>
    public enum ActionOutPutType
    {
        /// <summary>
        /// 复合体
        /// </summary>
        UNION,
        /// <summary>
        /// 一个整体
        /// </summary>
        WHOLE
    }
    /// <summary>
    /// 行为输入类型
    /// </summary>
    public enum ActionInPutType
    {
        /// <summary>
        /// 非类参数，按照基础数据类型产生输入参数列表
        /// </summary>
        DATATYPE,
        /// <summary>
        /// 复合体
        /// </summary>
        UNION,
        /// <summary>
        /// 一个整体
        /// </summary>
        WHOLE
    }
}