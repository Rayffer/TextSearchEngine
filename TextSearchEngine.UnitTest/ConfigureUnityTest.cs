using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TextSearchEngine.Interfaces;
using TextSearchEngine.Library.ConsoleProviders;
using TextSearchEngine.Library.FileProviders;
using TextSearchEngine.Library.FileSearchEngines;
using TextSearchEngine.Library.FileTextSearchers;
using TextSearchEngine.Library.Unity;
using Unity;

namespace TextSearchEngine.UnitTest
{
    [TestClass]
    public class ConfigureUnityTest
    {
        IUnityContainer unityContainer;
        public ConfigureUnityTest()
        {
            unityContainer = new UnityContainer();
            ConfigureUnity.ConfigureContainer(unityContainer);
        }

        [TestMethod]
        public void ConfigureUnity_IConsoleProvider_Resolves_SystemConsoleProvider()
        {
            var consoleProvider = unityContainer.Resolve<IConsoleProvider>();

            Assert.IsNotNull(
                consoleProvider,
                $"The interface {nameof(IConsoleProvider)}resolves a null instance");

            Assert.IsInstanceOfType(
                consoleProvider,
                typeof(SystemConsoleProvider),
                $"The default resolution for {nameof(IConsoleProvider)} resolves " +
                $"{consoleProvider.GetType().Name} instead of {nameof(SystemConsoleProvider)}");
        }

        [TestMethod]
        public void ConfigureUnity_IFileProvider_Resolves_SystemFileProvider()
        {
            var consoleProvider = unityContainer.Resolve<IFileProvider>();

            Assert.IsNotNull(
                consoleProvider,
                $"The interface {nameof(IFileProvider)}resolves a null instance");

            Assert.IsInstanceOfType(
                consoleProvider,
                typeof(SystemFileProvider),
                $"The default resolution for {nameof(IFileProvider)} resolves " +
                $"{consoleProvider.GetType().Name} instead of {nameof(SystemFileProvider)}");
        }

        [TestMethod]
        public void ConfigureUnity_IFileSearchEngine_Resolves_FileSearchEngine()
        {
            var consoleProvider = unityContainer.Resolve<IFileSearchEngine>();

            Assert.IsNotNull(
                consoleProvider,
                $"The interface {nameof(IFileSearchEngine)}resolves a null instance");

            Assert.IsInstanceOfType(
                consoleProvider,
                typeof(FileSearchEngine),
                $"The default resolution for {nameof(IFileSearchEngine)} resolves " +
                $"{consoleProvider.GetType().Name} instead of {nameof(FileSearchEngine)}");
        }

        [TestMethod]
        public void ConfigureUnity_IFileTextSearcher_Resolves_RegexFileTextSearcher()
        {
            var consoleProvider = unityContainer.Resolve<IFileTextSearcher>();

            Assert.IsNotNull(
                consoleProvider,
                $"The interface {nameof(IFileTextSearcher)}resolves a null instance");

            Assert.IsInstanceOfType(
                consoleProvider,
                typeof(RegexFileTextSearcher),
                $"The default resolution for {nameof(IFileTextSearcher)} resolves " +
                $"{consoleProvider.GetType().Name} instead of {nameof(RegexFileTextSearcher)}");
        }
    }
}
