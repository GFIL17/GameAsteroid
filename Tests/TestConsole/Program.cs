﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using TestConsole.Loggers;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Logger log = new TextFileLogger("text.log");
            Logger log = new ConsoleLogger();

            log.LogInformation("Message1");
            log.LogWarning("Info message");
            log.LogError("Error message");

            log.Flush();

            Console.ReadLine();
        }
    }    
}
