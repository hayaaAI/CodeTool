using Hayaa.CodeTool.FrameworkService.MultiStorey;
using Hayaa.CodeTool.FrameworkService;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Cors;
using Hayaa.BaseModel.Model;
using Hayaa.BaseModel;
using Hayaa.CodeToolService;
using System.Collections.Generic;
using Hayaa.AutoCodeController.Model;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.IO.Compression;
using Hayaa.WorkerSecurity.Client;

namespace Hayaa.AutoCodeController
{
    [Route("api/[controller]/[action]")]
    [UserAuthorityFilter]
    public class SolutionTemplateController: Controller
    {
        private SolutionTemplateService solutionTemplateService = new SolutionTemplateServer();
        private SolutionFrameworkService solutionFrameworkService = new SolutionFrameworkServer();
        private readonly IHostingEnvironment _hostingEnvironment;

        public SolutionTemplateController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

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
            var serviceResult = solutionTemplateService.Get(id);
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
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<CodeTemplate> GetCodeTemplate( int id)
        {
            TransactionResult<CodeTemplate> result = new TransactionResult<CodeTemplate>();

            var serviceResult = solutionTemplateService.GetCodeTemplate(id);

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
        public TransactionResult<List<CodeTemplate>> GetCodeTemplateList(int solutionTemplateId)
        {
            TransactionResult<List<CodeTemplate>> result = new TransactionResult<List<CodeTemplate>>();

            var serviceResult = solutionTemplateService.GetWithCodeTemplatesBySolutionTemplateId(solutionTemplateId);

            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data.SolutionTemplates;
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
        public TransactionResult<Solution> GenCode(GenCodeInfo info)
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
                result.Code = 103;
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
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
    }
}
