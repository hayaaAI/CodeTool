using Hayaa.CodeTool.FrameworkService.MultiStorey;
using Hayaa.CodeTool.FrameworkService;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Cors;
using Hayaa.BaseModel.Model;
using Hayaa.BaseModel;
using Hayaa.CodeToolService;
using System.Collections.Generic;

namespace Hayaa.AutoCodeController
{
    [Route("api/[controller]/[action]")]
    public class SolutionTemplateController: Controller
    {
        private SolutionTemplateService solutionTemplateService = new SolutionTemplateServer();
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<GridPager<SolutionTemplate>> GetPager(int page, int size)
        {
            TransactionResult<GridPager<SolutionTemplate>> result = new TransactionResult<GridPager<SolutionTemplate>>();
            var serviceResult = solutionTemplateService.GetPager(new BaseModel.GridPagerPamater<SolutionTemplateSearchPamater>()
            {
                Current = page,
                PageSize = size,
                SearchPamater = new SolutionTemplateSearchPamater() {  }
            });
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<SolutionTemplate> Get(int id)
        {
            TransactionResult<SolutionTemplate> result = new TransactionResult<SolutionTemplate>();
            var serviceResult = solutionTemplateService.GetWithCodeTemplatesBySolutionTemplateId(id);
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<SolutionTemplate> Add(SolutionTemplate info)
        {
            TransactionResult<SolutionTemplate> result = new TransactionResult<SolutionTemplate>();

            var serviceResult = solutionTemplateService.Create(info);

            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<Boolean> Edit(SolutionTemplate info)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = solutionTemplateService.UpdateByID(info);
            if (serviceResult.ActionResult)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<Boolean> Delete(int id)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = solutionTemplateService.DeleteByID(new List<int>() { id });
            if (serviceResult.ActionResult)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<CodeTemplate> AddCodeTemplate(CodeTemplate info,int solutionTemplateId)
        {
            TransactionResult<CodeTemplate> result = new TransactionResult<CodeTemplate>();

            var serviceResult = solutionTemplateService.CreateCodeTemplate(info, solutionTemplateId);

            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<Boolean> EditCodeTemplate(CodeTemplate info)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = solutionTemplateService.UpdateCodeTemplateByID(info);
            if (serviceResult.ActionResult)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<Boolean> DeleteCodeTemplate(int id)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = solutionTemplateService.DeleteCodeTemplateByID(new List<int>() { id });
            if (serviceResult.ActionResult)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
    }
}
