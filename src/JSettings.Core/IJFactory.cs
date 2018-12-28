using System.Threading.Tasks;

namespace JSettings.Core
{
    public interface IJFactory<TSettings>
    {
        /// <summary>
        /// Returns settings
        /// </summary>
        TSettings GetSettings();
        
        /// <summary>
        /// Asynchronously returns settings 
        /// </summary>
        /// <returns></returns>
        Task<TSettings> GetSettingsAsync();
    }
}