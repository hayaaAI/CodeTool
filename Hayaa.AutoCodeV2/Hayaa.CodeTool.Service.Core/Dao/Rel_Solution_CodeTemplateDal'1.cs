using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeTool.FrameworkService.Dao
{
   partial class Rel_Solution_CodeTemplateDal
    {
        internal static bool DeleteByCodeTemplateId(List<int> IDs)
        {
            string sql = "delete from  Rel_Solution_CodeTemplate where CodeTemplateId in(@ids)";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
    }
}
