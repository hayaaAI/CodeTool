using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.CodeTool.FrameworkService.Config;
using Hayaa.CodeToolService;


namespace Hayaa.CodeTool.FrameworkService.Dao
{
    internal partial class CodeTemplateDal
    {
       
        internal static List<CodeTemplate> GetListBySolutionTemplateId(int solutionTemplateId)
        {
            string sql = "select ct.* from CodeTemplate as ct inner join Rel_Solution_CodeTemplate rsct on ct.CodeTemplateId=rsct.CodeTemplateId where SolutionTemplateId=@SolutionTemplateId";
            return GetList<CodeTemplate>(con, sql, new { SolutionTemplateId = solutionTemplateId });
        }
       
    }
}