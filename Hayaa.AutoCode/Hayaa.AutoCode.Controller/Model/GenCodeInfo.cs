using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.AutoCodeController.Model
{
 public   class GenCodeInfo
    {
        public List<string> Tables { set; get; }
        public String DatabaseConnection { set; get; }
        public string DatabaseName { set; get; }
        public string CodeStorePath { set; get; }
        public int SolutionId { set; get; }
    }
}
