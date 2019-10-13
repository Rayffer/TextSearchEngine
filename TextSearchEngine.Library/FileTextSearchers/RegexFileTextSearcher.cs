using System.Text.RegularExpressions;
using TextSearchEngine.Interfaces;

namespace TextSearchEngine.Library.FileTextSearchers
{
    public class RegexFileTextSearcher : IFileTextSearcher
    {
        public int SearchOccurrences(string fileString, string searchTerm)
        {
            return Regex.Matches(fileString, searchTerm).Count;
        }
    }
}