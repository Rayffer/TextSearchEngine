using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TextSearchEngine.Interfaces;
using TextSearchEngine.Library.FileProviders;
using TextSearchEngine.Library.FileSearchEngines;
using TextSearchEngine.Library.FileTextSearchers;

namespace TextSearchEngine.IntegrationTest
{
    [TestClass]
    public class FileSearchEngineTest
    {
        private Mock<IConsoleProvider> moqConsoleProvider;
        private FileSearchEngine fileSearchEngine;
        [TestInitialize]
        public void TestInitialize()
        {
            moqConsoleProvider = ConfigureMockConsoleProvider();

            fileSearchEngine = new FileSearchEngine(
                new SystemFileProvider(),
                new RegexFileTextSearcher(),
                moqConsoleProvider.Object);
        }

        private Mock<IConsoleProvider> ConfigureMockConsoleProvider()
        {
            var moq = new Mock<IConsoleProvider>();

            return moq;
        }

        [TestMethod]
        public void TextSearchEngine_When_Search_ipsum_Then_Two_Files_Found_Contain_It()
        {
            moqConsoleProvider
                .SetupSequence(m => m.ReadLine())
                .Returns("ipsum")
                .Returns("$end");

            fileSearchEngine.StartEngine("./TestResources");

            // We search specifically three times because writeline is called at the start of the engine,
            // and one time for each file that has at least one occurrence of the search term
            moqConsoleProvider.Verify(m => m.WriteLine(It.IsAny<string>()), Times.Exactly(3));

            // As we iterate 2 times, we check that .ReadLine() has been called on each of those iterations,
            // as well as .Write(string)
            moqConsoleProvider.Verify(m => m.ReadLine(), Times.Exactly(2));
            moqConsoleProvider.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void TextSearchEngine_When_Search_fire_Then_No_Files_Found_Contain_It()
        {
            moqConsoleProvider
                .SetupSequence(m => m.ReadLine())
                .Returns("fire")
                .Returns("$end");

            fileSearchEngine.StartEngine("./TestResources");

            // We search specifically three times because writeline is called at the start of the engine,
            // and one time for each file that has at least one occurrence of the search term
            moqConsoleProvider.Verify(m => m.WriteLine(It.IsAny<string>()), Times.Exactly(2));

            // As we iterate 2 times, we check that .ReadLine() has been called on each of those iterations,
            // as well as .Write(string)
            moqConsoleProvider.Verify(m => m.ReadLine(), Times.Exactly(2));
            moqConsoleProvider.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
