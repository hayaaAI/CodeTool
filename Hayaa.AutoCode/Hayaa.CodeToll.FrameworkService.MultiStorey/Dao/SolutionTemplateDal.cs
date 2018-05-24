using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.CodeTool.FrameworkService.Config;
using Hayaa.CodeToolService;
/// <summary>///代码效率工具生成，此文件不要修改/// </summary>
namespace Hayaa.CodeTool.FrameworkService.Dao
{
    public partial class SolutionTemplateDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection(DefineTable.DatabaseName);
        internal static int Add(SolutionTemplate info)
        {
            string sql = "insert into SolutionTemplate(Name,Title) values(@Name,@Title)";
            return Insert<SolutionTemplate>(con, sql, info);
        }
        internal static int Update(SolutionTemplate info)
        {
            string sql = "update SolutionTemplate set Name=@Name,Title=@Title where SolutionTemplateId=@SolutionTemplateId";
            return Insert<SolutionTemplate>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  SolutionTemplate where SolutionTemplateId in(@ids)";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
        internal static SolutionTemplate Get(int Id)
        {
            string sql = "select * from SolutionTemplate  where SolutionTemplateId=@SolutionTemplateId";
            return Get<SolutionTemplate>(con, sql, new { SolutionTemplateId = Id });
        }
        internal static List<SolutionTemplate> GetList(SolutionTemplateSearchPamater pamater)
        {
            string sql = "select * from SolutionTemplate " + pamater.CreateWhereSql();
            return GetList<SolutionTemplate>(con, sql, pamater);
        }
        internal static GridPager<SolutionTemplate> GetGridPager(GridPagerPamater<SolutionTemplateSearchPamater> pamater)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from SolutionTemplate " + pamater.SearchPamater.CreateWhereSql() + " limit @Start,@PageSize;select FOUND_ROWS();";
            pamater.SearchPamater.Start = (pamater.Current - 1) * pamater.PageSize;
            pamater.SearchPamater.PageSize = pamater.PageSize;
            return GetGridPager<SolutionTemplate>(con, sql, pamater.PageSize, pamater.Current, pamater.SearchPamater);
        }
    }
}