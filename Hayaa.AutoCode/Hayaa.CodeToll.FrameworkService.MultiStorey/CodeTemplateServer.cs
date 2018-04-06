using Hayaa.BaseModel;
using Hayaa.CodeTool.FrameworkService;
using Hayaa.CodeTool.FrameworkService.Dao;
using Hayaa.CodeToolService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToll.FrameworkService.MultiStorey
{
    public class CodeTemplateServer : CodeTemplateService
    {
        public FunctionResult<CodeTemplate> Create(CodeTemplate info)
        {
            var r = new FunctionResult<CodeTemplate>();
            int id = CodeTemplateDal.Add(info);
            if (id > 0)
            {
                r.Data = info;
                r.Data.CodeTemplateId = id;
            }
            return r;

        }
        public FunctionOpenResult<bool> UpdateByID(CodeTemplate info)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = CodeTemplateDal.Update(info) > 0;
            return r;
        }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = CodeTemplateDal.Delete(idList);
            return r;
        }

        public GridPager<CodeTemplate> GetPager(GridPagerPamater<CodeTemplateSearchPamater> searchParam)
        {
            var r = CodeTemplateDal.GetGridPager(searchParam);
            return r;
        }

     
    }
}
