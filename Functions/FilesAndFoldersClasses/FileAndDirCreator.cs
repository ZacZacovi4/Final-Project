using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.FilesAndFoldersClasses
{
    sealed class FileAndDirCreator : GeneralMethods
    {
        private readonly ILogger logger;
        public FileAndDirCreator(ILogger logger) : base(logger)

        {
            this.logger = logger;
        }
        public void FileCreation()
        {
            string path = PathInput();
            logger.ShowMessage($@"Введите имя для вашего нового текствого файла :");
            string name = Console.ReadLine();
            string filename = path + @"\" + name + @".txt";

            try
            {
                while (File.Exists(filename))
                {
                    logger.ShowMessage("Файл с таким именем уже существует");
                    logger.ShowMessage($@"Введите имя для вашего нового текствого файла :");
                    name = Console.ReadLine();
                    filename = path + @"\" + name + @".txt";
                }
                File.Create(filename);
                TextWriter tw = new StreamWriter(filename);
                Console.WriteLine("Файл " + name + " был удачно создан в {0}.", Directory.GetCreationTime(filename));

                tw.WriteLine("Первая линия файла");
                tw.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Процесс потерпел неудачу: {0}", e.ToString());
            }
        }

        public void DirectoryCreation()
        {
            // Specify the directory you want to manipulate.
            string path = PathInput();
            logger.ShowMessage($@"Введите имя для вашей новой директории :");
            string name = Console.ReadLine();
            string filename = path + @"\" + name;

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(filename))
                {
                    logger.ShowMessage("Такая директория уже существует");
                    logger.ShowMessage($@"Введите имя для вашего нового текствого файла :");
                    name = Console.ReadLine();
                    filename = path + @"\" + name;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(filename);
                Console.WriteLine("Директория " + name + " была удачно создана в {0}.", Directory.GetCreationTime(filename)); ;

            }
            catch (Exception e)
            {
                Console.WriteLine("Процесс потерпел неудачу: {0}", e.ToString());
            }
        }

        public string PathInput()
        {
            logger.ShowMessage($@"Введите путь к директории в которой вы хотите создать файл");
            return GeneralDirectoryInput();
        }

        public void FileOrDirChoisMenu()
        {
            logger.ShowMessage($@" Выберите какой тип файла вы хотите создать (для выбора введите цифру варианта
1. Создать текстовый файл.
2. Создать директорию. 
q - для выхода в главное меню. ");
        }

        public void FileOrDirectoryCreator()
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
                        FileCreation();
                        break;

                    case "2":
                        Console.Clear();
                        DirectoryCreation();
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
