using System;
using System.Collections.Generic;
using System.IO;

namespace general_test
{
    internal class DiskExplorer
    {
        private readonly ILogger logger;
        public DiskExplorer(ILogger logger)
        {
            this.logger = logger;
        }

        public void GetLogicalDrives()
        {
            string[] drives = Directory.GetLogicalDrives();

            logger.ShowMessage($@"На вашем компьютере содержаться следующие диски:");

            foreach (string str in drives)
            {
                logger.ShowMessage(str);
            }
           
        }

        public void GetFilesAndDirectoryInfo()
        {
            logger.ShowMessage("Введите путь к диску, вместилище которого вы хотите просмотреть");
            var input = Console.ReadLine();
            while (!Directory.Exists(input))
            {
                Console.Clear();
                logger.ShowMessage("Ошибка ввода, вы некорректно ввели путь");
                logger.ShowMessage("Введите путь к диску, вместилище которого вы хотите просмотреть");
                input = Console.ReadLine();
            }
            var dir = new DirectoryInfo(input); // папка с файлами 

            logger.ShowMessage($"Дириктории в директорие {dir} :");

            List<string> directories = GetDirectoryNames(dir);
            foreach (var directory in directories)
            {
                logger.ShowMessage(directory);
            }

            logger.ShowMessage($"Файлы в директорие {dir} :");

            List<string> files = GetFileNames(dir);
            foreach (var file in files)
            {
                logger.ShowMessage(file);
            }
        }
        private static List<string> GetDirectoryNames(DirectoryInfo dir)
        {
            List<string> directories = new List<string>();

            foreach (DirectoryInfo directory in dir.GetDirectories())
            {
                directories.Add(directory.Name);
            }

            return directories;
        }

        private static List<string> GetFileNames(DirectoryInfo dir)
        {
            List<string> files = new List<string>();

            foreach (FileInfo file in dir.GetFiles())
            {
                files.Add(file.FullName);
            }

            return files;
        }
    }
}