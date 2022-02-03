using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using general_test.Functions.StaricData;

namespace general_test
{
    class ShowStaticData
    {
        private readonly ILogger logger;
        private WordCount wordCount;
        private StringCount stringCount;
        private ParagraphCount paragraphCount;
        private CharCount charCount;
        private CharCountWithNoEmptyEntries charCountWithNoEmptyEntries;
        private CompleteStaticData completeStaticData;

        public ShowStaticData (ILogger logger)
        {
            this.logger = logger;
            wordCount = new WordCount(logger);
            stringCount = new StringCount(logger);
            paragraphCount = new ParagraphCount(logger);
            charCount = new CharCount(logger);
            charCountWithNoEmptyEntries = new CharCountWithNoEmptyEntries(logger);
            completeStaticData = new CompleteStaticData(logger);
        }
       public void FileOrDirChoisMenu()
        {
            logger.ShowMessage($@" Выберите какую процедуру вы хотите выполнить (для выбора введите цифру варианта)
1. Узнать количество слов в вашем файле. 
2. Узнать количество строк в вашем файле. 
3. Узнать количество параграфов в вашем файле. 
4. Узнать количество символов (с пробелами) в вашем файле.
5. Узнать количество слов (без пробелов) в вашем файле. 
6. Показать все вышеперечисленные статические данные вашего файла. 
q - для выхода в главное меню. ");
        }

        public void ShowStaticDataMethod()
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
                        wordCount.WordCountMethod();
                        break;

                    case "2":
                        Console.Clear();
                        stringCount.StringCountMethod();
                        break;

                    case "3":
                        Console.Clear();
                        paragraphCount.ParagraphCountMethod();
                        break;

                    case "4":
                        Console.Clear();
                        charCount.CharCountMethod();
                        break;

                    case "5":
                        Console.Clear();
                        charCountWithNoEmptyEntries.CharCountWithNoEmptyEntriesMethod();
                        break;

                    case "6":
                        Console.Clear();
                        completeStaticData.CompleteInfo();
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
