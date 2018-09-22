using Hayaa.BaseModel;
using Hayaa.BaseModel.Model;
using Hayaa.CodeTool.Service;
using Hayaa.CodeTool.Service.Core;
using Hayaa.CodeTool.Service.Model;
using Hayaa.Common;
using Hayaa.CompanyWebSecurity.Client;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeTool.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [UserAuthorityFilter]
    public  class DataConnectionController : ControllerBase
    {
        private IDataConnectionService dataConnectionService = new DataConnectionServer();
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<GridPager<DataConnection>> GetPager([FromForm] int page, [FromForm] int size)
        {
            TransactionResult<GridPager<DataConnection>> result = new TransactionResult<GridPager<DataConnection>>();
            var serviceResult = dataConnectionService.GetPager(new BaseModel.GridPagerPamater<DataConnectionSearchPamater>()
            {
                Current = page,
                PageSize = size,
                SearchPamater = new DataConnectionSearchPamater() { }
            });
            if (serviceResult.ActionResult)
            {
                if (serviceResult.HavingData)
                    result.Data = serviceResult;
                else
                    result.Data = new GridPager<DataConnection>() { Data = new List<DataConnection>() };
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
        public TransactionResult<DataConnection> Get([FromForm] int id)
        {
            TransactionResult<DataConnection> result = new TransactionResult<DataConnection>();
            var serviceResult = dataConnectionService.Get(id);
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
        public TransactionResult<DataConnection> Add([FromForm] DataConnection info)
        {
            TransactionResult<DataConnection> result = new TransactionResult<DataConnection>();

            var serviceResult = dataConnectionService.Create(info);

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
        public TransactionResult<Boolean> Edit([FromForm] DataConnection info)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = dataConnectionService.UpdateByID(info);
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
            var serviceResult = dataConnectionService.DeleteByID(new List<int>() { id });
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
    }
}
