using System.Text.RegularExpressions;

namespace TextSearchEngine
{
    public static class TextFileSearcher
    {
        public static int SearchTextInFile(string fileToSearchIn, string searchText)
        {
            string fileContent = System.IO.File.ReadAllText(fileToSearchIn);
            return Regex.Matches(fileContent, searchText).Count;
        }
    }
}