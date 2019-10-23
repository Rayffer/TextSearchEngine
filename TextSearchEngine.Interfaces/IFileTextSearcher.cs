namespace TextSearchEngine.Interfaces
{
    public interface IFileTextSearcher
    {
        /// <summary>
        /// Counts the number of <paramref name="searchTerm"/> occurrences inside <paramref name="fileString"/>
        /// </summary>
        /// <param name="fileString">The file or file contents in which to perform the searchs</param>
        /// <param name="searchTerm">The search term</param>
        /// <returns>The amount of occurrences that <paramref name="searchTerm"/> occurs in the file/returns>
        int SearchOccurrences(string fileString, string searchTerm);
    }
}