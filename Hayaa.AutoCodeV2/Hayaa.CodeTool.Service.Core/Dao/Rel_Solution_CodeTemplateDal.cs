using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.CodeTool.FrameworkService.Config;
using Hayaa.CodeTool.Service;
using Hayaa.CodeTool.Service.Core;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.CodeTool.FrameworkService.Dao
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Rel_Solution_CodeTemplateDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection(DefineTable.DatabaseName);
        internal static int Add(Rel_Solution_CodeTemplate info)
        {
            string sql = "insert into Rel_Solution_CodeTemplate(Id,SolutionTemplateId,CodeTemplateId) values(@Id,@SolutionTemplateId,@CodeTemplateId)";
            return Insert<Rel_Solution_CodeTemplate>(con, sql, info);
        }
        internal static int Update(Rel_Solution_CodeTemplate info)
        {
            string sql = "update Rel_Solution_CodeTemplate set Id=@Id,SolutionTemplateId=@SolutionTemplateId,CodeTemplateId=@CodeTemplateId where Rel_Solution_CodeTemplateId=@Rel_Solution_CodeTemplateId";
            return Insert<Rel_Solution_CodeTemplate>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  Rel_Solution_CodeTemplate where Rel_Solution_CodeTemplateId in(@ids)";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
        internal static Rel_Solution_CodeTemplate Get(int Id)
        {
            string sql = "select * from Rel_Solution_CodeTemplate  where Rel_Solution_CodeTemplateId=@Rel_Solution_CodeTemplateId";
            return Get<Rel_Solution_CodeTemplate>(con, sql, new { Rel_Solution_CodeTemplateId = Id });
        }
        internal static List<Rel_Solution_CodeTemplate> GetList(Rel_Solution_CodeTemplateSearchPamater pamater)
        {
            string sql = "select * from Rel_Solution_CodeTemplate " + pamater.CreateWhereSql();
            return GetList<Rel_Solution_CodeTemplate>(con, sql, pamater);
        }
        internal static GridPager<Rel_Solution_CodeTemplate> GetGridPager(GridPagerPamater<Rel_Solution_CodeTemplateSearchPamater> pamater)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from Rel_Solution_CodeTemplate " + pamater.SearchPamater.CreateWhereSql() + " limit @Start,*@PageSize;select FOUND_ROWS();";
            pamater.SearchPamater.Start = (pamater.Current - 1) * pamater.PageSize;
            pamater.SearchPamater.PageSize = pamater.PageSize;
            return GetGridPager<Rel_Solution_CodeTemplate>(con, sql, pamater.PageSize, pamater.Current, pamater.SearchPamater);
        }
    }
}