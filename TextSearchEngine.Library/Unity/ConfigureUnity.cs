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
    public static class ConfigureUnity
    {
        public static void ConfigureContainer(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IConsoleProvider, SystemConsoleProvider>();
            unityContainer.RegisterType<IFileTextSearcher, RegexFileTextSearcher>();
            unityContainer.RegisterType<IFileProvider, SystemFileProvider>();
            unityContainer.RegisterType<IFileSearchEngine, FileSearchEngine>();
        }
    }
}
