using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // //Player player1 = new Player();
            // //player1.Name = "Georgy";
            // //player1.Birthday = new DateTime(1993, 04, 17, 0, 0, 0);

            ////Player player1 = new Player("Empty", new DateTime(1993, 04, 17));

            ////Console.Write("Введите фамилию >");
            ////player1.Name = Console.ReadLine();

            ////Console.WriteLine(player1.Name);

            // Vector2D v1 = new Vector2D(5, 7);
            // Vector2D v2 = new Vector2D(-7, 2);

            // Vector2D v3 = v1 + v2;

            // Vector2D v4 = v3 + 3.14159265358979;

            // // устанавливаем культуру

            //     CultureInfo ru = new CultureInfo("ru-ru");
            //     CultureInfo en_us = new CultureInfo("en_us");
            //     CultureInfo invariant = CultureInfo.InvariantCulture;
            //     CultureInfo current = CultureInfo.CurrentCulture;
            //     CultureInfo current_ui = CultureInfo.CurrentUICulture;

            // // double pi = 3.1415;
            // double pi = double.Parse("3,1415");

            // int i = (int) pi;


            // double length = (double) v4;

            Printer printer = new Printer();
            PrefixPrinter prefix_printer = new PrefixPrinter();
            prefix_printer.Prefix = "FIL";

            prefix_printer.Print("QWE");
            
            printer.Print("Hello World!");
            prefix_printer.PrintData(3.14);

            printer.Print("123");

            printer = prefix_printer;

            Console.ReadLine();
        }
    }
}
