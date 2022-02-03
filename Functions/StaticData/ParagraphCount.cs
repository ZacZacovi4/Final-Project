using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.StaricData
{
    class ParagraphCount : GeneralMethodsStaticData
    {
        private readonly ILogger logger;
        public ParagraphCount(ILogger logger) : base(logger)
        {
            this.logger = logger;
        }

        public void ParagraphCountMethod()
        {
            string path = CompleteFilePathInput();
            string[] text = File.ReadAllLines(path);
            int paragraphes = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != "") paragraphes++;
            }
            Console.WriteLine("В вашем файле: {0} параграфов", paragraphes);
        }

    }
}
