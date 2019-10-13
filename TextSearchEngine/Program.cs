using System;
using System.Linq;
using TextSearchEngine.Interfaces;
using TextSearchEngine.Library.Unity;
using Unity;

namespace TextSearchEngine
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var container = new UnityContainer();
            ConfigureUnity.ConfigureContainer(container);

            var searchEngine = container.Resolve<IFileSearchEngine>();

            searchEngine.StartEngine(args[0]);
        }
    }
}