using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSearchEngine.Interfaces;

namespace TextSearchEngine.Library.ConsoleProviders
{
    public class SystemConsoleProvider : IConsoleProvider
    {
        public string ReadKey()
        {
            return Console.ReadKey().KeyChar.ToString();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string textToWrite)
        {
            Console.Write(textToWrite);
        }

        public void WriteLine(string textToWrite)
        {
            Console.WriteLine(textToWrite);
        }
    }
}
