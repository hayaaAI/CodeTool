using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeTool.Service
{
    /// <summary>
    /// 数据库数据类型
    /// </summary>
    public enum DatabaseDataType
    {
        TinyInt,
        Int,
        BigInt,
        Decimal,
        Float,
        Double,
        Bit,
        Date,
        Time,
        Datetime,
        Timestamp,
        Year,
        Char,
        VarChar,
        Text,
        /// <summary>
        /// MsSql
        /// </summary>
        Nchar_MsSql,
        /// <summary>
        /// MsSql
        /// </summary>
        NvarChar_MsSql,
        /// <summary>
        /// MsSql
        /// </summary>
        Ntext_MsSql,
        /// <summary>
        /// MsSql
        /// </summary>
        Money_MsSql,
        /// <summary>
        /// Mariadb
        /// </summary>
        LongText_Mariadb,

    }
    public class DatabaseDataTypeEnumMapStatic
    {
        public static readonly Dictionary<String, DatabaseDataType> Map = new Dictionary<string, DatabaseDataType>() {
            {"bigint", DatabaseDataType.BigInt},
            {"bit",DatabaseDataType.Bit },
            {"char",DatabaseDataType.Char },
            {"date",DatabaseDataType.Date },
            {"datetime",DatabaseDataType.Datetime },
            {"decimal",DatabaseDataType.Decimal },
            {"double",DatabaseDataType.Double },
            {"float",DatabaseDataType.Float },
            {"int",DatabaseDataType.Int },
            {"longtext",DatabaseDataType.LongText_Mariadb },
            {"money",DatabaseDataType.Money_MsSql },
            {"nchar",DatabaseDataType.Nchar_MsSql },
            {"ntext",DatabaseDataType.Ntext_MsSql },
            {"nvarchar",DatabaseDataType.NvarChar_MsSql },
            {"text",DatabaseDataType.Text },
            {"time",DatabaseDataType.Time },
            {"timestamp",DatabaseDataType.Timestamp },
            {"tinyint",DatabaseDataType.TinyInt },
            {"varchar",DatabaseDataType.VarChar },
            {"year",DatabaseDataType.Year }
        };
    }
}
