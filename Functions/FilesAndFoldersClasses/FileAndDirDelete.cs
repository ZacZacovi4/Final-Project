using System;
using System.IO;

namespace general_test.Functions.FilesAndFoldersClasses
{
    sealed class FileAndDirDelete : GeneralMethods
    {
        private readonly ILogger logger;
        public FileAndDirDelete(ILogger logger) : base(logger)

        {
            this.logger = logger;
        }
        public string DirPathInput()
        {
            logger.ShowMessage($@"Введите путь в директорию которую вы хотите удалить");
            return GeneralDirectoryInput();
        }

        public string FilePathInput()
        {
            logger.ShowMessage($@"Введите путь к директории в которой находиться файл, который вы хотите удалить");
            return GeneralDirectoryInput();
        }

        public string CompleteFilePathInput()
        {
            string fileDirPath = FilePathInput();
            logger.ShowMessage($@"Введите имя файла который вы хотите удалить (с расширением по данной моделе имя.расширение) :");
            string currentFileName = Console.ReadLine();
            string completeFilePath = fileDirPath + @"\" + currentFileName;
            while (!File.Exists(completeFilePath))
            {
                Console.Clear();
                logger.ShowMessage("Ошибка ввода, вы некорректно ввели имя или такого файла не существует");
                logger.ShowMessage("Введите имя файла который вы хотите удплить (с расширением по данной моделе имя.расширение) :");
                currentFileName = Console.ReadLine();
                fileDirPath = FilePathInput();
                completeFilePath = fileDirPath + @"\" + currentFileName;
            }
            return completeFilePath;
        }

        public void FileDelete()
        {
            string filepath = CompleteFilePathInput();
            try
            {   
                File.Delete(filepath);
                if (File.Exists(filepath))
                {
                    logger.ShowMessage("Ваш файл успешно удален.");
                }
                else
                {
                    logger.ShowMessage("Ваш файл не удален.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка: {0}", e.ToString());
            }
        }
        public void DirDelete()
        {
            string filepath = DirPathInput();
            try
            {
                Directory.Delete(filepath);
                if (Directory.Exists(filepath))
                {
                    logger.ShowMessage("Ваша директория успешно удален.");
                }
                else
                {
                    logger.ShowMessage("Ваша директория не удален.");
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
1. Удалить файл.
2. Удалить директорию. 
q - для выхода в главное меню. ");
        }
        public void FileOrDirectoryDelete()
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
                        FileDelete();
                        break;

                    case "2":
                        Console.Clear();
                        DirDelete();
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

