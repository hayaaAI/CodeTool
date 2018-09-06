using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeTool.Service
{
    /// <summary>
    /// 代码解决方案信息
    /// </summary>
    public class Solution : BaseData
    {
        /// <summary>
        /// 展示信息
        /// </summary>
        public String Title { set; get; }
        /// <summary>
        /// 方案存储路径
        /// 相对路径或者绝对路径
        /// </summary>
        public String SolutionPath { set; get; }
        /// <summary>
        /// 代码库路径
        /// </summary>
        public String RepoUrl { set; get; }
    }
}
