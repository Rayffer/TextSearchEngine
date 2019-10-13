using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSearchEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryFiles = System.IO.Directory.GetFiles(args[0]).ToList();
            Console.WriteLine("Introduce text to search:");
            string searchTerm = Console.ReadLine();
            var searchedFiles = directoryFiles.Select(file =>
            {
                return (fileName: file, occurrences: TextFileSearcher.SearchTextInFile(file, searchTerm));
            }).OrderByDescending(searchedFile => searchedFile.occurrences).Take(10).TakeWhile(searchedFile => searchedFile.occurrences > 0).ToList();
            searchedFiles.ForEach(searchedFile =>
            {
                Console.WriteLine(string.Format("{0} => occurrences: {1}", Path.GetFileName(searchedFile.fileName), searchedFile.occurrences));
            });
            Console.WriteLine("Search finished, press any key to end the program");
            Console.ReadKey();
        }
    }
}
