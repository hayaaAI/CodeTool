using Hayaa.CodeTool.Service.Core.Config;
using Hayaa.RemoteConfig.Client;

namespace Hayaa.CodeTool.FrameworkService.Config
{
    internal class ConfigHelper : ConfigTool<AutoCodeServiceConfig, AutoCodeServiceConfigRoot>
    {
        private static ConfigHelper _instance = new ConfigHelper();
        private ConfigHelper() : base(DefineTable.AutoCodeServiceComponetID)
        {

        }

        internal static ConfigHelper Instance { get => _instance; }
    }
}
