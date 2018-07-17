using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
namespace Hayaa.DataCenter.Service
{
    public class DataConnectionSearchPamater : SearchPamaterMariadbBase
    {
        public int? DataConnectionId { set; get; }
        public List<int> DataConnectionIdList { set; get; }
        public int? DataConnectionIdMax { set; get; }
        public int? DataConnectionIdMin { set; get; }
        public void SetDataConnectionId(int? max, int? min) { this.DataConnectionIdMax = max; this.DataConnectionIdMin = min; this.DataConnectionIdPOT = PamaterOperationType.Between; }
        private PamaterOperationType DataConnectionIdPOT;
        public void SetDataConnectionId(int? info, PamaterOperationType pot) { this.DataConnectionId = info; this.DataConnectionIdPOT = pot; }
        private String GetDataConnectionIdSqlForSharp()
        {
            String sql = ""; switch (DataConnectionIdPOT)
            {
                case PamaterOperationType.Between: sql = "DataConnectionId between @DataConnectionIdMin to @DataConnectionIdMax"; break;
                case PamaterOperationType.StringContains: sql = "DataConnectionId like '%@DataConnectionId%'"; break;
                case PamaterOperationType.Equal: sql = "DataConnectionId=@DataConnectionId"; break;
                case PamaterOperationType.GreaterEqual: sql = "DataConnectionId>=@DataConnectionId"; break;
                case PamaterOperationType.GreaterThan: sql = "DataConnectionId>@DataConnectionId"; break;
                case PamaterOperationType.LessEqual: sql = "DataConnectionId<=@DataConnectionId"; break;
                case PamaterOperationType.LessThan: sql = "DataConnectionId<=@DataConnectionId"; break;
                case PamaterOperationType.In: sql = "DataConnectionId in(" + String.Join(",", this.DataConnectionIdList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "DataConnectionId in('" + String.Join("','", this.DataConnectionIdList) + "')"; break;
            }
            return sql;
        }
        public String DatabaseName { set; get; }
        public List<String> DatabaseNameList { set; get; }
        private PamaterOperationType DatabaseNamePOT;
        public void SetDatabaseName(String info, PamaterOperationType pot) { this.DatabaseName = info; this.DatabaseNamePOT = pot; }
        private String GetDatabaseNameSqlForSharp()
        {
            String sql = ""; switch (DatabaseNamePOT)
            {
                case PamaterOperationType.StringContains: sql = "DatabaseName like '%@DatabaseName%'"; break;
                case PamaterOperationType.Equal: sql = "DatabaseName=@DatabaseName"; break;
                case PamaterOperationType.GreaterEqual: sql = "DatabaseName>=@DatabaseName"; break;
                case PamaterOperationType.GreaterThan: sql = "DatabaseName>@DatabaseName"; break;
                case PamaterOperationType.LessEqual: sql = "DatabaseName<=@DatabaseName"; break;
                case PamaterOperationType.LessThan: sql = "DatabaseName<=@DatabaseName"; break;
                case PamaterOperationType.In: sql = "DatabaseName in(" + String.Join(",", this.DatabaseNameList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "DatabaseName in('" + String.Join("','", this.DatabaseNameList) + "')"; break;
            }
            return sql;
        }
        public String DatabaseUser { set; get; }
        public List<String> DatabaseUserList { set; get; }
        private PamaterOperationType DatabaseUserPOT;
        public void SetDatabaseUser(String info, PamaterOperationType pot) { this.DatabaseUser = info; this.DatabaseUserPOT = pot; }
        private String GetDatabaseUserSqlForSharp()
        {
            String sql = ""; switch (DatabaseUserPOT)
            {
                case PamaterOperationType.StringContains: sql = "DatabaseUser like '%@DatabaseUser%'"; break;
                case PamaterOperationType.Equal: sql = "DatabaseUser=@DatabaseUser"; break;
                case PamaterOperationType.GreaterEqual: sql = "DatabaseUser>=@DatabaseUser"; break;
                case PamaterOperationType.GreaterThan: sql = "DatabaseUser>@DatabaseUser"; break;
                case PamaterOperationType.LessEqual: sql = "DatabaseUser<=@DatabaseUser"; break;
                case PamaterOperationType.LessThan: sql = "DatabaseUser<=@DatabaseUser"; break;
                case PamaterOperationType.In: sql = "DatabaseUser in(" + String.Join(",", this.DatabaseUserList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "DatabaseUser in('" + String.Join("','", this.DatabaseUserList) + "')"; break;
            }
            return sql;
        }
        public String DatabaseToken { set; get; }
        public List<String> DatabaseTokenList { set; get; }
        private PamaterOperationType DatabaseTokenPOT;
        public void SetDatabaseToken(String info, PamaterOperationType pot) { this.DatabaseToken = info; this.DatabaseTokenPOT = pot; }
        private String GetDatabaseTokenSqlForSharp()
        {
            String sql = ""; switch (DatabaseTokenPOT)
            {
                case PamaterOperationType.StringContains: sql = "DatabaseToken like '%@DatabaseToken%'"; break;
                case PamaterOperationType.Equal: sql = "DatabaseToken=@DatabaseToken"; break;
                case PamaterOperationType.GreaterEqual: sql = "DatabaseToken>=@DatabaseToken"; break;
                case PamaterOperationType.GreaterThan: sql = "DatabaseToken>@DatabaseToken"; break;
                case PamaterOperationType.LessEqual: sql = "DatabaseToken<=@DatabaseToken"; break;
                case PamaterOperationType.LessThan: sql = "DatabaseToken<=@DatabaseToken"; break;
                case PamaterOperationType.In: sql = "DatabaseToken in(" + String.Join(",", this.DatabaseTokenList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "DatabaseToken in('" + String.Join("','", this.DatabaseTokenList) + "')"; break;
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
        public String Title { set; get; }
        public List<String> TitleList { set; get; }
        private PamaterOperationType TitlePOT;
        public void SetTitle(String info, PamaterOperationType pot) { this.Title = info; this.TitlePOT = pot; }
        private String GetTitleSqlForSharp()
        {
            String sql = ""; switch (TitlePOT)
            {
                case PamaterOperationType.StringContains: sql = "Title like '%@Title%'"; break;
                case PamaterOperationType.Equal: sql = "Title=@Title"; break;
                case PamaterOperationType.GreaterEqual: sql = "Title>=@Title"; break;
                case PamaterOperationType.GreaterThan: sql = "Title>@Title"; break;
                case PamaterOperationType.LessEqual: sql = "Title<=@Title"; break;
                case PamaterOperationType.LessThan: sql = "Title<=@Title"; break;
                case PamaterOperationType.In: sql = "Title in(" + String.Join(",", this.TitleList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "Title in('" + String.Join("','", this.TitleList) + "')"; break;
            }
            return sql;
        }
        public String Remark { set; get; }
        public List<String> RemarkList { set; get; }
        private PamaterOperationType RemarkPOT;
        public void SetRemark(String info, PamaterOperationType pot) { this.Remark = info; this.RemarkPOT = pot; }
        private String GetRemarkSqlForSharp()
        {
            String sql = ""; switch (RemarkPOT)
            {
                case PamaterOperationType.StringContains: sql = "Remark like '%@Remark%'"; break;
                case PamaterOperationType.Equal: sql = "Remark=@Remark"; break;
                case PamaterOperationType.GreaterEqual: sql = "Remark>=@Remark"; break;
                case PamaterOperationType.GreaterThan: sql = "Remark>@Remark"; break;
                case PamaterOperationType.LessEqual: sql = "Remark<=@Remark"; break;
                case PamaterOperationType.LessThan: sql = "Remark<=@Remark"; break;
                case PamaterOperationType.In: sql = "Remark in(" + String.Join(",", this.RemarkList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "Remark in('" + String.Join("','", this.RemarkList) + "')"; break;
            }
            return sql;
        }
    }
}