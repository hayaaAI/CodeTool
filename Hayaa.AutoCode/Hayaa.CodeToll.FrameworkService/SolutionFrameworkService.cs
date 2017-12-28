using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToll.FrameworkService
{
    /// <summary>
    /// 架构代码实现服务接口
    /// </summary>
  public  interface SolutionFrameworkService
    {
        /// <summary>
        /// 生成解决方案代码
        /// </summary>
        /// <returns></returns>
        FunctionResult<Solution> MakeCodeSolution();
    }
}
