using Hayaa.BaseModel;
using Hayaa.CodeTool.FrameworkService;
using Hayaa.CodeToolService;
using Hayaa.ModelService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToll.FrameworkService.MultiStorey
{
    public class SolutionFrameworkServer : SolutionFrameworkService
    {
       
        public FunctionResult<Solution> MakeCodeSolution(List<DatabaseModel> model, SolutinTemplate codeTemplate)
        {
            FunctionResult<Solution> result = new FunctionResult<Solution>();
            if (codeTemplate.SolutinTemplates != null)
            {
                codeTemplate.SolutinTemplates.ForEach(t =>
                {
                    //替换检查与断言标签
                });
            } 
            return result;
        }
        /// <summary>
        /// 生成断言代码片段
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string CreateAssertCode(DatabaseModel model)
        {
            StringBuilder code = new StringBuilder();

            return code.ToString();
        }
        /// <summary>
        /// 生成代码检查片段
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string CreateCheckCode(DatabaseModel model)
        {
            StringBuilder code = new StringBuilder();
            if (model.Fileds != null)
            {
                model.Fileds.ForEach(f =>
                {
                    switch (f.CheckRule.RuleType)
                    {
                        case ModelPropeprtyRuleType.NullOrEmpty:
                            switch (f.DataType)
                            {
                                case DatabaseDataType.Char:
                                case DatabaseDataType.LongText:
                                case DatabaseDataType.Nchar:
                                case DatabaseDataType.Ntext:
                                case DatabaseDataType.NvarChar:
                                case DatabaseDataType.Text:
                                case DatabaseDataType.VarChar:
                                    code.Append(string.Format("AssertHelper.AssertStringNullorEmpty()"));
                                    break;
                            }
                            break;
                        case ModelPropeprtyRuleType.Rang:
                            break;
                        case ModelPropeprtyRuleType.Regex:
                            break;
                    }
                });
            }
            return code.ToString();
        }
       
    }
}
 