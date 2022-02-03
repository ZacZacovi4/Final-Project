using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.FilesAndFoldersClasses
{
    class GeneralMethods
    {
        private readonly ILogger logger;
        public GeneralMethods(ILogger logger)
        {
            this.logger = logger;
        }
        protected string GeneralDirectoryInput()
        {
            var pathinput = Console.ReadLine();
            while (!Directory.Exists(pathinput))
            {
                Console.Clear();
                logger.ShowMessage("Ошибка ввода, вы некорректно ввели путь, попробуйте еще раз");
                pathinput = Console.ReadLine();
            }
            return pathinput;
        }
    }
}
