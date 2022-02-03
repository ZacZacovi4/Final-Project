using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.AttributeChangeOperations
{
    sealed class AddOrRemoveHidden : GetPath
    {
        private readonly ILogger logger;
        public AddOrRemoveHidden(ILogger logger) : base(logger)

        {
            this.logger = logger;
        }
        public void RemoveAttributeHidden()
        {
            var path = CompleteFilePathInput();

            FileAttributes attributes = File.GetAttributes(path);

            if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            {
                attributes = RemoveAttribute(attributes, FileAttributes.Hidden);
                File.SetAttributes(path, attributes);
                Console.WriteLine("Файл {0} теперь не имеет атрибута Скрытый.", path);
            }
            else
            {
                Console.WriteLine("Файл {0} и так не имеет атрибута Скрытый.", path);
            }
        }

        public void SetAttributeHidden()
        {
            var path = CompleteFilePathInput();

            FileAttributes attributes = File.GetAttributes(path);

            if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            {
                Console.WriteLine("Файл {0} и так имеет атрибут Скрытый.", path);
            }
            else
            {
                File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
                Console.WriteLine("Файл {0} теперь имеет атрибут Скрытый.", path);
            }
        }
    }
}
