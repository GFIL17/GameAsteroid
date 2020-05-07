﻿using System;
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
        private const string __NamesFile = "Names.txt";

        static void Main(string[] args)
        {

            foreach (var student in GetStudents(__NamesFile))
                Console.WriteLine(student.Surname + " " + student.Name + " " + student.Patronimyc);

            Console.ReadLine();
        }

        private static IEnumerable<Student> GetStudents(string FileName)
        {
            //yield break;
            using (var file = File.OpenText(FileName))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var components = line.Split(' ');
                    if (components.Length != 3) continue;

                    var student = new Student();
                    student.Surname = components[0];
                    student.Name = components[1];
                    student.Patronimyc = components[2];

                    yield return student;
                }
            }
        }
    }
    
}
