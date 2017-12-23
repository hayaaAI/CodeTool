using Hayaa.CodeTemplateEngine;
using Hayaa.ModelService;
using System;
using System.Web.Razor;
using Xunit;

namespace Hayaa.CodeTemplateENgine.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            BussinessModel t = new BussinessModel();
            GeneratorResults r= CodeEnginServer.Generate(t.GetType(), "using ");
            String sr = r.Document.ToString();
        }
    }
}
