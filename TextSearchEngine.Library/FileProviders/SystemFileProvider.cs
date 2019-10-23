using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextSearchEngine.DTO;
using TextSearchEngine.Interfaces;

namespace TextSearchEngine.Library.FileProviders
{
    /// <summary>
    /// Retrieves the file/s in a directory through the native file system
    /// </summary>
    public class SystemFileProvider : IFileProvider
    {
        /// <summary>
        /// Explores a directory, compiles a list of all the files inside it, reads them 
        /// and creates a list of <seealso cref="FileRepresentation"/> from its contents and filename
        /// </summary>
        /// <param name="directory">The directory in which to search for files</param>
        /// <returns>A list of <seealso cref="FileRepresentation"/> with the associated contents and filename</returns>
        public IEnumerable<FileRepresentation> GetFileRepresentationsFromDirectory(string directory)
        {
            var files = System.IO.Directory.GetFiles(directory);

            return files.Select(file => new FileRepresentation()
            {
                Contents = File.ReadAllText(file),
                FileName = Path.GetFileNameWithoutExtension(file)
            });
        }
    }
}