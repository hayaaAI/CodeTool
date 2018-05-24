using Hayaa.ModelService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToolService
{
    /// <summary>
    /// 项目信息
    /// 单一语言型项目
    /// </summary>
   public class Project
    {
        
        /// <summary>
        /// 项目名称
        /// </summary>
        public String Name { set; get; }
        /// <summary>
        /// 项目使用的逻辑模型
        /// </summary>
        public List<BussinessModel> ProjectModelData { set; get; }
        /// <summary>
        /// 代码输出目录
        /// </summary>
        public String CodeOutputPath { set; get; }
    }
}
