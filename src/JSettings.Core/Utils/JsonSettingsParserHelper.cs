using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSettings.Core.Utils
{
    public static class JsonSettingsParserHelper
    {
        private static string RegexForMatchingEnvVariables => @"\${(?<key>.*?)}";
        private static string NameOfGroup => "key";
        
        public static TSettings GetSettingsWithEnvVariables<TSettings>(JObject jObject)
        {
            var regex = new Regex(RegexForMatchingEnvVariables);
            string result = regex.Replace(jObject.ToString(), GetReplacedValue);
            
            return JsonConvert.DeserializeObject<TSettings>(result);
        }

        private static string GetReplacedValue(Match match)
        {
            string variable = Environment.GetEnvironmentVariable(match.Groups[NameOfGroup].Value);

            return string.IsNullOrWhiteSpace(variable) ? match.Value : variable;
        }
    }
}