using System;
using System.Collections.Generic;
using Hayaa.DataAccess;


namespace Hayaa.CodeTool.Service.Core.Dao
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
                                CheckRule = GetCheckRule(getDataType(c.data_type)),
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

        private static ModelPropeprtyRule GetCheckRule(DatabaseDataType databaseDataType)
        {
            ModelPropeprtyRule result = null;
            switch (databaseDataType)
            {
                case DatabaseDataType.BigInt:
                    result = new ModelPropeprtyRule(new DataRang<long>() { MaxVal=long.MaxValue,MinVal=long.MinValue });
                    break;
                case DatabaseDataType.Bit:
                    result = new ModelPropeprtyRule();
                    break;
                case DatabaseDataType.Char:
                    result = new ModelPropeprtyRule();
                    break;
                case DatabaseDataType.Date:
                    result = new ModelPropeprtyRule(new DataRang<DateTime>());
                    break;
                case DatabaseDataType.Datetime:
                    result = new ModelPropeprtyRule(new DataRang<DateTime>());
                    break;
                case DatabaseDataType.Decimal:
                    result = new ModelPropeprtyRule(new DataRang<decimal>() { MaxVal = decimal.MaxValue, MinVal = decimal.MinValue });
                    break;
                case DatabaseDataType.Double:
                    result = new ModelPropeprtyRule(new DataRang<double>() { MaxVal = double.MaxValue, MinVal = double.MinValue });
                    break;
                case DatabaseDataType.Float:
                    result = new ModelPropeprtyRule(new DataRang<float>() { MaxVal = float.MaxValue, MinVal = float.MinValue });
                    break;
                case DatabaseDataType.Int:
                    result = new ModelPropeprtyRule(new DataRang<int>() { MaxVal = int.MaxValue, MinVal = int.MinValue });
                    break;
                case DatabaseDataType.LongText_Mariadb:
                    result = new ModelPropeprtyRule();
                    break;
                case DatabaseDataType.Money_MsSql:
                    result = new ModelPropeprtyRule(new DataRang<decimal>() { MaxVal = decimal.MaxValue, MinVal = decimal.MinValue });
                    break;
                case DatabaseDataType.Nchar_MsSql:
                    result = new ModelPropeprtyRule();
                    break;
                case DatabaseDataType.Ntext_MsSql:
                    result = new ModelPropeprtyRule();
                    break;
                case DatabaseDataType.NvarChar_MsSql:
                    result = new ModelPropeprtyRule();
                    break;
                case DatabaseDataType.Text:
                    result = new ModelPropeprtyRule();
                    break;
                case DatabaseDataType.Time:
                    result = new ModelPropeprtyRule(new DataRang<DateTime>());
                    break;
                case DatabaseDataType.Timestamp:
                    result = new ModelPropeprtyRule(new DataRang<DateTime>());
                    break;
                case DatabaseDataType.TinyInt:
                    result = new ModelPropeprtyRule(new DataRang<byte>() { MaxVal = byte.MaxValue, MinVal = byte.MinValue });
                    break;
                case DatabaseDataType.VarChar:
                    result = new ModelPropeprtyRule();
                    break;
                case DatabaseDataType.Year:
                    result = new ModelPropeprtyRule(new DataRang<DateTime>());
                    break;
                default:
                    result = new ModelPropeprtyRule();
                    break;
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
