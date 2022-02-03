using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace general_test.Functions.StaricData
{
    class CompleteStaticData : GeneralMethodsStaticData
    {
        private readonly ILogger logger;
        public CompleteStaticData(ILogger logger) : base(logger)
        {
            this.logger = logger;
        }
        string filePath = null;
        
        public string GetPath()
        {
            if (filePath == null)
                filePath = CompleteFilePathInput();
            return filePath;
        }
        
        public void CharCountMethod()
        {
            string path = GetPath();
            StreamReader sr = new StreamReader(path);
            string curLine;
            int count = 0;
            while ((curLine = sr.ReadLine()) != null)
            {
                count += curLine.Length;
            }
            Console.WriteLine("В вашем файле: {0} cимволов", count);
        }

        public void CharCountWithNoEmptyEntriesMethod()
        {
            string path = GetPath();
            string text = File.ReadAllText(path);
            text = Regex.Replace(text, @"[ \r\n\t]", "");
            Console.WriteLine("В вашем файле: {0} cимволов (пробелы не учтены)", text.Length);
        }

        public void StringCountMethod()
        {
            string path = GetPath();
            int count = File.ReadAllLines(path).Length;
            Console.WriteLine("В вашем файле: {0} строк.", count);
        }
        public void WordCountMethod()
        {
            string path = GetPath();
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
        public void ParagraphCountMethod()
        {
            string path = GetPath();
            string[] text = File.ReadAllLines(path);
            int paragraphes = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != "") paragraphes++;
            }
            Console.WriteLine("В вашем файле: {0} параграфов", paragraphes);
        }

        public void CompleteInfo()
        {
            WordCountMethod();
            StringCountMethod();
            ParagraphCountMethod();
            CharCountMethod();
            CharCountWithNoEmptyEntriesMethod();
        }
    }
}
