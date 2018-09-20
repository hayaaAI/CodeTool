using Hayaa.BaseModel;
using Hayaa.BaseModel.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeTool.Service
{
  public  interface ISolutionTemplateService : IBaseService<SolutionTemplate, SolutionTemplateSearchPamater>
    {
        FunctionResult<CodeTemplate> CreateCodeTemplate(CodeTemplate info, int SolutionTemplateId);
        FunctionOpenResult<bool> UpdateCodeTemplateByID(CodeTemplate info);
        FunctionOpenResult<bool> DeleteCodeTemplateByID(List<int> idList);
        FunctionResult<CodeTemplate> GetCodeTemplate(int Id);
        FunctionResult<SolutionTemplate> GetWithCodeTemplatesBySolutionTemplateId(int Id);
    }
}
