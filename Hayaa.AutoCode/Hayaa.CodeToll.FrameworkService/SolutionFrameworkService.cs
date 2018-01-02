using Hayaa.BaseModel;
using Hayaa.CodeToolService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeTool.FrameworkService
{
    /// <summary>
    /// 架构代码实现服务接口
    /// </summary>
  public  interface SolutionFrameworkService
    {
        /// <summary>
        /// 生成解决方案代码
        /// 传统数据库模型
        /// </summary>
        /// <param name="codeTemplate">代码模板</param>
        /// <param name="model">数据模型</param>
        /// <returns></returns>
        FunctionResult<Solution> MakeCodeSolution(List<DatabaseModel> model, SolutinTemplate codeTemplate);
       
    }
}
