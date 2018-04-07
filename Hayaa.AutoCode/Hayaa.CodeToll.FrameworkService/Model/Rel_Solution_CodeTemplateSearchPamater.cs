using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
/// <summary>///代码效率工具生成，此文件不要修改/// </summary>
namespace Hayaa.CodeTool.FrameworkService
{
    public class Rel_Solution_CodeTemplateSearchPamater : SearchPamaterMariadbBase
    {
        public int? Id { set; get; }
        public List<int?> IdList { set; get; }
        public int? IdMax { set; get; }
        public int? IdMin { set; get; }
        public void SetId(int? max, int? min) { this.IdMax = max; this.IdMin = min; this.IdPOT = PamaterOperationType.Between; }
        private PamaterOperationType IdPOT;
        public void SetId(int? info, PamaterOperationType pot) { this.Id = info; this.IdPOT = pot; }
        private String GetIdSqlForSharp()
        {
            String sql = ""; switch (IdPOT)
            {
                case PamaterOperationType.Between: sql = "Id between @IdMin to @IdMax"; break;
                case PamaterOperationType.StringContains: sql = "Id like '%@Id%'"; break;
                case PamaterOperationType.Equal: sql = "Id=@Id"; break;
                case PamaterOperationType.GreaterEqual: sql = "Id>=@Id"; break;
                case PamaterOperationType.GreaterThan: sql = "Id>@Id"; break;
                case PamaterOperationType.LessEqual: sql = "Id<=@Id"; break;
                case PamaterOperationType.LessThan: sql = "Id<=@Id"; break;
                case PamaterOperationType.In: sql = "Id in(" + String.Join(",", this.IdList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "Id in('" + String.Join("','", this.IdList) + "')"; break;
            }
            return sql;
        }
        public int? SolutionTemplateId { set; get; }
        public List<int?> SolutionTemplateIdList { set; get; }
        public int? SolutionTemplateIdMax { set; get; }
        public int? SolutionTemplateIdMin { set; get; }
        public void SetSolutionTemplateId(int? max, int? min) { this.SolutionTemplateIdMax = max; this.SolutionTemplateIdMin = min; this.SolutionTemplateIdPOT = PamaterOperationType.Between; }
        private PamaterOperationType SolutionTemplateIdPOT;
        public void SetSolutionTemplateId(int? info, PamaterOperationType pot) { this.SolutionTemplateId = info; this.SolutionTemplateIdPOT = pot; }
        private String GetSolutionTemplateIdSqlForSharp()
        {
            String sql = ""; switch (SolutionTemplateIdPOT)
            {
                case PamaterOperationType.Between: sql = "SolutionTemplateId between @SolutionTemplateIdMin to @SolutionTemplateIdMax"; break;
                case PamaterOperationType.StringContains: sql = "SolutionTemplateId like '%@SolutionTemplateId%'"; break;
                case PamaterOperationType.Equal: sql = "SolutionTemplateId=@SolutionTemplateId"; break;
                case PamaterOperationType.GreaterEqual: sql = "SolutionTemplateId>=@SolutionTemplateId"; break;
                case PamaterOperationType.GreaterThan: sql = "SolutionTemplateId>@SolutionTemplateId"; break;
                case PamaterOperationType.LessEqual: sql = "SolutionTemplateId<=@SolutionTemplateId"; break;
                case PamaterOperationType.LessThan: sql = "SolutionTemplateId<=@SolutionTemplateId"; break;
                case PamaterOperationType.In: sql = "SolutionTemplateId in(" + String.Join(",", this.SolutionTemplateIdList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "SolutionTemplateId in('" + String.Join("','", this.SolutionTemplateIdList) + "')"; break;
            }
            return sql;
        }
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
    }
}