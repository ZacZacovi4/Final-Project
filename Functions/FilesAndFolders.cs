using System;
using System.Collections.Generic;
using System.Text;
using general_test.Functions.FilesAndFoldersClasses;

namespace general_test.Functions
{
    public class FunctionsOfFilesAndFolders
    {
        private readonly ILogger logger;
        private FileAndDirCreator fileAndDirCreator;
        private FileAndDirDelete fileAndDirDelete;
        private FileAndDirRenamer fileAndDirRenamer;
        private FileCopy fileCopy;
        private FileAndDirMove fileAndDirMove;
        private FileAndDirSize fileAndDirSize;

        public FunctionsOfFilesAndFolders(ILogger logger)
        {
            this.logger = logger;
            fileAndDirCreator = new FileAndDirCreator(logger);
            fileAndDirDelete = new FileAndDirDelete(logger);
            fileAndDirRenamer = new FileAndDirRenamer(logger);
            fileCopy = new FileCopy(logger);
            fileAndDirMove = new FileAndDirMove(logger);
            fileAndDirSize = new FileAndDirSize(logger);
        }
        public void FileOrDirChoisMenu()
        {
            logger.ShowMessage($@" Выберите какую процедуру вы хотите выполнить (для выбора введите цифру варианта)
1. Создать директорию/файл. 
2. Удалить директорию/файл. 
3. Переименовать директорию/файл. 
4. Скопировать файл.
5. Перенести директорию/файл. 
6. Вычислить размер директории/файла. 
q - для выхода в главное меню. ");
        }

        public void FileOrDirectoryFunctions()
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
                        fileAndDirCreator.FileOrDirectoryCreator();
                        break;

                    case "2":
                        Console.Clear();
                        fileAndDirDelete.FileOrDirectoryDelete();
                        break;

                    case "3":
                        Console.Clear();
                        fileAndDirRenamer.FileOrDirectoryRenamer();
                        break;

                    case "4":
                        Console.Clear();
                        fileCopy.FileCopyMethod();
                        break;

                    case "5":
                        Console.Clear();
                        fileAndDirMove.FileOrDirectoryMover();
                        break;

                    case "6":
                        Console.Clear();
                        fileAndDirSize.FileOrDirectorySize();
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
