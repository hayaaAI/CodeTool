using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ModelService
{
    /// <summary>
    /// 数据范围
    /// 虽然没有强制约束，但是只限于使用与int等基础数值类型
    /// </summary>
   public class DataRang<T> 
    {
        /// <summary>
        /// 最大数值
        /// </summary>
        public T MaxVal { set; get; }
        /// <summary>
        /// 最小数值
        /// </summary>
        public T MinVal { set; get; }
    }
}
