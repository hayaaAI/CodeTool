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
    public partial class SolutionFrameworkServer : SolutionFrameworkService
    {
        public FunctionResult<Solution> MakeCodeSolution(List<DatabaseTable> model, SolutionTemplate codeTemplate)
        {
            FunctionResult<Solution> result = new FunctionResult<Solution>();
            if (codeTemplate.SolutionTemplates != null)
            {
                codeTemplate.SolutionTemplates.ForEach(t =>
                {
                    //获取返回结果代码段
                    //替换检查与断言标签
                    //数据业务实现
                });
            }
            return result;
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
                        CreateCSharpDaoCode(t, codeBuilder, databaseName);
                    }
                    if (codeTemplate.Language == CodeLanaguage.Java)
                    {

                    }
                    BuilderDaoCodeFile(codeTemplate, codeBuilder, savePath, t.Name);
                });
            }
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
                    StringBuilder codeBuilder = new StringBuilder(String.Format("public  class {0}:BaseData{{CODE}}", t.Name));//构造原型类整体结构
                    StringBuilder codeSearchBuilder = new StringBuilder(String.Format("public class {0}SearchPamater:SearchPamaterMariadbBase {{CODE}}", t.Name));//构造参数类整体结构   
                    if (t.Fileds != null)
                    {
                        StringBuilder propertiesBulider = new StringBuilder();
                        StringBuilder searchPropertiesBulider = new StringBuilder();
                        t.Fileds.ForEach(p =>
                        {
                            //根据语言类型区分生成逻辑
                            if (codeTemplate.Language == CodeLanaguage.CSharp)
                            {
                                String dataType = GetCsharpDataType(p.DataType, true);
                                propertiesBulider.Append(String.Format("public {0} {1}{{set;get;}}\n", dataType, p.Name));
                                searchPropertiesBulider.Append(String.Format("public {0} {1}{{set;get;}}\n", dataType, p.Name));
                                searchPropertiesBulider.Append(String.Format("public List<{0}> {1}List{{set;get;}}\n", dataType, p.Name));
                                if (!IsString(p.DataType))//字符类型不需要二元操作符
                                {
                                    searchPropertiesBulider.Append(String.Format("public {0} {1}Max{{set;get;}}\n", dataType, p.Name));
                                    searchPropertiesBulider.Append(String.Format("public {0} {1}Min{{set;get;}}\n", dataType, p.Name));
                                    searchPropertiesBulider.Append(String.Format("public void Set{1}({0} max,{0} min){{ this.{1}Max=max;this.{1}Min=min;this.{1}POT=PamaterOperationType.Between;}}\n", dataType, p.Name));
                                }
                                searchPropertiesBulider.Append(String.Format("private PamaterOperationType {0}POT;\n", p.Name));//设置操作类型
                                searchPropertiesBulider.Append(String.Format("public void Set{1}({0} info,PamaterOperationType pot){{ this.{1}=info;this.{1}POT=pot;}}\n", dataType, p.Name));
                                searchPropertiesBulider.Append(String.Format("private String Get{0}SqlForSharp(){{String sql = \"\";switch ({0}POT){{\ncase PamaterOperationType.Between:sql = \"{0} between @{0}Min to @{0}Max\";break;\ncase PamaterOperationType.StringContains:sql = \"{0} like '%@{0}%'\";break;\ncase PamaterOperationType.Equal:sql = \"{0}=@{0}\";break;\ncase PamaterOperationType.GreaterEqual:sql = \"{0}>=@{0}\";break;\ncase PamaterOperationType.GreaterThan:sql = \"{0}>@{0}\";break;\ncase PamaterOperationType.LessEqual:sql = \"{0}<=@{0}\";break;\ncase PamaterOperationType.LessThan:sql = \"{0}<=@{0}\";break;\ncase PamaterOperationType.In:sql = \"{0} in(\" + String.Join(\",\", this.{0}List) + \")\";break;\ncase PamaterOperationType.StringIn:sql = \"{0} in('\" + String.Join(\"','\", this.{0}List)+\"')\";break;\n}}\nreturn sql;}}\n", p.Name));
                            }
                            if (codeTemplate.Language == CodeLanaguage.Java)
                            {
                                String dataType = GetJavaDataType(p.DataType);
                                propertiesBulider.Append(String.Format("private {0} {1};\n", dataType, p.Name));
                                propertiesBulider.Append(String.Format("public {0} set{1}({0} {1}value){{ {1}={1}value; }}\n", dataType, p.Name));
                                propertiesBulider.Append(String.Format("public {0} get{1}(){{ return {1}; }}\n", dataType, p.Name));
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
            MakeCodeForDao(tables, modelTemplate, databaseConnection, databaseName, savePath);
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

                list.ForEach(t =>
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
                   BuilderServiceFile(codeTemplate, codeBuilder, savePath, t.Name);
                 
                });
            }
            return result;
        }

      
    }
}
