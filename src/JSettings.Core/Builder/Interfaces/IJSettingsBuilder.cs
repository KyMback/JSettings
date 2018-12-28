namespace JSettings.Core.Builder.Interfaces
{
    public interface IJSettingsBuilder
    {
        /// <summary>
        /// Adds base path which will be used to searching settings files
        /// </summary>
        /// <param name="path">Base path</param>
        IJSettingsBuilder AddBasePath(string path);
        
        /// <summary>
        /// Adds json file which will be used for building settings
        /// </summary>
        /// <param name="name">Name of file</param>
        IJSettingsBuilder AddJsonSettingsFile(string name);

        /// <summary>
        /// Adds config for replacing environment variables in settings file
        /// </summary>
        IJSettingsBuilder UseEnvironmentVariables();

        /// <summary>
        /// Returns <see cref="JFactory{TSettings}"/>> which can be used for runtime hot settings retrieving
        /// </summary>
        /// <typeparam name="TSettings">Retrieved settings type</typeparam>
        IJFactory<TSettings> BuildJFactory<TSettings>();

        /// <summary>
        /// Returns created <see cref="TSettings"/>
        /// </summary>
        /// <typeparam name="TSettings">Retrieved settings type</typeparam>
        TSettings BuildSettings<TSettings>();
    }
}