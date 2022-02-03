using System;
using System.Collections.Generic;
using System.Text;

namespace general_test
{
    public interface ILogger
    {
        void ShowMessage(string message);
    }

    public sealed class ConsoleLogger : ILogger
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
