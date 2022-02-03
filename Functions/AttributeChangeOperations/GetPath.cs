using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.AttributeChangeOperations
{
    class GetPath
    {
        private readonly ILogger logger;
        public GetPath(ILogger logger)
        {
            this.logger = logger;
        }
        private string GeneralDirectoryInput()
        {
            logger.ShowMessage($@"Введите путь к директории в которой находиться ваш файл");
            var pathinput = Console.ReadLine();
            while (!Directory.Exists(pathinput))
            {
                Console.Clear();
                logger.ShowMessage("Ошибка ввода, вы некорректно ввели путь");
                logger.ShowMessage("Введите путь к директории в которой находиться ваш файл");
                pathinput = Console.ReadLine();
            }
            return pathinput;
        }

        protected string CompleteFilePathInput()
        {
            string fileDirPath = GeneralDirectoryInput();
            logger.ShowMessage($@"Введите имя вашего файла (с расширением по данной моделе имя.расширение) :");
            string currentFileName = Console.ReadLine();
            string completeFilePath = fileDirPath + @"\" + currentFileName;
            while (!File.Exists(completeFilePath))
            {
                Console.Clear();
                logger.ShowMessage("Ошибка ввода, вы некорректно ввели имя или такого файла не существует");
                logger.ShowMessage("Введите имя вашего файла (с расширением по данной моделе имя.расширение) :");
                currentFileName = Console.ReadLine();
                fileDirPath = GeneralDirectoryInput();
                completeFilePath = fileDirPath + @"\" + currentFileName;
            }
            return completeFilePath;
        }

        protected FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }
    }
}
