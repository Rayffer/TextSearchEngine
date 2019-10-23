using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSearchEngine.Interfaces;

namespace TextSearchEngine.Library.ConsoleProviders
{
    /// <summary>
    /// A class to use the system console to output and input information from the application wherever it is needed
    /// </summary>
    public class SystemConsoleProvider : IConsoleProvider
    {
        /// <summary>
        /// Reads the next key pressed by the user, blocks execution until a key is pressed
        /// </summary>
        /// <returns>The string representation of the pressed key</returns>
        public string ReadKey()
        {
            return Console.ReadKey().KeyChar.ToString();
        }

        /// <summary>
        /// Reads a line of text from the console, blocks execution until the enter key is pressed.
        /// </summary>
        /// <returns>The line of text written until the return key</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Writes the <paramref name="textToWrite"/> string to the console
        /// </summary>
        /// <param name="textToWrite">The text to write</param>
        public void Write(string textToWrite)
        {
            Console.Write(textToWrite);
        }

        /// <summary>
        /// Writes the <paramref name="textToWrite"/> string to the console and performs a carry return and line feed
        /// </summary>
        /// <param name="textToWrite">The text to write</param>
        public void WriteLine(string textToWrite)
        {
            Console.WriteLine(textToWrite);
        }
    }
}
