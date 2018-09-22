using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
namespace Hayaa.CodeTool.Service.Model
{
    public class DataConnection : BaseData
    {
        public int DataConnectionId { set; get; }
        public String DatabaseName { set; get; }
        public String DatabaseUser { set; get; }
        public String DatabaseToken { set; get; }
        public String Name { set; get; }
        public String Title { set; get; }
        public String Remark { set; get; }
    }
}