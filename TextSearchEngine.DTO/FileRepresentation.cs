namespace TextSearchEngine.DTO
{
    /// <summary>
    /// An in-memory representation of a file that holds both the file's filename and contents
    /// </summary>
    public class FileRepresentation
    {
        /// <summary>
        /// The file's filename
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// An in-memory representation of the file's content
        /// </summary>
        public string Contents { get; set; }
    }
}