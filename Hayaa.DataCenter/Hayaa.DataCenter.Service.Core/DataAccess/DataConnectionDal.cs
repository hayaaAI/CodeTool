using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.DataCenter.Service.Config;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.DataCenter.Service.Dao
{
    internal partial class DataConnectionDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection(DefineTable.DatabaseName);
        internal static int Add(DataConnection info, bool isReturn = true)
        {
            string sql = null; if (isReturn)
            {
                sql = "insert into DataConnection(DatabaseName,DatabaseUser,DatabaseToken,Name,Title,Remark) values(@DatabaseName,@DatabaseUser,@DatabaseToken,@Name,@Title,@Remark);select @@IDENTITY;";
                return InsertWithReturnID<DataConnection, int>(con, sql, info);
            }
            else
            {
                sql = "insert into DataConnection(DatabaseName,DatabaseUser,DatabaseToken,Name,Title,Remark) values(@DatabaseName,@DatabaseUser,@DatabaseToken,@Name,@Title,@Remark);";
                return Insert<DataConnection>(con, sql, info);
            }
        }
        internal static int Update(DataConnection info)
        {
            string sql = "update DataConnection set DatabaseName=@DatabaseName,DatabaseUser=@DatabaseUser,DatabaseToken=@DatabaseToken,Name=@Name,Title=@Title,Remark=@Remark where DataConnectionId=@DataConnectionId";
            return Update<DataConnection>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  DataConnection where DataConnectionId in @ids";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
        internal static DataConnection Get(int Id)
        {
            string sql = "select * from DataConnection  where DataConnectionId=@DataConnectionId";
            return Get<DataConnection>(con, sql, new { DataConnectionId = Id });
        }
        internal static List<DataConnection> GetList(DataConnectionSearchPamater pamater)
        {
            string sql = "select * from DataConnection " + pamater.CreateWhereSql();
            return GetList<DataConnection>(con, sql, pamater);
        }
        internal static GridPager<DataConnection> GetGridPager(GridPagerPamater<DataConnectionSearchPamater> pamater)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from DataConnection " + pamater.SearchPamater.CreateWhereSql() + " limit @Start,@PageSize;select FOUND_ROWS();";
            pamater.SearchPamater.Start = (pamater.Current - 1) * pamater.PageSize;
            pamater.SearchPamater.PageSize = pamater.PageSize;
            return GetGridPager<DataConnection>(con, sql, pamater.PageSize, pamater.Current, pamater.SearchPamater);
        }
    }
}