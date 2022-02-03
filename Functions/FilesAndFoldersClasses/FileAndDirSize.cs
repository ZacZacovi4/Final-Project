using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.FilesAndFoldersClasses
{
    sealed class FileAndDirSize : GeneralMethods
    {
        private readonly ILogger logger;
        public FileAndDirSize(ILogger logger) : base(logger)

        {
            this.logger = logger;
        }
        public string FilePathInput()
        {
            logger.ShowMessage($@"Введите путь к директории в которой находиться файл, который вы хотите переместить");
            return GeneralDirectoryInput();
        }
        public string DirPathInput()
        {
            logger.ShowMessage($@"Введите путь к директории, который вы хотите переместить");
            return GeneralDirectoryInput();
        }
        public string CompleteFilePathInput()
        {
            string fileDirPath = FilePathInput();
            logger.ShowMessage($@"Введите имя файла который хотите переместить (с расширением по данной моделе имя.расширение) :");
            string currentFileName = Console.ReadLine();
            string completeFilePath = fileDirPath + @"\" + currentFileName;
            while (!File.Exists(completeFilePath))
            {
                Console.Clear();
                logger.ShowMessage("Ошибка ввода, вы некорректно ввели имя или такого файла не существует");
                logger.ShowMessage("Введите имя файла который хотите переместить (с расширением по данной моделе имя.расширение) :");
                currentFileName = Console.ReadLine();
                fileDirPath = FilePathInput();
                completeFilePath = fileDirPath + @"\" + currentFileName;
            }
            return completeFilePath;
        }
        public string FileNameWithNoPath(ref string newValue)
        {
            var someStr = CompleteFilePathInput();
            newValue = someStr;
            var result = someStr.Remove(0, someStr.LastIndexOf(@"\") + 0);
            return result;
        }

        public void GetFileSize()
        {
            string filePath = String.Empty;
            string fileNameWithNoPath = FileNameWithNoPath(ref filePath);
            long fileSize = new FileInfo(filePath).Length;
            Console.WriteLine(@"Размер вашего файла {0} = {1} байтов.", fileNameWithNoPath, fileSize);
        }
        public void GetDirSize()
        {
            string dirPath = DirPathInput();
            DirectoryInfo dirName = new DirectoryInfo(dirPath);
            FileInfo[] fileInfos = dirName.GetFiles();
            Console.WriteLine("Эта директория {0} содержит следущие файлы:", dirName.Name);
            foreach (FileInfo file in fileInfos)
            Console.WriteLine("Размер вашего файла {0} = {1} байтов.", file.Name, file.Length);
        }

        public void FileOrDirChoisMenu()
        {
            logger.ShowMessage($@" Выберите размер чего вы хотите узнать (для выбора введите цифру варианта)
1. Размер файла.
2. Размер всех файлов в директории (не показывает поддиректории). 
q - для выхода в главное меню. ");
        }

        public void FileOrDirectorySize()
        {
            FileOrDirChoisMenu();
            string switchKey;
            while (true)
            {
                switchKey = Console.ReadLine().ToLower();
                switch (switchKey)
                {
                    case "1":
                        Console.Clear();
                        GetFileSize();
                        break;

                    case "2":
                        Console.Clear();
                        GetFileSize();
                        break;

                    case "q":
                        return;

                    default:
                        Console.Clear();
                        logger.ShowMessage($"Ошибка ввода, введите пожалуйста символ функции, которую хотите использовать.");
                        FileOrDirChoisMenu();
                        break;
                }
            }
        }
    }
}
