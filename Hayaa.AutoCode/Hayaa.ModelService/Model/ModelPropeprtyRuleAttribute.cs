using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ModelService
{
    /// <summary>
    /// 数据属性约束规则属性类
    /// </summary>
  public  class ModelPropeprtyRuleAttribute: Attribute
    {
        private ModelPropeprtyRuleType g_ruleType;
        private String g_regRule=null;
        private DataRang<int> g_intRang;
        public ModelPropeprtyRuleAttribute(DataRang<int> rang)
        {
            g_ruleType = ModelPropeprtyRuleType.Rang;
            g_intRang = rang;
        }
        private DataRang<long> g_longRang;
        public ModelPropeprtyRuleAttribute(DataRang<long> rang)
        {
            g_ruleType = ModelPropeprtyRuleType.Rang; 
            g_longRang = rang;
        }
        private DataRang<decimal> g_decimalRang;
        public ModelPropeprtyRuleAttribute(DataRang<decimal> rang)
        {
            g_ruleType = ModelPropeprtyRuleType.Rang;
            g_decimalRang = rang;
        }
        private DataRang<double> g_doublelRang;
        public ModelPropeprtyRuleAttribute( DataRang<double> rang)
        {
            g_ruleType = ModelPropeprtyRuleType.Rang;
            g_doublelRang = rang;
        }
        public ModelPropeprtyRuleAttribute(String reg)
        {
            g_ruleType = ModelPropeprtyRuleType.Regex;
            g_regRule = reg;
        }
        /// <summary>
        /// 获取正则规则内容
        /// </summary>
        public String RegexRule
        {
            get
            {
                return g_regRule;
            }
        }
        public ModelPropeprtyRuleAttribute()
        {
            g_ruleType = ModelPropeprtyRuleType.NullOrEmpty;          
        }
        /// <summary>
        /// 获取校验规则类型
        /// </summary>
        public ModelPropeprtyRuleType RuleType
        {
            get
            {
                return g_ruleType;
            }
        }
    }
}
