using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.FilesAndFoldersClasses
{
    sealed class FileAndDirMove : GeneralMethods
    {
        private readonly ILogger logger;
        public FileAndDirMove(ILogger logger) : base(logger)

        {
            this.logger = logger;
        }
        public string DirPathInput()
        {
            logger.ShowMessage($@"Введите путь в директорию которую вы хотите переместить");
            return GeneralDirectoryInput();
        }

        public string FilePathInput()
        {
            logger.ShowMessage($@"Введите путь к директории в которой находиться файл, который вы хотите переместить");
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
        
        public string NewFilePathInput()
        {
            logger.ShowMessage($@"Введите путь куда вы хотите перенести ваш файл :");
            return GeneralDirectoryInput();
        }
        public string NewDirPathInput()
        {
            logger.ShowMessage($@"Введите путь куда вы хотите перенести вашу директорию :");
            return GeneralDirectoryInput();
        }
        public string FileNameWithNoPath(ref string newValue)
        {
            var someStr = CompleteFilePathInput();
            newValue = someStr;
            var result = someStr.Remove(0, someStr.LastIndexOf(@"\") + 0);
            return result;           
        }
        public string DirNameWithNoPath(ref string newValue)
        {
            var someStr = DirPathInput();
            newValue = someStr;
            var result = someStr.Remove(0, someStr.LastIndexOf(@"\") + 0);
            return result;
        }
        public void FileMover()
        {
            string filepath = String.Empty;
            string fileNameWithNoPath = FileNameWithNoPath(ref filepath);
            string newFilePath = NewFilePathInput();
            string newFullFilePath = newFilePath + fileNameWithNoPath;
            try
            {
                while (File.Exists(newFullFilePath))
                {
                    Console.Clear();
                    logger.ShowMessage("Файл с таким именем уже существует в этой директории");
                    newFilePath = NewFilePathInput();
                    newFullFilePath = newFilePath + fileNameWithNoPath;
                }
                File.Move(filepath, newFullFilePath);
                Console.WriteLine("Ваш файл бы перемещен в {0}.", newFilePath);
                if (File.Exists(filepath))
                {
                    logger.ShowMessage("Изначальный файл не удален, что не предвидено.");
                }
                else
                {
                    logger.ShowMessage("Изначальный файл удален, что предвидено.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Процесс потерпел неудачу: {0}", e.ToString());
            }
        }
        public void DirMover()
        {
            string dirPath = String.Empty;
            string dirPathWithNoName = DirNameWithNoPath(ref dirPath);
            string newDirPath = NewDirPathInput();
            string newDirFullPath = newDirPath + dirPathWithNoName;
            try
            {
                while (Directory.Exists(newDirFullPath))
                {
                    Console.Clear();
                    logger.ShowMessage("Директория с таким именем уже существует в этой директории");
                    newDirFullPath = NewFilePathInput();
                    newDirFullPath = newDirPath + dirPathWithNoName;
                }
                Directory.Move(dirPath, newDirFullPath);
                Console.WriteLine("Your directory was moved to {0}.", newDirPath);
                if (Directory.Exists(dirPath))
                {
                    logger.ShowMessage("Изначальная директория не удалена, что не предвидено");
                }
                else
                {
                    logger.ShowMessage("Изначальная директория удалена, что предвидено.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Процесс потерпел неудачу: {0}", e.ToString());
            }

        }
        public void FileOrDirChoisMenu()
        {
            logger.ShowMessage($@" Выберите что вы хотите переместить (для выбора введите цифру варианта)
1. Перенести файл.
2. Перенести директорию. 
q - для выхода в главное меню. ");
        }
        public void FileOrDirectoryMover()
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
                        FileMover();
                        break;

                    case "2":
                        Console.Clear();
                        DirMover();
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
