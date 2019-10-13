using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextSearchEngine.DTO;
using TextSearchEngine.Interfaces;

namespace TextSearchEngine.Library.FileProviders
{
    public class SystemFileProvider : IFileProvider
    {
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