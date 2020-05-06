using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using TestConsole.Loggers;
using System.Diagnostics;
using System.Runtime.Serialization;
using TestConsole.Service;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var decanat = new Decanat();

            var rnd = new Random();

            for (var i = 1; i <= 100; i++)
                decanat.Add(new Student
                {
                    Name = $"Name {i}",
                    Surname = $"Surname {i}",
                    Patronimyc = $"Patronimyc {i}",
                    Ratings = rnd.GetValues(rnd.Next(20, 30), 3, 6)
                });

            //var student_to_remove = decanat[0];

            //decanat.Remove(student_to_remove);

            var random_student = new Student { Name = rnd.GetValue("Иванов", "Петров", "Сидоров", "Филин", "Бондарчук", "Лихачев") };

            
            // var random_rating = rnd.GetValue<int>(2, 3, 4, 5);  // числовой рандомайзер

            Console.ReadLine();

        }
    }
}
