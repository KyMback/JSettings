using System.Collections.Generic;
using JSettings.Core.Builder.Interfaces.Parameters;

namespace JSettings.Core.Builder.Interfaces
{
    public interface IJSettingsBuildingConfigurations
    {
        string BasePath { get; set; }
        
        /// <summary>
        /// Indicating that need to replace env variables with appropriate keys in settings
        /// </summary>
        bool IsEnvironmentVariablesUsed { get; set; }
        
        /// <summary>
        /// Collection of files for building
        /// </summary>
        IList<FileRules> Files { get; set; }
    }
}