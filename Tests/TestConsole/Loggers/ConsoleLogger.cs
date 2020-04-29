using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Loggers
{
    class ConsoleLogger : Logger
    {
        public override void Log(string Message)
        {
            Console.WriteLine(Message);
        }

    }
}
