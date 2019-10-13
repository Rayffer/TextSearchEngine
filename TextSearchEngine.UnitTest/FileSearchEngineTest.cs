using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TextSearchEngine.DTO;
using TextSearchEngine.Interfaces;
using TextSearchEngine.Library.FileSearchEngines;

namespace TextSearchEngine.UnitTest
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class FileSearchEngineTest
    {
        private Fixture specimenBuilders;
        private Mock<IFileProvider> moqFileProvider;
        private Mock<IFileTextSearcher> moqFileTextSearcher;
        private Mock<IConsoleProvider> moqConsoleProvider;

        private IFileSearchEngine fileSearchEngine;

        public FileSearchEngineTest()
        {
            specimenBuilders = new Fixture();
        }

        private Mock<IConsoleProvider> ConfigureMockConsoleProvider()
        {
            var moq = new Mock<IConsoleProvider>();

            moq.Setup(m => m.ReadLine())
                .Returns(specimenBuilders.Create<string>());

            moq.Setup(m => m.ReadKey())
                .Returns(specimenBuilders.Create<string>());

            return moq;
        }

        private Mock<IFileTextSearcher> ConfigureMockFileTextSearcher()
        {
            var moq = new Mock<IFileTextSearcher>();

            moq.Setup(m => m.SearchOccurrences(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(specimenBuilders.Create<int>());

            return moq;
        }

        private Mock<IFileProvider> ConfigureMockFileProvider()
        {
            var moq = new Mock<IFileProvider>();

            return moq;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            moqFileProvider = ConfigureMockFileProvider();
            moqFileTextSearcher = ConfigureMockFileTextSearcher();
            moqConsoleProvider = ConfigureMockConsoleProvider();

            fileSearchEngine = new FileSearchEngine(
                moqFileProvider.Object,
                moqFileTextSearcher.Object,
                moqConsoleProvider.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            moqConsoleProvider.VerifyNoOtherCalls();
            moqFileProvider.VerifyNoOtherCalls();
            moqFileTextSearcher.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void FileSearchEngine_When_DirectoryHasFilesThatMatch_Then_Performs_Search()
        {
            var fileRepresentations = specimenBuilders.CreateMany<FileRepresentation>().ToList();
            moqFileProvider.Setup(m => m.GetFileRepresentationsFromDirectory(It.IsAny<string>()))
                .Returns(fileRepresentations);

            moqConsoleProvider.SetupSequence(m => m.ReadLine())
                .Returns(specimenBuilders.Create<string>())
                .Returns("$end");

            fileSearchEngine.StartEngine("TestDirectory");

            moqFileProvider.Verify(m => m.GetFileRepresentationsFromDirectory(It.IsAny<string>()), Times.Once);
            moqFileTextSearcher.Verify(m => m.SearchOccurrences(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(fileRepresentations.Count));
            // We check that the console writes as many lines in this case as there are files in the directory + the initial WriteLine at the beggining of the method
            moqConsoleProvider.Verify(m => m.WriteLine(It.IsAny<string>()), Times.Exactly(1 + fileRepresentations.Count));
            // We check that these methods has been called twice as we iterate 2 times through the engine loop
            moqConsoleProvider.Verify(m => m.ReadLine(), Times.Exactly(2));
            moqConsoleProvider.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void FileSearchEngine_When_DirectoryHasFilesThatDoNotMatch_Then_Performs_Search()
        {
            var fileRepresentations = specimenBuilders.CreateMany<FileRepresentation>().ToList();
            moqFileProvider.Setup(m => m.GetFileRepresentationsFromDirectory(It.IsAny<string>()))
                .Returns(fileRepresentations);

            moqFileTextSearcher.Setup(m => m.SearchOccurrences(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(0);

            moqConsoleProvider.SetupSequence(m => m.ReadLine())
                .Returns(specimenBuilders.Create<string>())
                .Returns("$end");

            fileSearchEngine.StartEngine("TestDirectory");

            moqFileProvider.Verify(m => m.GetFileRepresentationsFromDirectory(It.IsAny<string>()), Times.Once);
            moqFileTextSearcher.Verify(m => m.SearchOccurrences(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(fileRepresentations.Count));
            // We check that the console writes the initial line and the one that informs that no files in the directory match
            moqConsoleProvider.Verify(m => m.WriteLine(It.IsAny<string>()), Times.Exactly(2));
            // We check that these methods has been called twice as we iterate 2 times through the engine loop
            moqConsoleProvider.Verify(m => m.ReadLine(), Times.Exactly(2));
            moqConsoleProvider.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void FileSearchEngine_When_EmptyDirectorySpecified_Then_Not_Performs_Search()
        {
            moqFileProvider.Setup(m => m.GetFileRepresentationsFromDirectory(It.IsAny<string>()))
                .Returns(new List<FileRepresentation>());

            moqConsoleProvider.SetupSequence(m => m.ReadLine())
                .Returns(specimenBuilders.Create<string>())
                .Returns("$end");

            fileSearchEngine.StartEngine("TestDirectory");

            moqFileProvider.Verify(m => m.GetFileRepresentationsFromDirectory(It.IsAny<string>()), Times.Once);
            moqFileTextSearcher.Verify(m => m.SearchOccurrences(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            // We check that the console writes the initial line and the one that informs that no files were found in the directory
            moqConsoleProvider.Verify(m => m.WriteLine(It.IsAny<string>()), Times.Exactly(2));
            // We check that these methods has been called twice as we iterate 2 times through the engine loop
            moqConsoleProvider.Verify(m => m.ReadLine(), Times.Never);
            moqConsoleProvider.Verify(m => m.Write(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void FileSearchEngine_When_EmptySearchTerm_Then_Not_Performs_Search()
        {
            var fileRepresentations = specimenBuilders.CreateMany<FileRepresentation>().ToList();
            moqFileProvider.Setup(m => m.GetFileRepresentationsFromDirectory(It.IsAny<string>()))
                .Returns(fileRepresentations);

            moqConsoleProvider.SetupSequence(m => m.ReadLine())
                .Returns(string.Empty)
                .Returns("$end");

            fileSearchEngine.StartEngine("TestDirectory");

            moqFileProvider.Verify(m => m.GetFileRepresentationsFromDirectory(It.IsAny<string>()), Times.Once);
            // We check that the console writes only one line as no searchs are performed in this case
            moqConsoleProvider.Verify(m => m.WriteLine(It.IsAny<string>()), Times.Once);
            // We check that these methods has been called twice as we iterate 2 times through the engine loop
            moqConsoleProvider.Verify(m => m.ReadLine(), Times.Exactly(2));
            moqConsoleProvider.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void FileSearchEngine_When_EndEngineStringRead_Then_Not_Performs_Search()
        {
            var fileRepresentations = specimenBuilders.CreateMany<FileRepresentation>().ToList();
            moqFileProvider.Setup(m => m.GetFileRepresentationsFromDirectory(It.IsAny<string>()))
                .Returns(fileRepresentations);

            moqConsoleProvider.SetupSequence(m => m.ReadLine())
                .Returns("$end");

            fileSearchEngine.StartEngine("TestDirectory");

            moqFileProvider.Verify(m => m.GetFileRepresentationsFromDirectory(It.IsAny<string>()), Times.Once);
            // We check that the console writes only one line as no searchs are performed in this case
            moqConsoleProvider.Verify(m => m.WriteLine(It.IsAny<string>()), Times.Once);
            // We check that these methods has been called twice as we iterate 2 times through the engine loop
            moqConsoleProvider.Verify(m => m.ReadLine(), Times.Once);
            moqConsoleProvider.Verify(m => m.Write(It.IsAny<string>()), Times.Once);
        }
    }
}