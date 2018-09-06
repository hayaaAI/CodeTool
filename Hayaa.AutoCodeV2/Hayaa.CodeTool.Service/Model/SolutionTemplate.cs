using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeTool.Service
{
    /// <summary>
    /// 解决方案模板
    /// </summary>
    public class SolutionTemplate : BaseData
    {
        public int SolutionTemplateId { set; get; }
        public String Name { set; get; }
        /// <summary>
        /// 展示信息
        /// </summary>
        public String Title { set; get; }
        /// <summary>
        /// 解决方案模板
        /// </summary>
        public List<CodeTemplate> SolutionTemplates { set; get; }
        /// <summary>
        /// 模板类型检查
        /// 是否有重复类型模板
        /// true表示没有false表示有重复类型模板
        /// </summary>

        public Boolean TemplateTypeCheck
        {
            get
            {
                Boolean templateTypeCheck = true;
                if (this.SolutionTemplates != null)
                {

                    Dictionary<CodeType, int> countor = new Dictionary<CodeType, int>();
                    foreach (var a in this.SolutionTemplates)
                    {
                        if (countor.ContainsKey(a.GenCodeType)) return false;
                        else countor.Add(a.GenCodeType, 1);
                    }
                }
                return templateTypeCheck;
            }
        }
    }
}
