using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using TestConsole.Loggers;
using System.Diagnostics;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Logger log = new TextFileLogger("text.log");
            //Logger log = new ConsoleLogger();
            //Logger log = new DebugOutputLogger();
            //Logger log = new TraceLogger();

            
            Trace.Listeners.Add(new TextWriterTraceListener("logger.log"));
            Trace.Listeners.Add(new XmlWriterTraceListener("logger.log.xml"));

            //CombineLogger combine_log = new CombineLogger();
            CombineLogger log = new CombineLogger();
            
            log.Add(new ConsoleLogger());
            log.Add(new DebugOutputLogger());
            log.Add(new TraceLogger());
            log.Add(new TextFileLogger("new_log.log"));

            //ILogger log = combine_log;
            log.LogInformation("Message1");
            log.LogWarning("Info message");
            log.LogError("Error message");

            //ComputeLongDataValue(100, log);

            //Console.WriteLine("Программа завершена!");
            //Console.ReadLine();

            log.Flush();

            Console.ReadLine();
        }
    }    
}
