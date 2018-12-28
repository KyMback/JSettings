using System.Collections.Generic;
using JSettings.Core.Builder.Interfaces;
using JSettings.Core.Builder.Interfaces.Parameters;

namespace JSettings.Core.Builder.Implementations
{
    public class JSettingsBuildingConfigurations: IJSettingsBuildingConfigurations
    {
        public string BasePath { get; set; }
        
        public bool IsEnvironmentVariablesUsed { get; set; }
        
        public IList<FileRules> Files { get; set; }
    }
}