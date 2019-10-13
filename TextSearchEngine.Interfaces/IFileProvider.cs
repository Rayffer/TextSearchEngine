using System.Collections.Generic;
using TextSearchEngine.DTO;

namespace TextSearchEngine.Interfaces
{
    public interface IFileProvider
    {
        IEnumerable<FileRepresentation> GetFileRepresentationsFromDirectory(string directory);
    }
}