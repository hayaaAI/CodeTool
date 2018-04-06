using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.CodeTool.FrameworkService.Config;
using Hayaa.CodeToolService;


namespace Hayaa.CodeTool.FrameworkService.Dao
{
    public class CodeTemplateDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection(DefineTable.DatabaseName);
        internal static int Add(CodeTemplate info)
        {
            string sql = "insert into CodeTemplate(Name,Content,SpaceName,Language,GenCodeType) values(@Name,@Content,@SpaceName,@Language,@GenCodeType)";
            return Insert<CodeTemplate>(con, sql, info);
        }
        internal static int Update(CodeTemplate info)
        {
            string sql = "update CodeTemplate set Name=@Name,Content=@Content,SpaceName=@SpaceName,Language=@Language,GenCodeType=@GenCodeType where CodeTemplateId=@CodeTemplateId";
            return Insert<CodeTemplate>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  CodeTemplate where CodeTemplateId in(@ids)";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
        internal static CodeTemplate Get(int Id)
        {
            string sql = "select * from CodeTemplate  where CodeTemplateId=@CodeTemplateId";
            return Get<CodeTemplate>(con, sql, new { CodeTemplateId = Id });
        }
        internal static List<CodeTemplate> GetList(CodeTemplateSearchPamater pamater)
        {
            string sql = "select * from CodeTemplate " + pamater.CreateWhereSql();
            return GetList<CodeTemplate>(con, sql, pamater);
        }
        internal static GridPager<CodeTemplate> GetGridPager(GridPagerPamater<CodeTemplateSearchPamater> pamater)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from CodeTemplate " + pamater.SearchPamater.CreateWhereSql() + " limit @Start,*@PageSize;select FOUND_ROWS();";
            pamater.SearchPamater.Start = (pamater.Current - 1) * pamater.PageSize;
            pamater.SearchPamater.PageSize = pamater.PageSize;
            return GetGridPager<CodeTemplate>(con, sql, pamater.PageSize, pamater.Current, pamater.SearchPamater);
        }
    }
}