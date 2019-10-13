using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSearchEngine.Library.FileTextSearchers;

namespace TextSearchEngine.IntegrationTest
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class RegexFileTextSearcherTest
    {
        RegexFileTextSearcher regexFileTextSearcher;

        [TestInitialize]
        public void TestInitialize()
        {
            regexFileTextSearcher = new RegexFileTextSearcher();
        }

        [TestMethod]
        public void RegexFileTextSearcher_When_Search_Lorem_In_LoremIpsum_File_Finds_Once_Occurrence()
        {
            var occurrences = regexFileTextSearcher.SearchOccurrences(System.IO.File.ReadAllText("./TestResources/LoremIpsum.txt"), "Lorem");

            Assert.AreEqual(
                occurrences,
                1,
                "RegexFileTextSearcher finds more Lorem occurrences than expected for the file {./TestResources/LoremIpsum.txt}");
        }

        [TestMethod]
        public void RegexFileTextSearcher_When_Search_Loremm_In_LoremIpsum_File_Finds_Once_Occurrence()
        {
            var occurrences = regexFileTextSearcher.SearchOccurrences(System.IO.File.ReadAllText("./TestResources/LoremIpsum.txt"), "Loremm");

            Assert.AreEqual(
                occurrences,
                0,
                "RegexFileTextSearcher finds more Lorem occurrences than expected for the file {./TestResources/LoremIpsum.txt}");
        }

    }
}
