using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToolService
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
        /// <summary>
        /// MsSql
        /// </summary>
        Nchar,
        /// <summary>
        /// MsSql
        /// </summary>
        NvarChar,
        /// <summary>
        /// MsSql
        /// </summary>
        Ntext,
        Text,
        /// <summary>
        /// Mariadb
        /// </summary>
        LongText,
        /// <summary>
        /// MsSql
        /// </summary>
        Money,
    }
}
