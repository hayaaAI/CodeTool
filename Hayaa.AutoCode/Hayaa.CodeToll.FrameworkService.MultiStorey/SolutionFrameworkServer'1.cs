using Hayaa.CodeToolService;
using Hayaa.ModelService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hayaa.CodeTool.FrameworkService.MultiStorey
{
    public partial class SolutionFrameworkServer
    {

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
        private string CreateAssertCodeForJava(DatabaseTable model)
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
                                    code.Append(string.Format("AssertHelper.AssertStringNullorEmpty(info.get{0}());\n",f.Name));
                                    break;
                            }
                            break;
                        case ModelPropeprtyRuleType.Rang:
                            switch (f.DataType)
                            {
                                #region 日期
                                case DatabaseDataType.Year:
                                    code.Append(string.Format("AssertHelper.AssertNull(info.get{0}());\n", f.Name));
                                    break;
                                case DatabaseDataType.Time:
                                    code.Append(string.Format("AssertHelper.AssertNull(info.get{0}());\n", f.Name));
                                    break;
                                case DatabaseDataType.Timestamp:
                                    code.Append(string.Format("AssertHelper.AssertNull(info.get{0}());\n", f.Name));
                                    break;
                                case DatabaseDataType.Date:
                                    code.Append(string.Format("AssertHelper.AssertNull(info.get{0}());\n", f.Name));
                                    break;
                                case DatabaseDataType.Datetime:
                                    code.Append(string.Format("AssertHelper.AssertNull(info.get{0}());\n", f.Name));
                                    break;
                                #endregion
                                #region bigdata
                                case DatabaseDataType.Decimal:
                                   // code.Append(string.Format("AssertHelper.AssertRangDecimal(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getDecimalRang().MinVal, f.CheckRule.getDecimalRang().MaxVal));
                                    break;
                                case DatabaseDataType.Money_MsSql:
                                   // code.Append(string.Format("AssertHelper.AssertRangDecimal(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getDecimalRang().MinVal, f.CheckRule.getDecimalRang().MaxVal));
                                    break;
                                case DatabaseDataType.Double:
                                    code.Append(string.Format("AssertHelper.AssertRangDouble(info.get{0}(),Double.MIN_VALUE,Double.MAX_VALUE);\n", f.Name));
                                    break;
                                case DatabaseDataType.Float:
                                    code.Append(string.Format("AssertHelper.AssertRangFloat(info.get{0}(),Float.MIN_VALUE,Float.MAX_VALUE);\n", f.Name));
                                    break;
                                #endregion
                                #region 整型
                                case DatabaseDataType.Int:
                                    code.Append(string.Format("AssertHelper.AssertRangInt(info.get{0}(),Integer.MIN_VALUE,Integer.MAX_VALUE);\n", f.Name));
                                    break;
                                case DatabaseDataType.BigInt:
                                    code.Append(string.Format("AssertHelper.AssertRangLong(info.get{0}(),Integer.MIN_VALUE,Integer.MAX_VALUE);\n", f.Name));
                                    break;
                                case DatabaseDataType.TinyInt:
                                   // code.Append(string.Format("AssertHelper.AssertRangByte(var{0}.{1},{2},{3});\n", model.Name, f.Name, f.CheckRule.getByteRang().MinVal, f.CheckRule.getByteRang().MaxVal));
                                    break;
                                    #endregion
                            }
                            break;
                        case ModelPropeprtyRuleType.Regex:
                           // code.Append(string.Format("AssertHelper.AssertRegex(var{0}.{1},{2});\n", model.Name, f.Name, f.CheckRule.RegexRule));
                            break;
                    }
                });
            }
            return code.ToString();
        }
        private static StringBuilder CreateForJava(DatabaseTable t)
        {
            String lname = ParseName(t.Name);
            StringBuilder codeBuilder = new StringBuilder(String.Format("@Service(\"{1}Service\")public class {0}Service implements I{0}Service{{ ", t.Name, lname));//构造原型类整体结构
            codeBuilder.Append(String.Format("@Autowired private {0}Mapper {1}Mapper;", t.Name, lname));
            codeBuilder.Append(String.Format("@Override public FunctionResult<{0}> Create({0} info){{FunctionResult<{0}> r = new FunctionResult<{0}>();{1}Mapper.insert(info);if (info.get{0}Id() > 0){{r.setData(info);}}return r;}} ", t.Name, lname));
            codeBuilder.Append(String.Format("@Override public FunctionOpenResult<Boolean> UpdateByID({0} info){{FunctionOpenResult<Boolean> r = new FunctionOpenResult<Boolean>();r.setData({1}Mapper.update(info));return r;}} ", t.Name, lname));
            codeBuilder.Append(String.Format("@Override public FunctionOpenResult<Boolean> DeleteByID(List<Integer> list) {{FunctionOpenResult<Boolean> r=new FunctionOpenResult<Boolean>();String ids=list.toString().replace(\"[\",\"\").replace(\"]\",\"\");r.setData({1}Mapper.delete(ids));return r;}} ", t.Name, lname));
            codeBuilder.Append(String.Format("@Override public GridPager<{0}> GetPager(GridPagerPamater<{0}SearchPamater> gridPagerPamater) {{  PageHelper.orderBy(\"{0}Id desc\");Page pageInfo=PageHelper.startPage(gridPagerPamater.getCurrent(), gridPagerPamater.getPageSize());List<{0}>  dalResult={1}Mapper.getList(gridPagerPamater.getSearchPamater());GridPager<{0}> r=new GridPager<>(gridPagerPamater.getCurrent(),gridPagerPamater.getPageSize()); r.setData(dalResult); r.setTotal((int)pageInfo.getTotal());return r;}} ", t.Name, lname));
            codeBuilder.Append(String.Format("@Override public FunctionResult<{0}> Get(int id) {{FunctionResult<{0}> r=new FunctionResult<{0}>();r.setData({1}Mapper.get(id));return r;}}\n", t.Name, lname));
            codeBuilder.Append(String.Format("@Override public FunctionListResult<{0}> GetList({0}SearchPamater searchPamater) {{FunctionListResult<{0}> r=new FunctionListResult<{0}>();r.setData({1}Mapper.getList(searchPamater));return r;}}", t.Name, lname));
            codeBuilder.Append("}");
            return codeBuilder;
        }

        private static String ParseName(string name)
        {
            var temp = name.ToLower().Substring(0, 1);
            name = name.Remove(0, 1);
            return temp + name;
        }

        private static StringBuilder CreateForCSharp(DatabaseTable t)
        {
            StringBuilder codeBuilder = new StringBuilder(String.Format("public partial  class {0}Server:{0}Service{{\n", t.Name));//构造原型类整体结构
                                                                                                                                   //Create
            codeBuilder.Append(String.Format("public FunctionResult<{0}> Create({0} info){{var r = new FunctionResult<{0}>();int id = {0}Dal.Add(info);if (id > 0){{r.Data = info;r.Data.{0}Id = id;}}\nreturn r;}}", t.Name));
            //Update
            codeBuilder.Append(String.Format(" public FunctionOpenResult<bool> UpdateByID({0} info){{var r = new FunctionOpenResult<bool>();r.Data = {0}Dal.Update(info) > 0;return r;}}", t.Name));
            //Delete
            codeBuilder.Append(String.Format(" public FunctionOpenResult<bool> DeleteByID(List<int> idList){{var r = new FunctionOpenResult<bool>();r.Data = {0}Dal.Delete(idList);return r;}}", t.Name));
            //Get
            codeBuilder.Append(String.Format("public FunctionResult<{0}> Get(int Id){{var r = new FunctionResult<{0}>();r.Data = {0}Dal.Get(Id);return r;}}", t.Name));
            //GetList
            codeBuilder.Append(String.Format("public FunctionListResult<{0}> GetList({0}SearchPamater pamater){{var r = new FunctionListResult<{0}>();r.Data = {0}Dal.GetList(pamater);return r;}}", t.Name));
            //GetPager
            codeBuilder.Append(String.Format(" public GridPager<{0}> GetPager(GridPagerPamater<{0}SearchPamater> searchParam){{ var r ={0}Dal.GetGridPager(searchParam);return r;}}", t.Name));
            codeBuilder.Append("}");
            return codeBuilder;
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
                                    code.Append(string.Format("if(CheckHelper.IsStringNullorEmpty(var{0}.{1})){{ return {2}; }}\n", model.Name, f.Name, returnTypeCode));
                                    break;
                            }
                            break;
                        case ModelPropeprtyRuleType.Rang:
                            switch (f.DataType)
                            {
                                #region 日期
                                case DatabaseDataType.Year:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDateTime(var{0}.{1},{2},{3})){{ return {4}; }}\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.Time:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDateTime(var{0}.{1},{2},{3})){{ return {4};}}\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.Timestamp:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDateTime(var{0}.{1},{2},{3})){{ return {4};}}\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.Date:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDateTime(var{0}.{1},{2},{3})){{ return {4};}}\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.Datetime:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDateTime(var{0}.{1},{2},{3})){{ return {4};}}\n", model.Name, f.Name, f.CheckRule.getDateTimeRang().MinVal, f.CheckRule.getDateTimeRang().MaxVal, returnTypeCode));
                                    break;
                                #endregion
                                #region bigdata
                                case DatabaseDataType.Decimal:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDecimal(var{0}.{1},{2},{3})){{ return {4};}}\n", model.Name, f.Name, f.CheckRule.getDecimalRang().MinVal, f.CheckRule.getDecimalRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.Money_MsSql:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDecimal(var{0}.{1},{2},{3})){{return {4};}}\n", model.Name, f.Name, f.CheckRule.getDecimalRang().MinVal, f.CheckRule.getDecimalRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.Double:
                                    code.Append(string.Format("if(!CheckHelper.IsRangDouble(var{0}.{1},{2},{3})){{return {4};}}\n", model.Name, f.Name, f.CheckRule.getDoubleRang().MinVal, f.CheckRule.getDoubleRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.Float:
                                    code.Append(string.Format("if(!CheckHelper.IsRangFloat(var{0}.{1},{2},{3})){{return {4};}}\n", model.Name, f.Name, f.CheckRule.getFloatRang().MinVal, f.CheckRule.getFloatRang().MaxVal, returnTypeCode));
                                    break;
                                #endregion
                                #region 整型
                                case DatabaseDataType.Int:
                                    code.Append(string.Format("if(!CheckHelper.IsRangInt(var{0}.{1},{2},{3})){{return {4};}}\n", model.Name, f.Name, f.CheckRule.getIntRang().MinVal, f.CheckRule.getIntRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.BigInt:
                                    code.Append(string.Format("if(!CheckHelper.IsRangLong(var{0}.{1},{2},{3})){{return {4};}}\n", model.Name, f.Name, f.CheckRule.getLongRang().MinVal, f.CheckRule.getLongRang().MaxVal, returnTypeCode));
                                    break;
                                case DatabaseDataType.TinyInt:
                                    code.Append(string.Format("if(!CheckHelper.IsRangByte(var{0}.{1},{2},{3})){{return {4};}}\n", model.Name, f.Name, f.CheckRule.getByteRang().MinVal, f.CheckRule.getByteRang().MaxVal, returnTypeCode));
                                    break;
                                    #endregion
                            }
                            break;
                        case ModelPropeprtyRuleType.Regex:
                            code.Append(string.Format("if(!CheckHelper.IsRegex(var{0}.{1},{2})){{return {3};}}\n", model.Name, f.Name, f.CheckRule.RegexRule, returnTypeCode));
                            break;
                    }
                });
            }
            return code.ToString();
        }
        private void BuilderMybatisXmlFile(StringBuilder codeBuilder, string savePath, string modelName)
        {          
                    Encoding utf8NoBom = new UTF8Encoding(false);
                    File.AppendAllText(String.Format("{0}/{1}Mapper.xml", savePath, modelName), codeBuilder.ToString(), utf8NoBom);
        }

        private void CreateMybatisXml(CodeTemplate codeTemplate, DatabaseTable t, StringBuilder codeBuilder, string databaseName,String modelSpacename)
        {
            codeBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?><!DOCTYPE mapper PUBLIC \" -//mybatis.org//DTD Mapper 3.0//EN\" \"http://mybatis.org/dtd/mybatis-3-mapper.dtd\">");
            codeBuilder.Append(String.Format("<mapper namespace=\"{0}.{1}Mapper\">", codeTemplate.SpaceName, t.Name));
            codeBuilder.Append(String.Format("<select id=\"getList\" resultType=\"{0}.{1}\">", modelSpacename, t.Name));
            codeBuilder.Append(String.Format("select * from {0}", t.Name));
            codeBuilder.Append("<where>");
            for(var i = 0; i < t.Fileds.Count; i++)
            {
                var f = t.Fileds[i];
                if (IsString(f.DataType))
                {
                    codeBuilder.Append(String.Format("<if test=\"searchPamater.{0} != null\"> {1} {0} like \"%\"#{{searchPamater.{0}}}\"%\"</if>", f.Name, (i > 0 ? "AND" : "")));
                }
                else
                {
                    codeBuilder.Append(String.Format("<if test=\"searchPamater.{0} != null\"> {1} {0} = #{{searchPamater.{0}}}</if>", f.Name, (i > 0 ? "AND" : "")));
                    codeBuilder.Append(String.Format("<if test=\"searchPamater.{0}Max != null and searchPamater.{0}Min != null\"> {1} {0} BETWEEN #{{searchPamater.{0}Min}} to #{{searchPamater.{0}Max}}</if>", f.Name, (i > 0 ? "AND" : "")));
                }               
            }
            codeBuilder.Append("</where>");
            codeBuilder.Append("</select>");
            codeBuilder.Append("</mapper>");
        }
        private void CreateJavaDaoCode(DatabaseTable model, StringBuilder codeBuilder, String databaseName)
        {
            codeBuilder.Append(String.Format("@Mapper interface {0}Mapper{{", model.Name));            
            codeBuilder.Append(String.Format(" @Insert(\"{1}\") @Options(useGeneratedKeys = true, keyProperty =\"{2}.{0}Id\") void insert(@Param(\"{2}\") {0} {2});", model.Name, CreateInsertSqlForJava(model),ParseName(model.Name)));
            codeBuilder.Append(String.Format("@Update(\"{1}\") Boolean update(@Param(\"{2}\") {0} {2});", model.Name, CreateUpdateSqlForJava(model),ParseName(model.Name)));
            codeBuilder.Append(String.Format("@Delete(\"delete from {0} where {1}Id in (${{ids}})\") Boolean delete(@Param(\"ids\") String ids);", model.Name, ParseName(model.Name)));
            codeBuilder.Append(String.Format("@Select(\"select * from {0} where {0}Id =#{{Id}}\") {0} get(int Id);", model.Name));
            codeBuilder.Append(String.Format("List<{0}> getList(@Param(\"searchPamater\") {0}SearchPamater searchPamater);", model.Name));
            codeBuilder.Append("}");
        }
        private String CreateInsertSqlForJava(DatabaseTable model)
        {
            String sql = "insert into {0}({1}) values({2});";//由于采用String.Join方法，多出一个@作为",@"分隔符方式的补充
            DatabaseFiled[] arr = new DatabaseFiled[model.Fileds.Count];
            model.Fileds.CopyTo(arr);//防止破坏模型数据
            List<DatabaseFiled> list = arr.ToList();
            list.RemoveAll(a => a.Name == (model.Name + "Id"));//数据库设计规范，主键为表名+Id
            list.RemoveAll(a => a.Name == "CreateTime");//数据库设计规范，每张表必有CreateTime字段并且字段有默认数值
            list.RemoveAll(a => a.Name == "UpdateTime");//数据库设计规范，UpdateTime
            IEnumerable<String> filedNames = list.Select(x => x.Name);
            IEnumerable<String> values = list.Select(x =>("#{"+ParseName(model.Name)+"."+x.Name+"}"));
            String fileds = String.Join(",", filedNames);
            sql = String.Format(sql, model.Name, fileds, String.Join(",", values));//传值变量需要满足mybatis的具名要求变量名和类属性名一致
            return sql;
        }
        private String CreateUpdateSqlForJava(DatabaseTable model)
        {
            String sql = "update {0} set {1} where {0}Id=#{{{2}.{0}Id}}";
            DatabaseFiled[] arr = new DatabaseFiled[model.Fileds.Count];
            model.Fileds.CopyTo(arr);//防止破坏模型数据
            List<DatabaseFiled> list = arr.ToList();
            list.RemoveAll(a => a.Name == (model.Name + "Id"));//数据库设计规范，主键为表名+Id
            list.RemoveAll(a => a.Name == "CreateTime");//数据库设计规范，每张表必有CreateTime字段
            list.RemoveAll(a => a.Name == "UpdateTime");//数据库设计规范，UpdateTime，并且字段有默认时间戳
            IEnumerable<String> filedNames = list.Select(x =>(x.Name + "=#{"+ParseName(model.Name)+"."+ x.Name+"}"));
            String fileds = String.Join(",", filedNames);
            sql = String.Format(sql, model.Name, fileds,ParseName(model.Name));//传值变量需要满足mybatis的具名要求变量名和类属性名一致
            return sql;
        }
        #region C#创建Dao
        /// <summary>
        /// 创建C#语言的dao层代码
        /// </summary>
        /// <param name="model">模型数据</param>
        /// <param name="codeBuilder">拼装字符容器</param>
        private void CreateCSharpDaoCode(DatabaseTable model, StringBuilder codeBuilder, String databaseName)
        {
            codeBuilder.Append(String.Format("internal partial class {0}Dal:CommonDal{{\n", model.Name));
            codeBuilder.Append(String.Format("private static String con= ConfigHelper.Instance.GetConnection(DefineTable.DatabaseName);\n", model.Name));
            codeBuilder.Append(String.Format("internal static int Add({0} info,bool isReturn=true){{\n string sql =null;if(isReturn) {{sql=\"{1}\";\nreturn InsertWithReturnID<{0},int>(con,sql, info);}}else {{sql=\"{2}\";\nreturn Insert<{0}>(con,sql, info);}}\n}}\n", model.Name, CreateInsertSqlForCSharp(model, true), CreateInsertSqlForCSharp(model, false)));
            codeBuilder.Append(String.Format("internal static int Update({0} info){{\n string sql = \"{1}\";\nreturn Update<{0}>(con,sql, info);\n}}\n", model.Name, CreateUpdateSqlForCSharp(model)));
            codeBuilder.Append(String.Format("internal static bool Delete(List<int> IDs){{\n string sql = \"delete from  {0} where {0}Id in @ids\";\nreturn Excute(con,sql, new {{ ids = IDs.ToArray() }}) > 0;\n}}\n", model.Name));
            codeBuilder.Append(String.Format("internal static {0} Get(int Id){{\n string sql = \"select * from {0}  where {0}Id=@{0}Id\";\nreturn Get<{0}>(con,sql,new{{ {0}Id=Id }});\n}}\n", model.Name));
            codeBuilder.Append(String.Format("internal static List<{0}> GetList({0}SearchPamater pamater){{\n string sql = \"select * from {0} \"+pamater.CreateWhereSql();\nreturn GetList<{0}>(con,sql,pamater);\n}}\n", model.Name));
            codeBuilder.Append(String.Format("internal static GridPager<{0}> GetGridPager(GridPagerPamater<{0}SearchPamater> pamater){{\n string sql = \"select SQL_CALC_FOUND_ROWS * from {0} \"+pamater.SearchPamater.CreateWhereSql()+\" limit @Start,@PageSize;select FOUND_ROWS();\";\n pamater.SearchPamater.Start = (pamater.Current-1)* pamater.PageSize;\npamater.SearchPamater.PageSize = pamater.PageSize;\nreturn GetGridPager<{0}>(con,sql, pamater.PageSize, pamater.Current, pamater.SearchPamater);\n}}\n", model.Name));
            codeBuilder.Append("}");
        }

        private String CreateUpdateSqlForCSharp(DatabaseTable model)
        {
            String sql = "update {0} set {1} where {0}Id=@{0}Id";
            DatabaseFiled[] arr = new DatabaseFiled[model.Fileds.Count];
            model.Fileds.CopyTo(arr);//防止破坏模型数据
            List<DatabaseFiled> list = arr.ToList();
            list.RemoveAll(a => a.Name == (model.Name + "Id"));//数据库设计规范，主键为表名+Id
            list.RemoveAll(a => a.Name == "CreateTime");//数据库设计规范，每张表必有CreateTime字段
            list.RemoveAll(a => a.Name == "UpdateTime");//数据库设计规范，UpdateTime，并且字段有默认时间戳
            IEnumerable<String> filedNames = list.Select(x => x.Name = (x.Name + "=@" + x.Name));
            String fileds = String.Join(",", filedNames);
            sql = String.Format(sql, model.Name, fileds);//传值变量需要满足Dapper的要求变量名和类属性名一致
            return sql;
        }
        private String CreateInsertSqlForCSharp(DatabaseTable model, bool isReturnId)
        {
            String sql = "insert into {0}({1}) values(@{2});{3}";//由于采用String.Join方法，多出一个@作为",@"分隔符方式的补充
            DatabaseFiled[] arr = new DatabaseFiled[model.Fileds.Count];
            model.Fileds.CopyTo(arr);//防止破坏模型数据
            List<DatabaseFiled> list = arr.ToList();
            list.RemoveAll(a => a.Name == (model.Name + "Id"));//数据库设计规范，主键为表名+Id
            list.RemoveAll(a => a.Name == "CreateTime");//数据库设计规范，每张表必有CreateTime字段并且字段有默认数值
            list.RemoveAll(a => a.Name == "UpdateTime");//数据库设计规范，UpdateTime
            IEnumerable<String> filedNames = list.Select(x => x.Name);
            String fileds = String.Join(",", filedNames);
            sql = String.Format(sql, model.Name, fileds, String.Join(",@", filedNames), (isReturnId ? "select @@IDENTITY;" : ""));//传值变量需要满足Dapper的要求变量名和类属性名一致
            return sql;
        }
        private void BuilderDaoCodeFile(CodeTemplate codeTemplate, StringBuilder codeBuilder, string savePath, string fileName)
        {
            String codeCotent = codeTemplate.Content.Replace("{$#class#$}", codeBuilder.ToString()).Replace("{$#space#$}", codeTemplate.SpaceName);
            switch (codeTemplate.Language)
            {
                case CodeLanaguage.CSharp:
                    File.AppendAllText(String.Format("{0}/{1}Dal.cs", savePath, fileName), codeCotent, Encoding.UTF8);
                    break;
                case CodeLanaguage.Java:
                    Encoding utf8NoBom = new UTF8Encoding(false);
                    File.AppendAllText(String.Format("{0}/{1}Mapper.java", savePath, fileName), codeCotent, utf8NoBom);
                    break;
            }
        }
        #endregion


        private bool IsString(DatabaseDataType dataType)
        {
            Boolean result = false;
            switch (dataType)
            {
                case DatabaseDataType.Char:
                    result = true;
                    break;
                case DatabaseDataType.LongText_Mariadb:
                    result = true;
                    break;
                case DatabaseDataType.Nchar_MsSql:
                    result = true;
                    break;
                case DatabaseDataType.Ntext_MsSql:
                    result = true;
                    break;
                case DatabaseDataType.NvarChar_MsSql:
                    result = true;
                    break;
                case DatabaseDataType.Text:
                    result = true;
                    break;
                case DatabaseDataType.VarChar:
                    result = true;
                    break;
                default:
                    break;
            }
            return result;
        }

        private void BuilderModelFile(CodeTemplate codeTemplate, StringBuilder codeBuilder, String savePath, String fileName)
        {
            String codeCotent = codeTemplate.Content.Replace("{$#class#$}", codeBuilder.ToString()).Replace("{$#space#$}", codeTemplate.SpaceName);
            switch (codeTemplate.Language)
            {
                case CodeLanaguage.CSharp:
                    File.AppendAllText(String.Format("{0}/{1}.cs", savePath, fileName), codeCotent, Encoding.UTF8);
                    break;
                case CodeLanaguage.Java:
                    Encoding utf8NoBom = new UTF8Encoding(false);
                    File.AppendAllText(String.Format("{0}/{1}.java", savePath, fileName), codeCotent, utf8NoBom);
                    break;
            }
        }
        private void BuilderServiceFile(CodeTemplate codeTemplate, StringBuilder codeBuilder, string savePath, string fileName)
        {
            String codeCotent = codeTemplate.Content.Replace("{$#class#$}", codeBuilder.ToString()).Replace("{$#space#$}", codeTemplate.SpaceName);
            switch (codeTemplate.Language)
            {
                case CodeLanaguage.CSharp:
                    File.AppendAllText(String.Format("{0}/{1}Server.cs", savePath, fileName), codeCotent, Encoding.UTF8);
                    break;
                case CodeLanaguage.Java:
                    Encoding utf8NoBom = new UTF8Encoding(false);
                    File.AppendAllText(String.Format("{0}/{1}Service.java", savePath, fileName), codeCotent, utf8NoBom);
                    break;
            }
        }
        private string GetCsharpDataType(DatabaseDataType dataType, Boolean isNull = false)
        {
            String result = "String";
            switch (dataType)
            {
                case DatabaseDataType.BigInt:
                    result = isNull ? "long?" : "long";
                    break;
                case DatabaseDataType.Bit:
                    result = isNull ? "bool?" : "bool";
                    break;
                case DatabaseDataType.Char:
                    result = "String";
                    break;
                case DatabaseDataType.Date:
                    result = isNull ? "DateTime?" : "DateTime";
                    break;
                case DatabaseDataType.Datetime:
                    result = isNull ? "DateTime?" : "DateTime";
                    break;
                case DatabaseDataType.Decimal:
                    result = isNull ? "decimal?" : "decimal";
                    break;
                case DatabaseDataType.Double:
                    result = isNull ? "double?" : "double";
                    break;
                case DatabaseDataType.Float:
                    result = isNull ? "float?" : "float";
                    break;
                case DatabaseDataType.Int:
                    result = isNull ? "int?" : "int";
                    break;
                case DatabaseDataType.LongText_Mariadb:
                    result = "String";
                    break;
                case DatabaseDataType.Money_MsSql:
                    result = isNull ? "decimal?" : "decimal";
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
                    result = isNull ? "DateTime?" : "DateTime";
                    break;
                case DatabaseDataType.Timestamp:
                    result = isNull ? "DateTime?" : "DateTime";
                    break;
                case DatabaseDataType.TinyInt:
                    result = isNull ? "byte?" : "byte";
                    break;
                case DatabaseDataType.VarChar:
                    result = "String";
                    break;
                case DatabaseDataType.Year:
                    result = isNull ? "DateTime?" : "DateTime";
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
                    result = "java.util.Date";
                    break;
                case DatabaseDataType.Datetime:
                    result = "java.util.Date";
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
                    result = "java.util.Date";
                    break;
                case DatabaseDataType.Timestamp:
                    result = "java.util.Date";
                    break;
                case DatabaseDataType.TinyInt:
                    result = "Integer";
                    break;
                case DatabaseDataType.VarChar:
                    result = "String";
                    break;
                case DatabaseDataType.Year:
                    result = "java.util.Date";
                    break;
                default:
                    break;
            }
            return result;
        }


    }
}
