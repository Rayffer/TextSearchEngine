using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSearchEngine.Interfaces;
using TextSearchEngine.Library.ConsoleProviders;
using TextSearchEngine.Library.FileProviders;
using TextSearchEngine.Library.FileSearchEngines;
using TextSearchEngine.Library.FileTextSearchers;
using Unity;

namespace TextSearchEngine.Library.Unity
{
    /// <summary>
    /// This class intends to expose a method which fills the container provided as a parameter with all of the dependencies
    /// that this class declares
    /// </summary>
    public static class ConfigureUnity
    {
        /// <summary>
        /// Registers all the dependencies this method declares in the container passed as the parameter of the method
        /// </summary>
        /// <param name="unityContainer">The container in which to declare dependencies</param>
        public static void ConfigureContainer(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IConsoleProvider, SystemConsoleProvider>();
            unityContainer.RegisterType<IFileTextSearcher, RegexFileTextSearcher>();
            unityContainer.RegisterType<IFileProvider, SystemFileProvider>();
            unityContainer.RegisterType<IFileSearchEngine, FileSearchEngine>();
        }
    }
}
