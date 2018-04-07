using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
using Hayaa.CodeToolService;
using Hayaa.CodeTool.FrameworkService;
using Hayaa.CodeTool.FrameworkService.Dao;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.CodeToll.FrameworkService.MultiStorey.Dao
{
    internal partial class CodeTemplateServer 
    {
       
        public FunctionListResult<CodeTemplate> GetList(CodeTemplateSearchPamater pamater) { var r = new FunctionListResult<CodeTemplate>(); r.Data = CodeTemplateDal.GetList(pamater); return r; }
        public GridPager<CodeTemplate> GetPager(GridPagerPamater<CodeTemplateSearchPamater> searchParam) { var r = CodeTemplateDal.GetGridPager(searchParam); return r; }
    }
}