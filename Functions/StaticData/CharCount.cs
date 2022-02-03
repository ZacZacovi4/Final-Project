using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.StaricData
{
    class CharCount : GeneralMethodsStaticData
    {
        private readonly ILogger logger;
        public CharCount(ILogger logger) : base(logger)
        {
            this.logger = logger;
        }

        public void CharCountMethod()
        {
            string path = CompleteFilePathInput();
            StreamReader sr = new StreamReader(path);
            string curLine;
            int count = 0;
            while ((curLine = sr.ReadLine()) != null)
            {
                count += curLine.Length;
            }
            Console.WriteLine("В вашем файле: {0} cимволов", count);
        }
    }
}
