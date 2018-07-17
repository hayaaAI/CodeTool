using Hayaa.ConfigSeed.Standard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.DataCenter.Service.Config
{
    internal class ConfigHelper : ConfigTool<DataCenterServiceConfig, DataCenterServiceConfigRoot>
    {
        private static ConfigHelper _instance = new ConfigHelper();
        private ConfigHelper() : base(DefineTable.DataCenterServiceComponetID)
        {

        }

        internal static ConfigHelper Instance { get => _instance; }
    }
}
