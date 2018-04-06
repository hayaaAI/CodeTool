using Hayaa.CodeToll.FrameworkService.MultiStorey;
using Hayaa.CodeTool.FrameworkService;
using Hayaa.CodeToolService;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTestSolutionFrameworkService
    {
        SolutionFrameworkService sfs = new SolutionFrameworkServer();
        private static String con = "Data Source=39.104.91.100;Initial Catalog=RemoteConfig;Persist Security Info=True;User ID=configdbu;password=configDBuserpd18?1";
        private static String modeTemplate= "using System;using System.Collections.Generic;using System.Text;using Hayaa.BaseModel;\nnamespace Hayaa.RemoteService{\n{$#class#$}\n}";
        private static String daoTemplate = "using System;using System.Collections.Generic;using System.Text;using Hayaa.DataAccess;using Hayaa.BaseModel;using Hayaa.RemoteService.Core.Config;\nnamespace Hayaa.RemoteService.DataAccess{\n{$#class#$}\n}";
        [Fact]
        public void MakeCodeForModel_Pass_Test()
        {
            Guid id = Guid.NewGuid();
            CodeTemplate codeTemplate = new CodeTemplate() { CodeTemplateID = 1, Content = modeTemplate, GenCodeType= CodeType.DataAccessModel, Language=CodeLanaguage.CSharp, Name="ctn"};
            List<String> tables = new List<string>() {"App" };
            sfs.MakeCodeForModel(tables, codeTemplate, con, "RemoteConfig", @"F:\Test\Code");
        }
        [Fact]
        public void MakeCodeForDao_Pass_Test()
        {
            CodeTemplate codeTemplate = new CodeTemplate() { CodeTemplateID = 1, Content = daoTemplate, GenCodeType = CodeType.Dao, Language = CodeLanaguage.CSharp, Name = "ctn" };
            List<String> tables = new List<string>() { "App" };
            sfs.MakeCodeForDao(tables, codeTemplate, con, "RemoteConfig", @"F:\Test\Code");
        }
    }
}
