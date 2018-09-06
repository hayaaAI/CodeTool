using System;
using System.Collections.Generic;

namespace Hayaa.CodeTool.Controller
{
    public class GenCodeInfo
    {
        public List<string> Tables { set; get; }
        public String DatabaseConnection { set; get; }
        public string DatabaseName { set; get; }
        public string CodeStorePath { set; get; }
        public int SolutionId { set; get; }
    }
}
