using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace general_test.Functions.StaricData
{
    class CharCountWithNoEmptyEntries : GeneralMethodsStaticData
    {
        private readonly ILogger logger;
        public CharCountWithNoEmptyEntries(ILogger logger) : base(logger)
        {
            this.logger = logger;
        }

        public void CharCountWithNoEmptyEntriesMethod()
        {
            var path = CompleteFilePathInput();
            string text = File.ReadAllText(path);
            text = Regex.Replace(text, @"[ \r\n\t]", "");
            Console.WriteLine("В вашем файле: {0} cимволов (пробелы не учтены)", text.Length);
        }
    }
}
