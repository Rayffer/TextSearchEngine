using System.Collections.Generic;
using TextSearchEngine.DTO;

namespace TextSearchEngine.Interfaces
{
    public interface IFileProvider
    {
        /// <summary>
        /// Returns a <seealso cref="IEnumerable{T}"/> of <seealso cref="FileRepresentation"/> of all the files inside a directory
        /// </summary>
        /// <param name="directory">The directory in which to enumerate the files</param>
        /// <returns><seealso cref="IEnumerable{T}"/> of <seealso cref="FileRepresentation"/></returns>
        IEnumerable<FileRepresentation> GetFileRepresentationsFromDirectory(string directory);
    }
}