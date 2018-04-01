using Hayaa.BaseModel;
using Hayaa.CodeToll.FrameworkService.MultiStorey.Dao;
using Hayaa.CodeTool.FrameworkService;
using Hayaa.CodeToolService;
using Hayaa.ModelService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hayaa.CodeToll.FrameworkService.MultiStorey
{
    public class SolutionFrameworkServer : SolutionFrameworkService
    {


        public FunctionResult<Solution> MakeCodeSolution(List<DatabaseTable> model, SolutinTemplate codeTemplate)
        {
            FunctionResult<Solution> result = new FunctionResult<Solution>();
            if (codeTemplate.SolutinTemplates != null)
            {
                codeTemplate.SolutinTemplates.ForEach(t =>
                {
                    //获取返回结果代码段
                    //替换检查与断言标签
                    //数据业务实现
                });
            }
            return result;
        }
        /// <summary>
        /// 生成断言代码片段
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string CreateAssertCode(DatabaseTable model)
        {
            StringBuilder code = new StringBuilder();
            if (model.Fileds != null)
            {
                model.Fileds.ForEach(f =>
                {
                    switch (f.CheckRule.RuleType)
                    {
                        case ModelPropeprtyRuleType.NullOrEmpty:
                            switch (f.DataType)
                            {
                                case DatabaseDataType.Char:
                                case DatabaseDataType.LongText_Mariadb:
                                case DatabaseDataType.Nchar_MsSql:
                                case DatabaseDataType.Ntext_MsSql:
                                case DatabaseDataType.NvarChar_MsSql:
                                case DatabaseDataType.Text:
                                case DatabaseDataType.VarChar:
                                default:
                                    code.Append(string.Format("AssertHelper.AssertStringNullorEmpty(var{0}.{1});\n", model.Name, f.Name));
                                    break;
                            }
                            break;
                        case ModelPropeprtyRuleType.Rang:
                            switch (f.DataType)
                            {
                                #region 日期
                                case DatabaseDataType.Year:
                                    code.Append(string.Format("AssertHelper.AssertRangDateTime(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal));
                                    break;
                                case DatabaseDataType.Time:
                                    code.Append(string.Format("AssertHelper.AssertRangDateTime(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal));
                                    break;
                                case DatabaseDataType.Timestamp:
                                    code.Append(string.Format("AssertHelper.AssertRangDateTime(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal));
                                    break;
                                case DatabaseDataType.Date:
                                    code.Append(string.Format("AssertHelper.AssertRangDateTime(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal));
                                    break;
                                case DatabaseDataType.Datetime:
                                    code.Append(string.Format("AssertHelper.AssertRangDateTime(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal));
                                    break;
                                #endregion
                                #region bigdata
                                case DatabaseDataType.Decimal:
                                    code.Append(string.Format("AssertHelper.AssertRangDecimal(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getDecimalRang().MinVal, f.CheckRule.getDecimalRang().MaxVal));
                                    break;
                                case DatabaseDataType.Money_MsSql:
                                    code.Append(string.Format("AssertHelper.AssertRangDecimal(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getDecimalRang().MinVal, f.CheckRule.getDecimalRang().MaxVal));
                                    break;
                                case DatabaseDataType.Double:
                                    code.Append(string.Format("AssertHelper.AssertRangDouble(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getDoubleRang().MinVal, f.CheckRule.getDoubleRang().MaxVal));
                                    break;
                                case DatabaseDataType.Float:
                                    code.Append(string.Format("AssertHelper.AssertRangFloat(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getFloatRang().MinVal, f.CheckRule.getFloatRang().MaxVal));
                                    break;
                                #endregion
                                #region 整型
                                case DatabaseDataType.Int:
                                    code.Append(string.Format("AssertHelper.AssertRangInt(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getIntRang().MinVal, f.CheckRule.getIntRang().MaxVal));
                                    break;
                                case DatabaseDataType.BigInt:
                                    code.Append(string.Format("AssertHelper.AssertRangLong(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getLongRang().MinVal, f.CheckRule.getLongRang().MaxVal));
                                    break;
                                case DatabaseDataType.TinyInt:
                                    code.Append(string.Format("AssertHelper.AssertRangByte(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getByteRang().MinVal, f.CheckRule.getByteRang().MaxVal));
                                    break;
                                    #endregion
                            }
                            break;
                        case ModelPropeprtyRuleType.Regex:
                            code.Append(string.Format("AssertHelper.AssertRegex(var{0}.{1},{2});\n", model.Name, f.Name, f.CheckRule.RegexRule));
                            break;
                    }
                });
            }
            return code.ToString();
        }
        /// <summary>
        /// 生成代码检查片段
        /// </summary>
        /// <param name="model"></param>
        /// <param name="resultResultCode">需要返回的结果类型对象代码</param>
        /// <returns></returns>
        private string CreateCheckCode(DatabaseTable model, String returnTypeCode)
        {
            StringBuilder code = new StringBuilder();
            if (model.Fileds != null)
            {
                model.Fileds.ForEach(f =>
                {
                    switch (f.CheckRule.RuleType)
                    {
                        case ModelPropeprtyRuleType.NullOrEmpty:
                            switch (f.DataType)
                            {
                                case DatabaseDataType.Char:
                                case DatabaseDataType.LongText_Mariadb:
                                case DatabaseDataType.Nchar_MsSql:
                                case DatabaseDataType.Ntext_MsSql:
                                case DatabaseDataType.NvarChar_MsSql:
                                case DatabaseDataType.Text:
                                case DatabaseDataType.VarChar:
                                default:
                                    code.Append(string.Format("if(CheckHelper.IsStringNullorEmpty(var{0}.{1})){ return {2}; }\n", model.Name, f.Name, returnTypeCode));
                                    break;
                            }
                            break;
                        case ModelPropeprtyRuleType.Rang:
                            switch (f.DataType)
                            {
                                #region 日期
                                case DatabaseDataType.Year:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDateTime(var{0}.{1},{2},{3})){ return {4}; }\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.Time:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDateTime(var{0}.{1},{2},{3})){ return {4}; }\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.Timestamp:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDateTime(var{0}.{1},{2},{3})){ return {4}; }\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.Date:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDateTime(var{0}.{1},{2},{3})){ return {4}; }\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.Datetime:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDateTime(var{0}.{1},{2},{3})){ return {4}; }\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal, returnTypeCode));
                                    break;
                                #endregion
                                #region bigdata
                                case DatabaseDataType.Decimal:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDecimal(var{0}.{1},{2},{3})){ return {4}; }\n", model.Name, f.Name, f.CheckRule.getDecimalRang().MinVal, f.CheckRule.getDecimalRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.Money_MsSql:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDecimal(var{0}.{1},{2},{3})){ return {4}; }\n", model.Name, f.Name, f.CheckRule.getDecimalRang().MinVal, f.CheckRule.getDecimalRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.Double:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDouble(var{0}.{1},{2},{3})){ return {4}; }\n", model.Name, f.Name, f.CheckRule.getDoubleRang().MinVal, f.CheckRule.getDoubleRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.Float:
                                    code.Append(string.Format("if(!CheckHelper.IsRangFloat(var{0}.{1},{2},{3})){ return {4}; }\n", model.Name, f.Name, f.CheckRule.getFloatRang().MinVal, f.CheckRule.getFloatRang().MaxVal, returnTypeCode));
                                    break;
                                #endregion
                                #region 整型
                                case DatabaseDataType.Int:
                                    code.Append(string.Format("if(!CheckHelper.IsRangInt(var{0}.{1},{2},{3})){ return {4}; }\n", model.Name, f.Name, f.CheckRule.getIntRang().MinVal, f.CheckRule.getIntRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.BigInt:
                                    code.Append(string.Format("if(!CheckHelper.IsRangLong(var{0}.{1},{2},{3})){ return {4}; }\n", model.Name, f.Name, f.CheckRule.getLongRang().MinVal, f.CheckRule.getLongRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.TinyInt:
                                    code.Append(string.Format("if(!CheckHelper.IsRangByte(var{0}.{1},{2},{3})){ return {4}; }\n", model.Name, f.Name, f.CheckRule.getByteRang().MinVal, f.CheckRule.getByteRang().MaxVal, returnTypeCode));
                                    break;
                                    #endregion
                            }
                            break;
                        case ModelPropeprtyRuleType.Regex:
                            code.Append(string.Format("if(!CheckHelper.IsRegex(var{0}.{1},{2})){ return {3}; }\n", model.Name, f.Name, f.CheckRule.RegexRule, returnTypeCode));
                            break;
                    }
                });
            }
            return code.ToString();
        }
        public FunctionResult<Solution> MakeCodeForDao(List<string> tables, CodeTemplate codeTemplate, string databaseConnection, String databaseName, String savePath)
        {
            var result = new FunctionResult<Solution>();
            result.Data = new Solution()
            {
                SolutionPath = savePath
            };
            //返回数据模型
            List<DatabaseTable> list = MariadbDao.GetTables(tables, databaseConnection, databaseName);
            //生成代码
            if (list != null)
            {
                list.ForEach(t =>
                {
                    StringBuilder codeBuilder = new StringBuilder();
                    if (codeTemplate.Language == CodeLanaguage.CSharp)
                    {
                        CreateCSharpDaoCode(t, codeBuilder);
                    }
                    if (codeTemplate.Language == CodeLanaguage.Java)
                    {

                    }
                    BuilderDaoCodeFile(codeTemplate, codeBuilder, savePath, t.Name);
                });
            }
            return result;
        }

      
        #region C#创建Dao
        /// <summary>
        /// 创建C#语言的dao层代码
        /// </summary>
        /// <param name="model">模型数据</param>
        /// <param name="codeBuilder">拼装字符容器</param>
        private void CreateCSharpDaoCode(DatabaseTable model, StringBuilder codeBuilder)
        {
            codeBuilder.Append(String.Format("public class {0}Dal:CommonDal{\n", model.Name));
            codeBuilder.Append(String.Format("private static String con=ConfigHelper.GetCon(\"{0}\");\n", model.Name));
            codeBuilder.Append(String.Format("internal static int Add({0} info){ string sql = \"{1}\";return Insert<{0}>(con,sql, info);}\n", model.Name, CreateInsertSqlForCSharp(model)));
            codeBuilder.Append(String.Format("internal static int Update({0} info){ string sql = \"{1}\";return Insert<{0}>(con,sql, info);}\n", model.Name, CreateUpdateSqlForCSharp(model)));
            codeBuilder.Append(String.Format("internal static bool Delete(List<int> IDs){ string sql = \"delete from  {0} where {0}Id in(@ids)\";return Excute(con,sql, new { ids = IDs.ToArray() }) > 0;}\n", model.Name));
            codeBuilder.Append(String.Format("internal static {0} Get(int Id){ string sql = \"select * from {0}  where {0}Id=@{0}Id\";return Get<{0}>(con,sql,new{ {0}Id=Id });}\n", model.Name));           
            codeBuilder.Append("}");
        }       
        private String CreateUpdateSqlForCSharp(DatabaseTable model)
        {
            String sql = "update {0} set {1} where {0}Id=@{0}Id";
            DatabaseFiled[] arr = null;
            model.Fileds.CopyTo(arr);//防止破坏模型数据
            List<DatabaseFiled> list = arr.ToList();
            list.RemoveAll(a => a.Name == (model.Name + "Id"));//数据库设计规范，主键为表名+Id
            list.RemoveAll(a => a.Name == "CreateTime");//数据库设计规范，每张表必有CreateTime字段
            IEnumerable<String> filedNames = list.Select(x => x.Name=(x.Name+"=@"+ x.Name));
            String fileds = String.Join(",", filedNames);
            sql = String.Format(sql, model.Name, fileds);//传值变量需要满足Dapper的要求变量名和类属性名一致
            return sql;
        }
        private String CreateInsertSqlForCSharp(DatabaseTable model)
        {
            String sql = "insert into {0}({1}) values(@{2})";//由于采用String.Join方法，多出一个@作为",@"分隔符方式的补充
            DatabaseFiled[] arr = null;
            model.Fileds.CopyTo(arr);//防止破坏模型数据
            List<DatabaseFiled> list = arr.ToList();
            list.RemoveAll(a => a.Name == (model.Name + "Id"));//数据库设计规范，主键为表名+Id
            list.RemoveAll(a => a.Name == "ModifyTime");//数据库设计规范，每张表必有ModifyTime字段
            IEnumerable<String> filedNames= list.Select(x => x.Name);
            String fileds = String.Join(",", filedNames);
            sql = String.Format(sql,model.Name, fileds, String.Join(",@",filedNames));//传值变量需要满足Dapper的要求变量名和类属性名一致
            return sql;
        }
        private void BuilderDaoCodeFile(CodeTemplate codeTemplate, StringBuilder codeBuilder, string savePath, string fileName)
        {
            String codeCotent = codeTemplate.Content.Replace("{$#class#$}", codeBuilder.ToString());
            switch (codeTemplate.Language)
            {
                case CodeLanaguage.CSharp:
                    File.AppendAllText(String.Format("{0}/{1}dal.cs", savePath, fileName), codeCotent);
                    break;
                case CodeLanaguage.Java:
                    File.AppendAllText(String.Format("{0}/{1}dal.java", savePath, fileName), codeCotent);
                    break;
            }
        }
        #endregion

        public FunctionResult<Solution> MakeCodeForModel(List<string> tables, CodeTemplate codeTemplate, string databaseConnection, string databaseName, string savePath)
        {
            var result = new FunctionResult<Solution>();
            result.Data = new Solution()
            {
                SolutionPath = savePath
            };
            //返回数据模型
            List<DatabaseTable> list = MariadbDao.GetTables(tables, databaseConnection, databaseName);
            //生成代码
            if (list != null)
            {

                list.ForEach(t =>
                {
                    StringBuilder codeBuilder = new StringBuilder(String.Format("public class {0}{CODE}", t.Name));//构造类整体结构                  
                    if (t.Fileds != null)
                    {
                        StringBuilder propertiesBulider = new StringBuilder();
                        t.Fileds.ForEach(p =>
                        {
                            //根据语言类型区分生成逻辑
                            if (codeTemplate.Language == CodeLanaguage.CSharp)
                            {
                                propertiesBulider.Append(String.Format("public {0} {1}{set;get;}\n", GetCsharpDataType(p.DataType), p.Name));
                            }
                            if (codeTemplate.Language == CodeLanaguage.Java)
                            {
                                String dataType = GetJavaDataType(p.DataType);
                                propertiesBulider.Append(String.Format("private {0} {1};\n", dataType, p.Name));
                                propertiesBulider.Append(String.Format("public {0} set{1}({0} {1}value){ {1}={1}value; }\n", dataType, p.Name));
                                propertiesBulider.Append(String.Format("public {0} get{1}(){ return {1}; }\n", dataType, p.Name));
                            }
                        });
                        codeBuilder = codeBuilder.Replace("CODE", propertiesBulider.ToString());
                    }
                    BuilderModelFile(codeTemplate, codeBuilder, savePath, t.Name);
                });
            }
            return result;
        }

        private void BuilderModelFile(CodeTemplate codeTemplate, StringBuilder codeBuilder, String savePath, String fileName)
        {
            String codeCotent = codeTemplate.Content.Replace("{$#class#$}", codeBuilder.ToString());
            switch (codeTemplate.Language)
            {
                case CodeLanaguage.CSharp:
                    File.AppendAllText(String.Format("{0}/{1}.cs", savePath, fileName), codeCotent);
                    break;
                case CodeLanaguage.Java:
                    File.AppendAllText(String.Format("{0}/{1}.java", savePath, fileName), codeCotent);
                    break;
            }
        }

        private string GetCsharpDataType(DatabaseDataType dataType)
        {
            String result = "String";
            switch (dataType)
            {
                case DatabaseDataType.BigInt:
                    result = "long";
                    break;
                case DatabaseDataType.Bit:
                    result = "bool";
                    break;
                case DatabaseDataType.Char:
                    result = "String";
                    break;
                case DatabaseDataType.Date:
                    result = "DateTime";
                    break;
                case DatabaseDataType.Datetime:
                    result = "DateTime";
                    break;
                case DatabaseDataType.Decimal:
                    result = "decimal";
                    break;
                case DatabaseDataType.Double:
                    result = "double";
                    break;
                case DatabaseDataType.Float:
                    result = "float";
                    break;
                case DatabaseDataType.Int:
                    result = "int";
                    break;
                case DatabaseDataType.LongText_Mariadb:
                    result = "String";
                    break;
                case DatabaseDataType.Money_MsSql:
                    result = "decimal";
                    break;
                case DatabaseDataType.Nchar_MsSql:
                    result = "String";
                    break;
                case DatabaseDataType.Ntext_MsSql:
                    result = "String";
                    break;
                case DatabaseDataType.NvarChar_MsSql:
                    result = "String";
                    break;
                case DatabaseDataType.Text:
                    result = "String";
                    break;
                case DatabaseDataType.Time:
                    result = "DateTime";
                    break;
                case DatabaseDataType.Timestamp:
                    result = "DateTime";
                    break;
                case DatabaseDataType.TinyInt:
                    result = "byte";
                    break;
                case DatabaseDataType.VarChar:
                    result = "String";
                    break;
                case DatabaseDataType.Year:
                    result = "DateTime";
                    break;
                default:
                    break;
            }
            return result;
        }
        private string GetJavaDataType(DatabaseDataType dataType)
        {
            String result = "String";
            switch (dataType)
            {
                case DatabaseDataType.BigInt:
                    result = "BigInteger";
                    break;
                case DatabaseDataType.Bit:
                    result = "Boolean";
                    break;
                case DatabaseDataType.Char:
                    result = "String";
                    break;
                case DatabaseDataType.Date:
                    result = "java.sql.Date";
                    break;
                case DatabaseDataType.Datetime:
                    result = "java.sql.Date";
                    break;
                case DatabaseDataType.Decimal:
                    result = "BigDecimal";
                    break;
                case DatabaseDataType.Double:
                    result = "Double";
                    break;
                case DatabaseDataType.Float:
                    result = "Float";
                    break;
                case DatabaseDataType.Int:
                    result = "Integer";
                    break;
                case DatabaseDataType.LongText_Mariadb:
                    result = "String";
                    break;
                case DatabaseDataType.Money_MsSql:
                    result = "java.math.BigDecimal";
                    break;
                case DatabaseDataType.Nchar_MsSql:
                    result = "String";
                    break;
                case DatabaseDataType.Ntext_MsSql:
                    result = "String";
                    break;
                case DatabaseDataType.NvarChar_MsSql:
                    result = "String";
                    break;
                case DatabaseDataType.Text:
                    result = "String";
                    break;
                case DatabaseDataType.Time:
                    result = "java.sql.Time";
                    break;
                case DatabaseDataType.Timestamp:
                    result = "java.sql.Timestamp";
                    break;
                case DatabaseDataType.TinyInt:
                    result = "Integer";
                    break;
                case DatabaseDataType.VarChar:
                    result = "String";
                    break;
                case DatabaseDataType.Year:
                    result = "java.sql.Date";
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
