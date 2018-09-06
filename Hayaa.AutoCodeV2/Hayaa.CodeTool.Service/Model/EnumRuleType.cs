using System;
namespace Hayaa.CodeTool.Service
{
    /// <summary>
    /// 模型数据属性约束规则类型
    /// </summary>
    [Flags]
    public enum ModelPropeprtyRuleType
    {
        /// <summary>
        /// 数据范围
        /// </summary>
        Rang = 1,
        /// <summary>
        /// 空检查
        /// </summary>
        NullOrEmpty = 2,
        /// <summary>
        /// 正则规则
        /// </summary>
        Regex = 4,

    }
}