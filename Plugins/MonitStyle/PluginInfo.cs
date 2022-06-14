using System;
using static MyNewApp.Common.PluginBase;

namespace MonitStyle
{
        public class PluginInfo : IPlugin
        {
            public string Name => "MonitStyle";
            public string Description => "示例插件介绍";
            public string Author => "作者";
        }
    
}
