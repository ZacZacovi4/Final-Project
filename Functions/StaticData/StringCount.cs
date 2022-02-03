using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.StaricData
{
    class StringCount : GeneralMethodsStaticData
    {
        
        private readonly ILogger logger;
        public StringCount(ILogger logger) : base(logger)
        {
            this.logger = logger;
        }

        public void StringCountMethod()
        {
            string path = CompleteFilePathInput();
            int count = File.ReadAllLines(path).Length;
            Console.WriteLine("В вашем файле: {0} строк.", count);
        }
    }
}
