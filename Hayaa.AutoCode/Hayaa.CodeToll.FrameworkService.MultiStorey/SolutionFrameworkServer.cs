using Hayaa.BaseModel;
using Hayaa.CodeTool.FrameworkService.MultiStorey.Dao;
using Hayaa.CodeTool.FrameworkService;
using Hayaa.CodeToolService;
using Hayaa.ModelService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hayaa.CodeTool.FrameworkService.MultiStorey
{
    public partial class SolutionFrameworkServer : SolutionFrameworkService
    {
        //public FunctionResult<Solution> MakeCodeSolution(List<DatabaseTable> model, SolutionTemplate codeTemplate)
        //{
        //    FunctionResult<Solution> result = new FunctionResult<Solution>();
        //    if (codeTemplate.SolutionTemplates != null)
        //    {
        //        codeTemplate.SolutionTemplates.ForEach(t =>
        //        {
        //            //获取返回结果代码段
        //            //替换检查与断言标签
        //            //数据业务实现
        //        });
        //    }
        //    return result;
        //}
        public FunctionResult<Solution> MakeCodeForMultiStoreySolution(List<string> tables, SolutionTemplate codeTemplatee, string databaseConnection, string databaseName, string savePath)
        {
            var result = new FunctionResult<Solution>();
            result.Data = new Solution()
            {
                SolutionPath = savePath
            };
            //生成数据库原型类
            CodeTemplate modelTemplate = codeTemplatee.SolutionTemplates.Find(ct => ct.GenCodeType == CodeType.DataAccessModel);
            MakeCodeForModel(tables, modelTemplate, databaseConnection, databaseName, savePath);
            //生成Dao层代码
            CodeTemplate dalTemplate = codeTemplatee.SolutionTemplates.Find(ct => ct.GenCodeType == CodeType.Dao);
            MakeCodeForDao(tables, dalTemplate, databaseConnection, databaseName, savePath, modelTemplate.SpaceName);
            //生成服务层代码
            CodeTemplate serviceTemplate = codeTemplatee.SolutionTemplates.Find(ct => ct.GenCodeType == CodeType.Service);
            MakeCodeForService(tables, serviceTemplate, databaseConnection, databaseName, savePath);
            //生成controller层代码
            CodeTemplate viewServiceTemplate = codeTemplatee.SolutionTemplates.Find(ct => ct.GenCodeType == CodeType.ViewService);
            MakeCodeForViewService(tables, viewServiceTemplate, databaseConnection, databaseName, savePath);
            return result;
        }
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
                    StringBuilder codeBuilder = null; //构造原型类整体结构
                    StringBuilder codeSearchBuilder = null; //构造参数类整体结构   
                    if (codeTemplate.Language == CodeLanaguage.CSharp)
                    {
                        codeBuilder = new StringBuilder(String.Format("public  class {0}:BaseData{{CODE}}", t.Name));
                        codeSearchBuilder = new StringBuilder(String.Format("public class {0}SearchPamater:SearchPamaterMariadbBase {{CODE}}", t.Name));
                    }
                    if (codeTemplate.Language == CodeLanaguage.Java)
                    {
                        codeBuilder = new StringBuilder(String.Format("public  class {0} extends BaseData{{CODE}}", t.Name));
                        codeSearchBuilder = new StringBuilder(String.Format("public class {0}SearchPamater {{CODE}}", t.Name));
                    }
                    if (t.Fileds != null)
                    {
                        StringBuilder propertiesBulider = new StringBuilder();
                        StringBuilder searchPropertiesBulider = new StringBuilder();
                        t.Fileds.ForEach(p =>
                        {
                            if(p.Name.ToLower().Contains("createtime")|| p.Name.ToLower().Contains("updatetime"))
                            {
                                return;
                            }
                            //根据语言类型区分生成逻辑
                            if (codeTemplate.Language == CodeLanaguage.CSharp)
                            {
                                String dataType = GetCsharpDataType(p.DataType, false);
                                String searchDataType = GetCsharpDataType(p.DataType, true);
                                propertiesBulider.Append(String.Format("public {0} {1}{{set;get;}}\n", dataType, p.Name));
                                searchPropertiesBulider.Append(String.Format("public {0} {1}{{set;get;}}\n", searchDataType, p.Name));
                                searchPropertiesBulider.Append(String.Format("public List<{0}> {1}List{{set;get;}}\n", dataType, p.Name));
                                String betweenStr = "";
                                if (!IsString(p.DataType))//字符类型不需要二元操作符
                                {
                                    searchPropertiesBulider.Append(String.Format("public {0} {1}Max{{set;get;}}\n", searchDataType, p.Name));
                                    searchPropertiesBulider.Append(String.Format("public {0} {1}Min{{set;get;}}\n", searchDataType, p.Name));
                                    searchPropertiesBulider.Append(String.Format("public void Set{1}({0} max,{0} min){{ this.{1}Max=max;this.{1}Min=min;this.{1}POT=PamaterOperationType.Between;}}\n", searchDataType, p.Name));
                                    betweenStr = "case PamaterOperationType.Between:sql = \"{0} between @{0}Min to @{0}Max\";break;\n";
                                }
                                searchPropertiesBulider.Append(String.Format("private PamaterOperationType {0}POT;\n", p.Name));//设置操作类型
                                searchPropertiesBulider.Append(String.Format("public void Set{1}({0} info,PamaterOperationType pot){{ this.{1}=info;this.{1}POT=pot;}}\n", searchDataType, p.Name));
                                searchPropertiesBulider.Append(String.Format("private String Get{0}SqlForSharp(){{String sql = \"\";switch ({0}POT){{\n" + betweenStr + "case PamaterOperationType.StringContains:sql = \"{0} like '%@{0}%'\";break;\ncase PamaterOperationType.Equal:sql = \"{0}=@{0}\";break;\ncase PamaterOperationType.GreaterEqual:sql = \"{0}>=@{0}\";break;\ncase PamaterOperationType.GreaterThan:sql = \"{0}>@{0}\";break;\ncase PamaterOperationType.LessEqual:sql = \"{0}<=@{0}\";break;\ncase PamaterOperationType.LessThan:sql = \"{0}<=@{0}\";break;\ncase PamaterOperationType.In:sql = \"{0} in(\" + String.Join(\",\", this.{0}List) + \")\";break;\ncase PamaterOperationType.StringIn:sql = \"{0} in('\" + String.Join(\"','\", this.{0}List)+\"')\";break;\n}}\nreturn sql;}}\n", p.Name));
                            }
                            if (codeTemplate.Language == CodeLanaguage.Java)
                            {
                                String dataType = GetJavaDataType(p.DataType);
                                propertiesBulider.Append(String.Format("private {0} {1};", dataType, p.Name));
                                propertiesBulider.Append(String.Format("public void set{2}({0} {1}value){{ this.{1}={1}value; }}", dataType, p.Name,ParseBigName(p.Name)));
                                propertiesBulider.Append(String.Format("public {0} get{2}(){{ return this.{1}; }}", dataType, p.Name, ParseBigName(p.Name)));
                                searchPropertiesBulider.Append(String.Format("private {0} {1};", dataType, p.Name));
                                searchPropertiesBulider.Append(String.Format("public void set{2}({0} {1}value){{ this.{1}={1}value; }}", dataType, p.Name, ParseBigName(p.Name)));
                                searchPropertiesBulider.Append(String.Format("public {0} get{2}(){{ return this.{1}; }}", dataType, p.Name, ParseBigName(p.Name)));
                                searchPropertiesBulider.Append(String.Format("private List<{0}> {1}List;", dataType, p.Name));
                                searchPropertiesBulider.Append(String.Format("public void set{1}List(List<{0}> {1}value){{ this.{1}List={1}value; }}", dataType, p.Name));
                                searchPropertiesBulider.Append(String.Format("public List<{0}> get{1}List(){{ return  this.{1}List; }}", dataType, p.Name));
                                String betweenStr = "";
                                if (!IsString(p.DataType))//字符类型不需要二元操作符
                                {
                                    searchPropertiesBulider.Append(String.Format("private {0} {1}Max;", dataType, p.Name));
                                    searchPropertiesBulider.Append(String.Format("public void set{1}Max({0} {1}value){{ this.{1}Max={1}value; }}", dataType, p.Name));
                                    searchPropertiesBulider.Append(String.Format("public {0} get{1}Max(){{ return this.{1}Max; }}", dataType, p.Name));
                                    searchPropertiesBulider.Append(String.Format("private {0} {1}Min;", dataType, p.Name));
                                    searchPropertiesBulider.Append(String.Format("public void set{1}Min({0} {1}value){{ this.{1}Min={1}value; }}", dataType, p.Name));
                                    searchPropertiesBulider.Append(String.Format("public {0} get{1}Min(){{ return this.{1}Min; }}", dataType, p.Name));
                                    //   searchPropertiesBulider.Append(String.Format("public void set{1}({0} max,{0} min){{ this.{1}Max=max;this.{1}Min=min;this.{1}POT=PamaterOperationType.Between;}}", dataType, p.Name));
                                    // betweenStr = "case Between:sql = \"{0} between #{{{0}}}Min to #{{{0}}}Max\";break;";
                                }
                                // searchPropertiesBulider.Append(String.Format("private PamaterOperationType {0}POT;", p.Name));//设置操作类型
                                //  searchPropertiesBulider.Append(String.Format("public void Set{1}({0} info,PamaterOperationType pot){{ this.{1}=info;this.{1}POT=pot;}}\n", dataType, p.Name));
                                //  searchPropertiesBulider.Append(String.Format("protected String get{0}Sql(){{String sql = \"\";switch ({0}POT){{ " + betweenStr + "case StringContains:sql = \"{0} like '%#{{{0}}}%'\";break;case Equal:sql = \"{0}=#{{{0}}}\";break;case GreaterEqual:sql = \"{0}>=#{{{0}}}\";break;case GreaterThan:sql = \"{0}>#{{{0}}}\";break;case LessEqual:sql = \"{0}<=#{{{0}}}\";break;case LessThan:sql = \"{0}<=#{{{0}}}\";break;case In: String strArr=this.{0}List.toString().replace(\"[\",\"\").replace(\"]\",\"\");sql = \"{0} in(\" + String.join(\",\",strArr) + \")\";break;case StringIn: String strList=this.{0}List.toString().replace(\"[\",\"\").replace(\"]\",\"\");sql = \"{0} in('\" + String.join(\"','\", strList)+\"')\";break;}}return sql;}}", p.Name));
                            }
                        });
                        codeBuilder = codeBuilder.Replace("CODE", propertiesBulider.ToString());
                        codeSearchBuilder = codeSearchBuilder.Replace("CODE", searchPropertiesBulider.ToString());
                    }
                    BuilderModelFile(codeTemplate, codeBuilder, savePath, t.Name);
                    BuilderModelFile(codeTemplate, codeSearchBuilder, savePath, t.Name + "SearchPamater");
                });
            }
            return result;
        }
        public FunctionResult<Solution> MakeCodeForDao(List<string> tables, CodeTemplate codeTemplate, string databaseConnection, String databaseName, String savePath, String modelSpacename = null)
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
                    StringBuilder xmlBuilder = new StringBuilder();
                    if (codeTemplate.Language == CodeLanaguage.CSharp)
                    {
                        CreateCSharpDaoCode(t, codeBuilder, databaseName);
                    }
                    if (codeTemplate.Language == CodeLanaguage.Java)
                    {
                        CreateJavaDaoCode(t, codeBuilder, databaseName);
                        CreateMybatisXml(codeTemplate, t, xmlBuilder, databaseName, modelSpacename);
                        BuilderMybatisXmlFile(xmlBuilder, savePath, t.Name);
                    }
                    BuilderDaoCodeFile(codeTemplate, codeBuilder, savePath, t.Name);
                });
            }
            return result;
        }
        public FunctionResult<Solution> MakeCodeForService(List<string> tables, CodeTemplate codeTemplate, string databaseConnection, string databaseName, string savePath)
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
                StringBuilder codeBuilder = null;
                list.ForEach(t =>
                {
                    if (codeTemplate.Language == CodeLanaguage.CSharp)
                        codeBuilder = CreateForCSharp(t);
                    else
                        codeBuilder = CreateForJava(t);
                    BuilderServiceFile(codeTemplate, codeBuilder, savePath, t.Name);

                });
            }
            return result;
        }

        public FunctionResult<Solution> MakeCodeForViewService(List<string> tables, CodeTemplate codeTemplate, string databaseConnection, string databaseName, string savePath)
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
                StringBuilder codeBuilder = null;
                list.ForEach(t =>
                {
                    if (codeTemplate.Language == CodeLanaguage.CSharp)
                        codeBuilder = new StringBuilder();
                    else
                        codeBuilder = CreateViewServiceForJava(t);
                    BuilderViewServiceFile(codeTemplate, codeBuilder, savePath, t.Name);

                });
            }
            return result;
        }

       
    }
}
