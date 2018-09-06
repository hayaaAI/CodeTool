using Hayaa.BaseModel;
using System;
using System.Collections.Generic;

namespace Hayaa.CodeTool.Service
{
    public class CodeTemplateSearchPamater : SearchPamaterMariadbBase
    {
        public int? CodeTemplateId { set; get; }
        public List<int?> CodeTemplateIdList { set; get; }
        public int? CodeTemplateIdMax { set; get; }
        public int? CodeTemplateIdMin { set; get; }
        public void SetCodeTemplateId(int? max, int? min) { this.CodeTemplateIdMax = max; this.CodeTemplateIdMin = min; this.CodeTemplateIdPOT = PamaterOperationType.Between; }
        private PamaterOperationType CodeTemplateIdPOT;
        public void SetCodeTemplateId(int? info, PamaterOperationType pot) { this.CodeTemplateId = info; this.CodeTemplateIdPOT = pot; }
        private String GetCodeTemplateIdSqlForSharp()
        {
            String sql = ""; switch (CodeTemplateIdPOT)
            {
                case PamaterOperationType.Between: sql = "CodeTemplateId between @CodeTemplateIdMin to @CodeTemplateIdMax"; break;
                case PamaterOperationType.StringContains: sql = "CodeTemplateId like '%@CodeTemplateId%'"; break;
                case PamaterOperationType.Equal: sql = "CodeTemplateId=@CodeTemplateId"; break;
                case PamaterOperationType.GreaterEqual: sql = "CodeTemplateId>=@CodeTemplateId"; break;
                case PamaterOperationType.GreaterThan: sql = "CodeTemplateId>@CodeTemplateId"; break;
                case PamaterOperationType.LessEqual: sql = "CodeTemplateId<=@CodeTemplateId"; break;
                case PamaterOperationType.LessThan: sql = "CodeTemplateId<=@CodeTemplateId"; break;
                case PamaterOperationType.In: sql = "CodeTemplateId in(" + String.Join(",", this.CodeTemplateIdList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "CodeTemplateId in('" + String.Join("','", this.CodeTemplateIdList) + "')"; break;
            }
            return sql;
        }
        public String Name { set; get; }
        public List<String> NameList { set; get; }
        private PamaterOperationType NamePOT;
        public void SetName(String info, PamaterOperationType pot) { this.Name = info; this.NamePOT = pot; }
        private String GetNameSqlForSharp()
        {
            String sql = ""; switch (NamePOT)
            {
                case PamaterOperationType.Between: sql = "Name between @NameMin to @NameMax"; break;
                case PamaterOperationType.StringContains: sql = "Name like '%@Name%'"; break;
                case PamaterOperationType.Equal: sql = "Name=@Name"; break;
                case PamaterOperationType.GreaterEqual: sql = "Name>=@Name"; break;
                case PamaterOperationType.GreaterThan: sql = "Name>@Name"; break;
                case PamaterOperationType.LessEqual: sql = "Name<=@Name"; break;
                case PamaterOperationType.LessThan: sql = "Name<=@Name"; break;
                case PamaterOperationType.In: sql = "Name in(" + String.Join(",", this.NameList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "Name in('" + String.Join("','", this.NameList) + "')"; break;
            }
            return sql;
        }
        public String Content { set; get; }
        public List<String> ContentList { set; get; }
        private PamaterOperationType ContentPOT;
        public void SetContent(String info, PamaterOperationType pot) { this.Content = info; this.ContentPOT = pot; }
        private String GetContentSqlForSharp()
        {
            String sql = ""; switch (ContentPOT)
            {
                case PamaterOperationType.Between: sql = "Content between @ContentMin to @ContentMax"; break;
                case PamaterOperationType.StringContains: sql = "Content like '%@Content%'"; break;
                case PamaterOperationType.Equal: sql = "Content=@Content"; break;
                case PamaterOperationType.GreaterEqual: sql = "Content>=@Content"; break;
                case PamaterOperationType.GreaterThan: sql = "Content>@Content"; break;
                case PamaterOperationType.LessEqual: sql = "Content<=@Content"; break;
                case PamaterOperationType.LessThan: sql = "Content<=@Content"; break;
                case PamaterOperationType.In: sql = "Content in(" + String.Join(",", this.ContentList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "Content in('" + String.Join("','", this.ContentList) + "')"; break;
            }
            return sql;
        }
        public String SpaceName { set; get; }
        public List<String> SpaceNameList { set; get; }
        private PamaterOperationType SpaceNamePOT;
        public void SetSpaceName(String info, PamaterOperationType pot) { this.SpaceName = info; this.SpaceNamePOT = pot; }
        private String GetSpaceNameSqlForSharp()
        {
            String sql = ""; switch (SpaceNamePOT)
            {
                case PamaterOperationType.Between: sql = "SpaceName between @SpaceNameMin to @SpaceNameMax"; break;
                case PamaterOperationType.StringContains: sql = "SpaceName like '%@SpaceName%'"; break;
                case PamaterOperationType.Equal: sql = "SpaceName=@SpaceName"; break;
                case PamaterOperationType.GreaterEqual: sql = "SpaceName>=@SpaceName"; break;
                case PamaterOperationType.GreaterThan: sql = "SpaceName>@SpaceName"; break;
                case PamaterOperationType.LessEqual: sql = "SpaceName<=@SpaceName"; break;
                case PamaterOperationType.LessThan: sql = "SpaceName<=@SpaceName"; break;
                case PamaterOperationType.In: sql = "SpaceName in(" + String.Join(",", this.SpaceNameList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "SpaceName in('" + String.Join("','", this.SpaceNameList) + "')"; break;
            }
            return sql;
        }
        public int? Language { set; get; }
        public List<int?> LanguageList { set; get; }
        public int? LanguageMax { set; get; }
        public int? LanguageMin { set; get; }
        public void SetLanguage(int? max, int? min) { this.LanguageMax = max; this.LanguageMin = min; this.LanguagePOT = PamaterOperationType.Between; }
        private PamaterOperationType LanguagePOT;
        public void SetLanguage(int? info, PamaterOperationType pot) { this.Language = info; this.LanguagePOT = pot; }
        private String GetLanguageSqlForSharp()
        {
            String sql = ""; switch (LanguagePOT)
            {
                case PamaterOperationType.Between: sql = "Language between @LanguageMin to @LanguageMax"; break;
                case PamaterOperationType.StringContains: sql = "Language like '%@Language%'"; break;
                case PamaterOperationType.Equal: sql = "Language=@Language"; break;
                case PamaterOperationType.GreaterEqual: sql = "Language>=@Language"; break;
                case PamaterOperationType.GreaterThan: sql = "Language>@Language"; break;
                case PamaterOperationType.LessEqual: sql = "Language<=@Language"; break;
                case PamaterOperationType.LessThan: sql = "Language<=@Language"; break;
                case PamaterOperationType.In: sql = "Language in(" + String.Join(",", this.LanguageList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "Language in('" + String.Join("','", this.LanguageList) + "')"; break;
            }
            return sql;
        }
        public int? GenCodeType { set; get; }
        public List<int?> GenCodeTypeList { set; get; }
        public int? GenCodeTypeMax { set; get; }
        public int? GenCodeTypeMin { set; get; }
        public void SetGenCodeType(int? max, int? min) { this.GenCodeTypeMax = max; this.GenCodeTypeMin = min; this.GenCodeTypePOT = PamaterOperationType.Between; }
        private PamaterOperationType GenCodeTypePOT;
        public void SetGenCodeType(int? info, PamaterOperationType pot) { this.GenCodeType = info; this.GenCodeTypePOT = pot; }
        private String GetGenCodeTypeSqlForSharp()
        {
            String sql = ""; switch (GenCodeTypePOT)
            {
                case PamaterOperationType.Between: sql = "GenCodeType between @GenCodeTypeMin to @GenCodeTypeMax"; break;
                case PamaterOperationType.StringContains: sql = "GenCodeType like '%@GenCodeType%'"; break;
                case PamaterOperationType.Equal: sql = "GenCodeType=@GenCodeType"; break;
                case PamaterOperationType.GreaterEqual: sql = "GenCodeType>=@GenCodeType"; break;
                case PamaterOperationType.GreaterThan: sql = "GenCodeType>@GenCodeType"; break;
                case PamaterOperationType.LessEqual: sql = "GenCodeType<=@GenCodeType"; break;
                case PamaterOperationType.LessThan: sql = "GenCodeType<=@GenCodeType"; break;
                case PamaterOperationType.In: sql = "GenCodeType in(" + String.Join(",", this.GenCodeTypeList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "GenCodeType in('" + String.Join("','", this.GenCodeTypeList) + "')"; break;
            }
            return sql;
        }
        public DateTime? CreateTime { set; get; }
        public List<DateTime?> CreateTimeList { set; get; }
        public DateTime? CreateTimeMax { set; get; }
        public DateTime? CreateTimeMin { set; get; }
        public void SetCreateTime(DateTime? max, DateTime? min) { this.CreateTimeMax = max; this.CreateTimeMin = min; this.CreateTimePOT = PamaterOperationType.Between; }
        private PamaterOperationType CreateTimePOT;
        public void SetCreateTime(DateTime? info, PamaterOperationType pot) { this.CreateTime = info; this.CreateTimePOT = pot; }
        private String GetCreateTimeSqlForSharp()
        {
            String sql = ""; switch (CreateTimePOT)
            {
                case PamaterOperationType.Between: sql = "CreateTime between @CreateTimeMin to @CreateTimeMax"; break;
                case PamaterOperationType.StringContains: sql = "CreateTime like '%@CreateTime%'"; break;
                case PamaterOperationType.Equal: sql = "CreateTime=@CreateTime"; break;
                case PamaterOperationType.GreaterEqual: sql = "CreateTime>=@CreateTime"; break;
                case PamaterOperationType.GreaterThan: sql = "CreateTime>@CreateTime"; break;
                case PamaterOperationType.LessEqual: sql = "CreateTime<=@CreateTime"; break;
                case PamaterOperationType.LessThan: sql = "CreateTime<=@CreateTime"; break;
                case PamaterOperationType.In: sql = "CreateTime in(" + String.Join(",", this.CreateTimeList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "CreateTime in('" + String.Join("','", this.CreateTimeList) + "')"; break;
            }
            return sql;
        }
        public DateTime? UpdateTime { set; get; }
        public List<DateTime?> UpdateTimeList { set; get; }
        public DateTime? UpdateTimeMax { set; get; }
        public DateTime? UpdateTimeMin { set; get; }
        public void SetUpdateTime(DateTime? max, DateTime? min) { this.UpdateTimeMax = max; this.UpdateTimeMin = min; this.UpdateTimePOT = PamaterOperationType.Between; }
        private PamaterOperationType UpdateTimePOT;
        public void SetUpdateTime(DateTime? info, PamaterOperationType pot) { this.UpdateTime = info; this.UpdateTimePOT = pot; }
        private String GetUpdateTimeSqlForSharp()
        {
            String sql = ""; switch (UpdateTimePOT)
            {
                case PamaterOperationType.Between: sql = "UpdateTime between @UpdateTimeMin to @UpdateTimeMax"; break;
                case PamaterOperationType.StringContains: sql = "UpdateTime like '%@UpdateTime%'"; break;
                case PamaterOperationType.Equal: sql = "UpdateTime=@UpdateTime"; break;
                case PamaterOperationType.GreaterEqual: sql = "UpdateTime>=@UpdateTime"; break;
                case PamaterOperationType.GreaterThan: sql = "UpdateTime>@UpdateTime"; break;
                case PamaterOperationType.LessEqual: sql = "UpdateTime<=@UpdateTime"; break;
                case PamaterOperationType.LessThan: sql = "UpdateTime<=@UpdateTime"; break;
                case PamaterOperationType.In: sql = "UpdateTime in(" + String.Join(",", this.UpdateTimeList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "UpdateTime in('" + String.Join("','", this.UpdateTimeList) + "')"; break;
            }
            return sql;
        }
    }
}