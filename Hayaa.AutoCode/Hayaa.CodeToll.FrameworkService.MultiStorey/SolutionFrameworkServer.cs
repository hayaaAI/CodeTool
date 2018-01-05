using Hayaa.BaseModel;
using Hayaa.CodeTool.FrameworkService;
using Hayaa.CodeToolService;
using Hayaa.ModelService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeToll.FrameworkService.MultiStorey
{
    public class SolutionFrameworkServer : SolutionFrameworkService
    {
       
        public FunctionResult<Solution> MakeCodeSolution(List<DatabaseModel> model, SolutinTemplate codeTemplate)
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
        private string CreateAssertCode(DatabaseModel model)
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
                                case DatabaseDataType.LongText:
                                case DatabaseDataType.Nchar:
                                case DatabaseDataType.Ntext:
                                case DatabaseDataType.NvarChar:
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
                                case DatabaseDataType.Money:
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
        private string CreateCheckCode(DatabaseModel model,String returnTypeCode)
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
                                case DatabaseDataType.LongText:
                                case DatabaseDataType.Nchar:
                                case DatabaseDataType.Ntext:
                                case DatabaseDataType.NvarChar:
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
                                case DatabaseDataType.Money:
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
                            code.Append(string.Format("if(!CheckHelper.IsRegex(var{0}.{1},{2})){ return {3}; }\n", model.Name, f.Name,f.CheckRule.RegexRule, returnTypeCode));
                            break;
                    }
                });
            }
            return code.ToString();
        }
       
    }
}
 