using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using TextSearchEngine.Library.FileProviders;

namespace TextSearchEngine.IntegrationTest
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class SystemFileProviderTest
    {
        private SystemFileProvider systemFileProvider;

        [TestInitialize]
        public void TestInitialize()
        {
            systemFileProvider = new SystemFileProvider();
        }

        [TestMethod]
        public void SystemFileProvider_When_Using_TestResources_Folder_Returns_Three_Files()
        {
            var fileRepresentation = systemFileProvider.GetFileRepresentationsFromDirectory("./TestResources");

            Assert.AreEqual(
                fileRepresentation.Count(),
                3,
                "SystemFileProvider returns more files than expected in the folder {/TestResources}");
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void SystemFileProvider_When_Using_InvalidDirectory_Throws_Exception()
        {
            var fileRepresentation = systemFileProvider.GetFileRepresentationsFromDirectory("./TestResources2");
        }
    }
}