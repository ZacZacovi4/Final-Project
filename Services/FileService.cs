using System;
using general_test.Functions;

namespace general_test
{
    public class FileService : IRunnable
    {
        private ILogger logger;
        private DiskExplorer diskExplorer;
        private FunctionsOfFilesAndFolders functionsOfFilesAndFolders;
        private MaskSearch maskSearch;
        private ShowStaticData showStaticData;
        private AttributeChange attributeChange;

        public FileService(ILogger logger)
        {
            this.logger = logger;

            diskExplorer = new DiskExplorer(logger);
            functionsOfFilesAndFolders = new FunctionsOfFilesAndFolders(logger);
            maskSearch = new MaskSearch(logger);
            showStaticData = new ShowStaticData(logger);
            attributeChange = new AttributeChange(logger);
        }
        
        public void Run()
        {   
            ShowMenu();
            string switchKey;
            while(true)
            {
                switchKey = Console.ReadLine().ToLower();
                switch (switchKey)
                {
                    case "1":
                        Console.Clear();
                        diskExplorer.GetLogicalDrives();
                        diskExplorer.GetFilesAndDirectoryInfo();
                        break;

                    case "2":
                        Console.Clear();
                        functionsOfFilesAndFolders.FileOrDirectoryFunctions();
                        break;

                    case "3":
                        Console.Clear();
                        maskSearch.FindViaMask();
                        break;

                    case "4":
                        Console.Clear();
                        showStaticData.ShowStaticDataMethod();
                        break;

                    case "5":
                        Console.Clear();
                        attributeChange.AttributeChangeFunctions();
                        break;

                    case "q":
                        return;
                   
                    default:
                        logger.ShowMessage($"Ошибка ввода, введите пожалуйста символ функции, которую хотите использовать.");
                        Console.Clear();
                        ShowMenu();
                        break;

                }
                
            }
        }

        public void ShowMenu()
        {
            string menu = ($@"Здраствуйте, вас приветствует Файловый сервис!
Введите цифру для выбора функции:
1. - Показать содержимое диска;
2. - Действия с папками или файлами;
3. - Поиск по маске;
4. - Показать статические данные текстовых файлов;
5. - Изменения Атрибутов Файлов;
q - выход из Файлового сервиса;");
            logger.ShowMessage(menu);
        }


    }
}
