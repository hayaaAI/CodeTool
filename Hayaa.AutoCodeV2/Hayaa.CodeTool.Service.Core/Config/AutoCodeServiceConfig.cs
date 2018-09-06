

using Hayaa.RemoteConfig.Client;

namespace Hayaa.CodeTool.Service.Core.Config
{
    public class AutoCodeServiceConfig : ConfigContent
    {
        public AppSettings AppSettings { set; get; }
        public ConnectionStrings ConnectionStrings { set; get; }
    }
}