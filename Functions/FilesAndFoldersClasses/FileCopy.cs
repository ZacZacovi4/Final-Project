using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.FilesAndFoldersClasses
{
    sealed class FileCopy : GeneralMethods
    {
        private readonly ILogger logger;
        public FileCopy(ILogger logger) : base(logger)

        {
            this.logger = logger;
        }
        public string FilePathInput()
        {
            logger.ShowMessage($@"Введите путь к директории в которой находиться файл, который вы хотите скопировать");
            return GeneralDirectoryInput();
        }
        public string CompleteFilePathInput()
        {
            string fileDirPath = FilePathInput();
            logger.ShowMessage($@"Введите имя файла который хотите скопировать (с расширением по данной моделе имя.расширение) :");
            string currentFileName = Console.ReadLine();
            string completeFilePath = fileDirPath + @"\" + currentFileName;
            while (!File.Exists(completeFilePath))
            {
                Console.Clear();
                logger.ShowMessage("Ошибка ввода, вы некорректно ввели имя или такого файла не существует");
                logger.ShowMessage("Введите имя файла который вы хотите скопировать (с расширением по данной моделе имя.расширение) :");
                currentFileName = Console.ReadLine();
                fileDirPath = FilePathInput();
                completeFilePath = fileDirPath + @"\" + currentFileName;
            }
            return completeFilePath;
        }

        public string NewFilePathInput()
        {
            logger.ShowMessage($@"Введите путь куда вы хотите скопировать ваш файл :");
            return GeneralDirectoryInput();
        }
        public string FileNameWithNoPath(ref string newValue)
        {
            var someStr = CompleteFilePathInput();
            newValue = someStr;
            var result = someStr.Remove(0, someStr.LastIndexOf(@"\") + 0);
            return result;
        }
        public void FileCopyMethod()
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
                File.Copy(filepath, newFullFilePath);
                Console.WriteLine("Ваш файл был скопирован в: {0}.", newFilePath);
                if (!File.Exists(filepath))
                {
                    logger.ShowMessage("Изначальный файл удален, что не предвидено.");
                }
                else
                {
                    logger.ShowMessage("Изначальный файл не удален, что предвидено.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Процесс потерпел неудачу: {0}", e.ToString());
            }
        }
    }
}

