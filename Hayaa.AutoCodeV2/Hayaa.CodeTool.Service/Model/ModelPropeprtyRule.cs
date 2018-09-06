using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeTool.Service
{
    /// <summary>
    /// 数据属性约束规则属性类
    /// </summary>
  public  class ModelPropeprtyRule
    {
        private ModelPropeprtyRuleType g_ruleType;
        private String g_regRule=null;
        private DataRang<byte> g_byteRang;
        public ModelPropeprtyRule(DataRang<byte> rang)
        {
            g_ruleType = ModelPropeprtyRuleType.Rang;
            g_byteRang = rang;
        }
        public DataRang<byte> getByteRang()
        {
            return g_byteRang;
        }
        private DataRang<int> g_intRang;
        public ModelPropeprtyRule(DataRang<int> rang)
        {
            g_ruleType = ModelPropeprtyRuleType.Rang;
            g_intRang = rang;
        }
        public DataRang<int> getIntRang()
        {
            return g_intRang;
        }
        private DataRang<long> g_longRang;
        public ModelPropeprtyRule(DataRang<long> rang)
        {
            g_ruleType = ModelPropeprtyRuleType.Rang; 
            g_longRang = rang;
        }
        public DataRang<long> getLongRang()
        {
            return g_longRang;
        }
        private DataRang<decimal> g_decimalRang;
        public ModelPropeprtyRule(DataRang<decimal> rang)
        {
            g_ruleType = ModelPropeprtyRuleType.Rang;
            g_decimalRang = rang;
        }
        public DataRang<decimal> getDecimalRang()
        {
            return g_decimalRang;
        }
        private DataRang<double> g_doubleRang;
        public ModelPropeprtyRule( DataRang<double> rang)
        {
            g_ruleType = ModelPropeprtyRuleType.Rang;
            g_doubleRang = rang;
        }
        public DataRang<double> getDoubleRang()
        {
            return g_doubleRang;
        }
        private DataRang<float> g_floatRang;
        public ModelPropeprtyRule(DataRang<float> rang)
        {
            g_ruleType = ModelPropeprtyRuleType.Rang;
            g_floatRang = rang;
        }
        public DataRang<float> getFloatRang()
        {
            return g_floatRang;
        }
        private DataRang<DateTime> g_dateTimeRang;
        public ModelPropeprtyRule(DataRang<DateTime> rang)
        {
            g_ruleType = ModelPropeprtyRuleType.Rang;
            g_dateTimeRang = rang;
        }
        public DataRang<DateTime> getDateTimeRang()
        {
            return g_dateTimeRang;
        }
        public ModelPropeprtyRule(String reg)
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
        public ModelPropeprtyRule()
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
