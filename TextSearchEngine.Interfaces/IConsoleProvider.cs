namespace TextSearchEngine.Interfaces
{
    /// <summary>
    /// An interface to allow outputting and inputting information into the application
    /// </summary>
    public interface IConsoleProvider
    {
        /// <summary>
        /// Writes a line to the device and performs a carry return after writting it
        /// </summary>
        /// <param name="textToWrite">The text to write</param>
        void WriteLine(string textToWrite);


        /// <summary>
        /// Writes a line to the device 
        /// </summary>
        /// <param name="textToWrite">The text to write</param>
        void Write(string textToWrite);

        /// <summary>
        /// Reads the next keystroke performed on the input device
        /// </summary>
        /// <returns>A string representation of the stroken device's key</returns>
        string ReadKey();

        /// <summary>
        /// Reads the next line performed on the input device until a carry return is performed
        /// </summary>
        /// <returns>The line of text inputted from the device</returns>
        string ReadLine();
    }
}