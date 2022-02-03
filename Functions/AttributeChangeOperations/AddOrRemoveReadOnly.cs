using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace general_test.Functions.AttributeChangeOperations
{
    sealed class AddOrRemoveReadOnly : GetPath
    {
        private readonly ILogger logger;
        public AddOrRemoveReadOnly(ILogger logger) : base(logger)

        {
            this.logger = logger;
        }
        public void RemoveAttributeReadOnly()
        {
            var path = CompleteFilePathInput();

            FileAttributes attributes = File.GetAttributes(path);

            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
                File.SetAttributes(path, attributes);
                Console.WriteLine("Файл {0} теперь не имеет атрибута Только для чтения.", path);
            }
            else
            {
                Console.WriteLine("Файл {0} и так не имеет атрибута Только для чтения.", path);
            }
        }

        public void SetAttributeReadOnly()
        {
            var path = CompleteFilePathInput();

            FileAttributes attributes = File.GetAttributes(path);

            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                Console.WriteLine("Файл {0} и так имеет атрибут Только для чтения.", path);
            }
            else
            {
                File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.ReadOnly);
                Console.WriteLine("Файл {0} теперь имеет атрибут Только для чтения.", path);
            }
        }
    }
}
