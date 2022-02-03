using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.StaricData
{
    class WordCount : GeneralMethodsStaticData
    {
        private readonly ILogger logger;
        public WordCount(ILogger logger) : base(logger)
        {
            this.logger = logger;
        }

        public void WordCountMethod()
        {
            string path = CompleteFilePathInput();
            string s = "";
            string[] textMass;
            StreamReader sr = new StreamReader(path);

            while (sr.EndOfStream != true)
            {
                s += sr.ReadLine();
            }
            textMass = s.Split(' ');
            Console.WriteLine("В вашем файле: {0} слова.", textMass.Length);
            sr.Close();
        }
    }
}
