using System.Collections.Generic;
using JSettings.Core.Builder.Interfaces;
using JSettings.Core.Builder.Interfaces.Parameters;

namespace JSettings.Core.Builder.Implementations
{
    public class JSettingsBuilder: IJSettingsBuilder
    {
        private string BasePath { get; set; }

        private bool IsEnvironmentVariablesUsed { get; set; }
        
        private IList<FileRules> Files { get; }

        public JSettingsBuilder()
        {
            Files = new List<FileRules>();
        }
        
        public IJSettingsBuilder AddBasePath(string path)
        {
            BasePath = path;
            return this;
        }

        public IJSettingsBuilder UseEnvironmentVariables()
        {
            IsEnvironmentVariablesUsed = true;

            return this;
        }

        public IJFactory<TSettings> BuildJFactory<TSettings>()
        {
            return new JFactory<TSettings>(new JSettingsBuildingConfigurations
            {
                BasePath = BasePath,
                Files = Files,
                IsEnvironmentVariablesUsed = IsEnvironmentVariablesUsed
            });
        }

        public TSettings BuildSettings<TSettings>()
        {
            return BuildJFactory<TSettings>().GetSettings();
        }

        public IJSettingsBuilder AddJsonSettingsFile(string name)
        {
            Files.Add(new FileRules
            {
                Name = name
            });
            
            return this;
        }
    }
}