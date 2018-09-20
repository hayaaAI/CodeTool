
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Cors;
using Hayaa.BaseModel.Model;
using Hayaa.BaseModel;

using System.Collections.Generic;

using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.IO.Compression;
using Hayaa.CodeTool.Service.Core;
using Hayaa.CodeTool.Service;
using Hayaa.CompanyWebSecurity.Client;
using Hayaa.Common;

namespace Hayaa.CodeTool.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [UserAuthorityFilter]
    public class SolutionTemplateController: ControllerBase
    {
        private ISolutionTemplateService solutionTemplateService = new SolutionTemplateServer();
        private ISolutionFrameworkService solutionFrameworkService = new SolutionFrameworkServer();
        private readonly IHostingEnvironment _hostingEnvironment;

        public SolutionTemplateController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<GridPager<SolutionTemplate>> GetPager([FromForm] int page, [FromForm] int size)
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
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]     
        [EnableCors("any")]
        public TransactionResult<SolutionTemplate> Get([FromForm] int id)
        {
            TransactionResult<SolutionTemplate> result = new TransactionResult<SolutionTemplate>();
            var serviceResult = solutionTemplateService.Get(id);
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<SolutionTemplate> Add([FromForm] SolutionTemplate info)
        {
            TransactionResult<SolutionTemplate> result = new TransactionResult<SolutionTemplate>();

            var serviceResult = solutionTemplateService.Create(info);

            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]      
        [EnableCors("any")]
        public TransactionResult<Boolean> Edit([FromForm] SolutionTemplate info)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = solutionTemplateService.UpdateByID(info);
            if (serviceResult.ActionResult)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<Boolean> Delete([FromForm] int id)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = solutionTemplateService.DeleteByID(new List<int>() { id });
            if (serviceResult.ActionResult)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<CodeTemplate> AddCodeTemplate([FromForm] CodeTemplate info, [FromForm] int solutionTemplateId)
        {
            TransactionResult<CodeTemplate> result = new TransactionResult<CodeTemplate>();

            var serviceResult = solutionTemplateService.CreateCodeTemplate(info, solutionTemplateId);

            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<Boolean> EditCodeTemplate([FromForm] CodeTemplate info)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = solutionTemplateService.UpdateCodeTemplateByID(info);
            if (serviceResult.ActionResult)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<Boolean> DeleteCodeTemplate([FromForm] int id)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = solutionTemplateService.DeleteCodeTemplateByID(new List<int>() { id });
            if (serviceResult.ActionResult)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<CodeTemplate> GetCodeTemplate([FromForm] int id)
        {
            TransactionResult<CodeTemplate> result = new TransactionResult<CodeTemplate>();

            var serviceResult = solutionTemplateService.GetCodeTemplate(id);

            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<List<CodeTemplate>> GetCodeTemplateList([FromForm] int solutionTemplateId)
        {
            TransactionResult<List<CodeTemplate>> result = new TransactionResult<List<CodeTemplate>>();

            var serviceResult = solutionTemplateService.GetWithCodeTemplatesBySolutionTemplateId(solutionTemplateId);

            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data.SolutionTemplates;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<Solution> GenCode([FromForm] GenCodeInfo info)
        {
            TransactionResult<Solution> result = new TransactionResult<Solution>();
            info.CodeStorePath = _hostingEnvironment.WebRootPath + "/Code/SourceCode";
            try {
                Directory.Delete(info.CodeStorePath,true);
                System.IO.File.Delete(_hostingEnvironment.WebRootPath + "/Code/Code.zip");
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(info.CodeStorePath);
            Directory.CreateDirectory(info.CodeStorePath);
            var solutionResult=  solutionTemplateService.GetWithCodeTemplatesBySolutionTemplateId(info.SolutionId);
            if (!(solutionResult.ActionResult && solutionResult.HavingData))
            {
                result.Code = ErrorCode.NoData;
                result.Message = "无方案模板数据";
                return result;
            }
            var serviceResult = solutionFrameworkService.MakeCodeForMultiStoreySolution(info.Tables, solutionResult.Data,info.DatabaseConnection,info.DatabaseName,info.CodeStorePath);
            if (serviceResult.ActionResult)
            {
                ZipFile.CreateFromDirectory(info.CodeStorePath, _hostingEnvironment.WebRootPath + "/Code/Code.zip");
                serviceResult.Data.SolutionPath = "Code/Code.zip";
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
    }
}
