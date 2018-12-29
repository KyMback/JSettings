using System.IO;
using System.Threading.Tasks;
using JSettings.Core.Builder.Interfaces;
using JSettings.Core.Builder.Interfaces.Parameters;
using JSettings.Core.Utils;
using Newtonsoft.Json.Linq;

namespace JSettings.Core
{
    public class JFactory<TSettings>: IJFactory<TSettings>
    {
        private IJSettingsBuildingConfigurations Configurations { get; }

        internal JFactory(IJSettingsBuildingConfigurations configurations)
        {
            Configurations = configurations;
        }
        
        public TSettings GetSettings()
        {
            var resultSettings = new JObject();
            
            foreach (FileRules configurationsFile in Configurations.Files)
            {
                resultSettings = GetMergedSettings(resultSettings, GetJObjectFromFile(configurationsFile.Name));
            }

            return GetSettingsWithResolvedEnvVariables(resultSettings);
        }

        public async Task<TSettings> GetSettingsAsync()
        {
            var resultSettings = new JObject();
            
            foreach (FileRules configurationsFile in Configurations.Files)
            {
                resultSettings =
                    GetMergedSettings(resultSettings, await GetJObjectFromFileAsync(configurationsFile.Name));
            }

            return GetSettingsWithResolvedEnvVariables(resultSettings);
        }

        private JObject GetMergedSettings(JObject destinationSettings, JObject newSettings)
        {
            destinationSettings.Merge(newSettings, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Concat,
                MergeNullValueHandling = MergeNullValueHandling.Ignore
            });

            return destinationSettings;
        }
        
        private JObject GetJObjectFromFile(string fileName)
        {
            using (var reader = new StreamReader(GetResultPath(fileName)))
            {
                return JObject.Parse(reader.ReadToEnd());
            }
        }
        
        private async Task<JObject> GetJObjectFromFileAsync(string fileName)
        {
            using (var reader = new StreamReader(GetResultPath(fileName)))
            {
                return JObject.Parse(await reader.ReadToEndAsync());
            }
        }

        private TSettings GetSettingsWithResolvedEnvVariables(JObject resultSettings)
        {
            return Configurations.IsEnvironmentVariablesUsed
                ? JsonSettingsParserHelper.GetSettingsWithEnvVariables<TSettings>(resultSettings)
                : resultSettings.ToObject<TSettings>();
        }

        private string GetResultPath(string fileName)
        {
            return !string.IsNullOrWhiteSpace(Configurations.BasePath)
                ? Path.Combine(Configurations.BasePath, fileName)
                : fileName;
        }
    }
}