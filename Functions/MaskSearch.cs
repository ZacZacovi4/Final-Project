using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using general_test.Functions.FilesAndFoldersClasses;

namespace general_test
{
    internal class MaskSearch : GeneralMethods
    {
        private readonly ILogger logger;
        public MaskSearch(ILogger logger) : base(logger)

        {
            this.logger = logger;
        }

        internal string PathInput()
        {
            logger.ShowMessage("Введите путь в директорию в которой вы хотите искать файлы по маске:");

            return GeneralDirectoryInput(); 
        }
        
        internal string MaskInput()
        {
            logger.ShowMessage("Введите маску по которой вы хотите искать файлы (например по расширению (.txt) или по ключевому слову (test)):");

            string mask = Console.ReadLine();
            string fullmask = "*" + mask + "*";
            return fullmask;
        }
        internal void FindViaMask()
        {
            string path = PathInput();
            string fullmask = MaskInput();
            string[] files_txt = Directory.GetFiles(path, fullmask, SearchOption.AllDirectories);
            logger.ShowMessage("По вашему запросу были найдены следущие файлы:");
            for (int i = 0; i < files_txt.Length; i++)
            logger.ShowMessage(files_txt[i]);
        }
    }
}
