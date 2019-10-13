namespace TextSearchEngine.Interfaces
{
    public interface IFileTextSearcher
    {
        int SearchOccurrences(string fileString, string searchTerm);
    }
}