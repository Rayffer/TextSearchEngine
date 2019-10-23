using System.Text.RegularExpressions;
using TextSearchEngine.Interfaces;

namespace TextSearchEngine.Library.FileTextSearchers
{
    /// <summary>
    /// A class that uses Regex to search a given text in a string
    /// </summary>
    public class RegexFileTextSearcher : IFileTextSearcher
    {
        /// <summary>
        /// Counts the number of occurrences that the <paramref name="searchTerm"/> occurs in the content of the provided <paramref name="fileString"/>
        /// </summary>
        /// <param name="fileString">The string in which to search for the <paramref name="searchTerm"/> </param>
        /// <param name="searchTerm">The search term</param>
        /// <returns>The amount of occurrences that <paramref name="searchTerm"/> occurs in the file
        public int SearchOccurrences(string fileString, string searchTerm)
        {
            return Regex.Matches(fileString, searchTerm).Count;
        }
    }
}