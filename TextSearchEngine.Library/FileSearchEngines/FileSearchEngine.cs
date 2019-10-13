using System.Linq;
using TextSearchEngine.Interfaces;
using Unity;

namespace TextSearchEngine.Library.FileSearchEngines
{
    public class FileSearchEngine : IFileSearchEngine
    {
        private readonly IFileProvider fileProvider;
        private readonly IFileTextSearcher fileTextSearcher;
        private readonly IConsoleProvider consoleProvider;

        private string exitString = "$end";

        [InjectionConstructor]
        public FileSearchEngine(IFileProvider fileProvider,
            IFileTextSearcher fileTextSearcher,
            IConsoleProvider consoleProvider)
        {
            this.fileProvider = fileProvider;
            this.fileTextSearcher = fileTextSearcher;
            this.consoleProvider = consoleProvider;
        }

        public void StartEngine(string searchDirectory)
        {
            var fileRepresentations = fileProvider.GetFileRepresentationsFromDirectory(searchDirectory);
            consoleProvider.WriteLine($"There are {fileRepresentations.Count()} files in directory {searchDirectory}");
            while (true)
            {
                consoleProvider.Write("enter the search term: ");
                string searchTerm = consoleProvider.ReadLine();
                if (string.IsNullOrEmpty(searchTerm))
                    continue;
                else if (searchTerm.Equals(exitString))
                    break;

                var searchedFiles =
                    fileRepresentations
                    .Select(fileRepresentation => (fileName: fileRepresentation.FileName, occurrences: fileTextSearcher.SearchOccurrences(fileRepresentation.Contents, searchTerm)))
                    .OrderByDescending(searchedFile => searchedFile.occurrences)
                    .Take(10)
                    .TakeWhile(searchedFile => searchedFile.occurrences > 0)
                    .ToList();

                if (!searchedFiles.Any())
                {
                    consoleProvider.WriteLine("No text in the files matching the search term was found.");
                    continue;
                }

                searchedFiles.ForEach(searchedFile =>
                {
                    consoleProvider.WriteLine(string.Format("{0} => occurrences: {1}", searchedFile.fileName, searchedFile.occurrences));
                });
            }
        }
    }
}