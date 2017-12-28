using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToolService.FrameworkService
{
    /// <summary>
    /// 解决方案架构
    /// </summary>
   public class SolutionFramework
    {
        /// <summary>
        /// 展示名称
        /// </summary>
        public string Title { set; get; }
        /// <summary>
        /// 架构编码名称，不要宽字符
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 插件名称
        /// </summary>
        public string PlusName { set; get; }
        /// <summary>
        /// 插件文件名称，不包括路径
        /// </summary>
        public string PlusFile { set; get; }
    }
}
