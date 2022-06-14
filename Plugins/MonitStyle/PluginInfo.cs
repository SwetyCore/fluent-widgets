using System;
using static MyNewApp.Common.PluginBase;

namespace PluginExample
{
        public class PluginInfo : IPlugin
        {
            public string Name => "示例插件";
            public string Description => "示例插件介绍";
            public string Author => "作者";
        }
    
}
