using System;
using System.IO;

namespace general_test.Functions.FilesAndFoldersClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            IRunnable manager = new FileService(logger);
            manager.Run();
        }
    }
}
