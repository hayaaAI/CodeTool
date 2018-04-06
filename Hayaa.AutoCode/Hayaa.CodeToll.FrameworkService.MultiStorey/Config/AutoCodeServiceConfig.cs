using Hayaa.BaseModel;

namespace Hayaa.CodeToll.FrameworkService.MultiStorey.Config
{
    internal class AutoCodeServiceConfig : BaseData,ConfigContent
    {
        public AppSettings AppSettings { set; get; }
        public ConnectionStrings ConnectionStrings { set; get; }
    }
}