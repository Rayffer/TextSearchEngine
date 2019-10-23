using System.Linq;
using TextSearchEngine.Interfaces;
using Unity;

namespace TextSearchEngine.Library.FileSearchEngines
{
    /// <summary>
    /// An engine that given a directory, allows to perform any amount of text searchs within the text of all the files inside it
    /// </summary>
    public class FileSearchEngine : IFileSearchEngine
    {
        private readonly IFileProvider fileProvider;
        private readonly IFileTextSearcher fileTextSearcher;
        private readonly IConsoleProvider consoleProvider;

        /// <summary>
        /// A command that signals the engine to stop and end its execution
        /// </summary>
        private readonly string exitString = "$end";

        [InjectionConstructor]
        public FileSearchEngine(IFileProvider fileProvider,
            IFileTextSearcher fileTextSearcher,
            IConsoleProvider consoleProvider)
        {
            this.fileProvider = fileProvider;
            this.fileTextSearcher = fileTextSearcher;
            this.consoleProvider = consoleProvider;
        }

        /// <summary>
        /// Starts the search engine in the directory specified by the <paramref name="searchDirectory"/> parameter and waits for user input.
        /// To stop the engine, type $end
        /// </summary>
        /// <param name="searchDirectory">The directory in which to perform the searchs</param>
        public void StartEngine(string searchDirectory)
        {
            var fileRepresentations = fileProvider.GetFileRepresentationsFromDirectory(searchDirectory);
            consoleProvider.WriteLine($"There are {fileRepresentations.Count()} files in directory {searchDirectory}");
            if (!fileRepresentations.Any())
            {
                consoleProvider.WriteLine($"Please specify a directory that has files");
                return;
            }
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
                    consoleProvider.WriteLine("No text in the files matching the search term were found.");
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