using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.CodeToolService;
using Hayaa.DataAccess;

namespace Hayaa.CodeTool.FrameworkService.MultiStorey.Dao
{
    /// <summary>
    /// Mariadb数据库数据通道逻辑
    /// </summary>
    class MariadbDao : CommonDal
    {
        internal static List<DatabaseTable> GetTables(List<string> tables, string databaseConnection, String databaseName)
        {
            List<DatabaseTable> result = null;
            if (tables != null)
            {
                String sql = "select column_name,data_type,column_comment from information_schema.columns where table_schema='" + databaseName + "' and table_name='{0}';";
                result = new List<DatabaseTable>();
                tables.ForEach(table =>
                {
                    List<MariadbColumn> columnList = GetList<MariadbColumn>(databaseConnection, String.Format(sql, table), null);
                    if (columnList != null)
                    {
                        DatabaseTable dt = new DatabaseTable();
                        dt.Name = table;
                        dt.Fileds = new List<DatabaseFiled>();
                        columnList.ForEach(c =>
                        {
                            dt.Fileds.Add(new DatabaseFiled()
                            {
                                CheckRule = null,
                                DataType = getDataType(c.data_type),
                                Name = c.column_name,
                                Remark = c.column_comment,
                                Title = c.column_name
                            });
                        });
                        result.Add(dt);
                    }
                });
            }
            return result;
        }

        private static DatabaseDataType getDataType(string dataType)
        {
            if (DatabaseDataTypeEnumMapStatic.Map.ContainsKey(dataType))
            {
                return DatabaseDataTypeEnumMapStatic.Map[dataType];
            }
            return DatabaseDataType.VarChar;
        }

        private class MariadbColumn
        {
            public String column_name { set; get; }
            public String data_type { set; get; }
            public String column_comment { set; get; }
        }
    }
}
