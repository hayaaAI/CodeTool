﻿using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.CodeTool.Service.Model;
using Hayaa.CodeTool.Service.Dao;

namespace Hayaa.CodeTool.Service.Core
{
    public partial class DataConnectionServer : IDataConnectionService
    {
        public FunctionResult<DataConnection> Create(DataConnection info)
        {
            var r = new FunctionResult<DataConnection>(); int id = DataConnectionDal.Add(info); if (id > 0) { r.Data = info; r.Data.DataConnectionId = id; }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(DataConnection info) { var r = new FunctionOpenResult<bool>(); r.Data = DataConnectionDal.Update(info) > 0; return r; }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList) { var r = new FunctionOpenResult<bool>(); r.Data = DataConnectionDal.Delete(idList); return r; }
        public FunctionResult<DataConnection> Get(int Id) { var r = new FunctionResult<DataConnection>(); r.Data = DataConnectionDal.Get(Id); return r; }
        public FunctionListResult<DataConnection> GetList(DataConnectionSearchPamater pamater) { var r = new FunctionListResult<DataConnection>(); r.Data = DataConnectionDal.GetList(pamater); return r; }
        public GridPager<DataConnection> GetPager(GridPagerPamater<DataConnectionSearchPamater> searchParam) { var r = DataConnectionDal.GetGridPager(searchParam); return r; }
    }
}