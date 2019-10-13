namespace TextSearchEngine.Interfaces
{
    public interface IConsoleProvider
    {
        void WriteLine(string textToWrite);

        void Write(string textToWrite);

        string ReadKey();

        string ReadLine();
    }
}