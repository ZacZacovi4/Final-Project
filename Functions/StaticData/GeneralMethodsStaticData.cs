using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.StaricData
{
    class GeneralMethodsStaticData
    {
        private readonly ILogger logger;
        public GeneralMethodsStaticData(ILogger logger)
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
            logger.ShowMessage($@"Введите имя вашего файла (без расширениея) :");
            string currentFileName = Console.ReadLine();
            string completeFilePath = fileDirPath + @"\" + currentFileName + @".txt";
            while (!File.Exists(completeFilePath))
            {
                Console.Clear();
                logger.ShowMessage("Ошибка ввода, вы некорректно ввели имя или такого файла не существует");
                logger.ShowMessage("Введите имя вашего файла (без расширениея) :");
                currentFileName = Console.ReadLine();
                fileDirPath = GeneralDirectoryInput();
                completeFilePath = fileDirPath + @"\" + currentFileName + @".txt";
            }
            return completeFilePath;
        }
    }
}
