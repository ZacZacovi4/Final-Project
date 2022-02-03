using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.AttributeChangeOperations
{
    sealed class ShowAttribute : GetPath
    {
        private readonly ILogger logger;
        public ShowAttribute(ILogger logger) : base(logger)

        {
            this.logger = logger;
        }
        public void ShowAttributes()
        {

            var path = CompleteFilePathInput();
            var attributes = File.GetAttributes(path);
            Console.WriteLine("Атрибуты вашего файла {0} : ", attributes);

        }
    }
}
