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
        /// <returns>生成代码存信息</returns>
        FunctionResult<Solution> MakeCodeSolution(List<DatabaseTable> model, SolutinTemplate codeTemplate);
        /// <summary>
        /// 生成Dao层代码，保存至指定位置
        /// </summary>
        /// <param name="tables">需要生成代码的表</param>
        /// <param name="codeTemplate">使用的代码模板</param>
        /// <param name="databaseConnection">连接的数据库的连接字符串</param>
        /// <param name="databaseName">数据库名</param>
        /// <param name="savePath">代码文件保存路径</param>
        /// <returns>生成代码存信息</returns>
        FunctionResult<Solution> MakeCodeForDao(List<String> tables, CodeTemplate codeTemplate,String databaseConnection,String databaseName,String savePath);
        /// <summary>
        /// 生成model代码，保存至指定位置
        /// </summary>
        /// <param name="tables">需要生成代码的表</param>
        /// <param name="codeTemplate">使用的代码模板</param>
        /// <param name="databaseConnection">连接的数据库的连接字符串</param>
        /// <param name="databaseName">数据库名</param>
        /// <param name="savePath">代码文件保存路径</param>
        /// <returns>生成代码存信息</returns>
        FunctionResult<Solution> MakeCodeForModel(List<String> tables, CodeTemplate codeTemplate, String databaseConnection, String databaseName, String savePath);
      
    }
}
