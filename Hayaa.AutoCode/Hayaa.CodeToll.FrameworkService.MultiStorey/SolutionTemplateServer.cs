using System.Collections.Generic;
using Hayaa.BaseModel;
using Hayaa.CodeToolService;
using Hayaa.CodeTool.FrameworkService.Dao;
using Hayaa.CodeTool.FrameworkService;

namespace Hayaa.CodeTool.FrameworkService.MultiStorey
{
    public partial class SolutionTemplateServer : SolutionTemplateService
    {
        public FunctionResult<SolutionTemplate> Create(SolutionTemplate info)
        {
            var r = new FunctionResult<SolutionTemplate>(); int id = SolutionTemplateDal.Add(info); if (id > 0) { r.Data = info; r.Data.SolutionTemplateId = id; }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(SolutionTemplate info) { var r = new FunctionOpenResult<bool>(); r.Data = SolutionTemplateDal.Update(info) > 0; return r; }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList) { var r = new FunctionOpenResult<bool>(); r.Data = SolutionTemplateDal.Delete(idList); return r; }
        public FunctionResult<SolutionTemplate> Get(int Id) { var r = new FunctionResult<SolutionTemplate>(); r.Data = SolutionTemplateDal.Get(Id); return r; }
        public FunctionListResult<SolutionTemplate> GetList(SolutionTemplateSearchPamater pamater) { var r = new FunctionListResult<SolutionTemplate>(); r.Data = SolutionTemplateDal.GetList(pamater); return r; }
        public GridPager<SolutionTemplate> GetPager(GridPagerPamater<SolutionTemplateSearchPamater> searchParam) { var r = SolutionTemplateDal.GetGridPager(searchParam); return r;
        }

        public FunctionResult<CodeTemplate> CreateCodeTemplate(CodeTemplate info, int solutionTemplateId)
        {
            var r = new FunctionResult<CodeTemplate>();
            int id = CodeTemplateDal.Add(info);
            if (id > 0)
            {
                r.Data = info; r.Data.CodeTemplateId = id;
                Rel_Solution_CodeTemplateDal.Add(new Rel_Solution_CodeTemplate()
                {
                    SolutionTemplateId = solutionTemplateId,
                    CodeTemplateId = id
                });
            }
            return r;
        }

        public FunctionOpenResult<bool> UpdateCodeTemplateByID(CodeTemplate info)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = CodeTemplateDal.Update(info) > 0;
            return r;
        }

        public FunctionOpenResult<bool> DeleteCodeTemplateByID(List<int> idList)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = CodeTemplateDal.Delete(idList);
            return r;
        }

        public FunctionResult<CodeTemplate> GetCodeTemplate(int Id)
        {
            var r = new FunctionResult<CodeTemplate>();
            r.Data = CodeTemplateDal.Get(Id);
            return r;
        }

        public FunctionResult<SolutionTemplate> GetWithCodeTemplatesBySolutionTemplateId(int Id)
        {
            FunctionResult<SolutionTemplate> r = Get(Id);
            if (r.ActionResult && r.HavingData)
            {
                r.Data.SolutionTemplates = CodeTemplateDal.GetListBySolutionTemplateId(Id);
            }
            return r;
        }
    }
}