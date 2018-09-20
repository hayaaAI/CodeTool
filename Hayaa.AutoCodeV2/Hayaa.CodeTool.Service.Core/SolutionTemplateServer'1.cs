using Hayaa.BaseModel;
using Hayaa.CodeTool.FrameworkService;
using Hayaa.CodeTool.FrameworkService.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeTool.Service.Core
{
  public partial  class SolutionTemplateServer
    {
        public FunctionOpenResult<bool> DeleteCodeTemplateByID(List<int> idList)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = (CodeTemplateDal.Delete(idList)&&           Rel_Solution_CodeTemplateDal.DeleteByCodeTemplateId(idList));
            return r;
        }
    }
}
