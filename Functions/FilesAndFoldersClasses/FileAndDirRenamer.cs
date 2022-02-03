using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.FilesAndFoldersClasses
{
    sealed class FileAndDirRenamer : GeneralMethods
    {
        private readonly ILogger logger;
        public FileAndDirRenamer(ILogger logger) : base(logger)

        {
            this.logger = logger;
        }
        public string DirPathInput()
        {
            logger.ShowMessage($@"Введите путь к директории которую вы хотите переименовать (включая имя самой директории)");
            return GeneralDirectoryInput();
        }
        public string FilePathInput()
        {
            logger.ShowMessage($@"Введите путь к директории файла который вы хотите переименовать");
            return GeneralDirectoryInput();
        }
        public string CompleteFilePathInput()
        {
            string fileDirPath = FilePathInput();
            logger.ShowMessage($@"Введите имя файла который хотите переименовать (с расширением по данной моделе имя.расширение) :");
            string currentFileName = Console.ReadLine();
            string completeFilePath = fileDirPath + @"\" + currentFileName;
            while (!File.Exists(completeFilePath))
            {
                Console.Clear();
                logger.ShowMessage("Ошибка ввода, вы некорректно ввели имя или такого файла не существует");
                logger.ShowMessage("Введите имя файла который хотите переименовать (с расширением по данной моделе имя.расширение) :");
                currentFileName = Console.ReadLine();
                fileDirPath = FilePathInput();
                completeFilePath = fileDirPath + @"\" + currentFileName;
            }
            return completeFilePath;
        }
        public string NewFilePathInput()
        {
            logger.ShowMessage($@"Введите новое имя для вашего файла :");
            string newName = Console.ReadLine();
            return newName;
        }
        public string NewDirPathInput()
        {
            logger.ShowMessage($@"Введите новое имя для вашей директории :");
            string newDirName = Console.ReadLine();
            return newDirName;
        }
        public string FilePathWithNoName(ref string newValue)
        {
            var someStr = CompleteFilePathInput();
            newValue = someStr;
            var splitedString = new List<string>(someStr.Split(@"\"));
            splitedString.RemoveAt(splitedString.Count - 1);
            var result = string.Join(@"\", splitedString);
            return result;
        }
        public string DirPathWithNoName(ref string newValue)
        {
            var someStr = DirPathInput();
            newValue = someStr;
            var splitedString = new List<string>(someStr.Split(@"\"));
            splitedString.RemoveAt(splitedString.Count - 1);
            var result = string.Join(@"\", splitedString);
            return result;
        }
        public void FileRenamer()
        {
            string filepath = String.Empty;// CompleteFilePathInput();
            string filepathWithNoName = FilePathWithNoName(ref filepath);
            string newFileName = NewFilePathInput();
            string newFilePath = filepathWithNoName + @"\" + newFileName;
            try
            {
                while (File.Exists(newFilePath))
                {
                    Console.Clear();
                    logger.ShowMessage("Файл с таким именем уже существует");
                    newFileName = NewFilePathInput();
                    newFilePath = filepathWithNoName + @"\" + newFileName;
                }
                File.Move(filepath, newFilePath);
                Console.WriteLine("Ваш файл был переименован в: {0}.", newFileName);
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
        public void DirRenamer()
        {
            string dirPath = String.Empty;
            string dirPathWithNoName = DirPathWithNoName(ref dirPath);
            string newDirName = NewDirPathInput();
            string newDirPath = dirPathWithNoName + @"\" + newDirName;
            try
            {
                while (Directory.Exists(newDirPath))
                {
                    Console.Clear();
                    logger.ShowMessage("Директория с таким именем уже существует");
                    newDirPath = NewFilePathInput();
                    newDirPath = dirPathWithNoName + @"\" + newDirName;
                }
                Directory.Move(dirPath, newDirPath);
                Console.WriteLine("Ваша директория была переименован в: {0}.", newDirPath);
                if (Directory.Exists(dirPath))
                {
                    logger.ShowMessage("Изначальная директория не удалена, что не предвидено.");
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
            logger.ShowMessage($@" Выберите что вы хотите переименовать (для выбора введите цифру варианта)
1. Переименовать файл.
2. Переименовать директорию. 
q - для выхода в главное меню. ");
        }
        public void FileOrDirectoryRenamer()
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
                        FileRenamer();
                        break;

                    case "2":
                        Console.Clear();
                        DirRenamer();
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
