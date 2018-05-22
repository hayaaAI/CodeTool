using Hayaa.CodeTool.FrameworkService.MultiStorey.Config;
using Hayaa.ConfigSeed.Standard;
using System;
using System.Collections.Generic;
using System.Text;

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
