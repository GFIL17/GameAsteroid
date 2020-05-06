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
    internal delegate int StringProcessor(string str);

    internal delegate void StudentProcessor(Student student);

    class Program
    {

        private static void OnStudentRemoved(Student student)
        {
            Console.WriteLine("Студент {0} был отчислен!", student.Surname);
        }

        static void Main(string[] args)
        {
            var decanat = new Decanat();

            decanat.SubscribeToAdd(RateStudent);
            decanat.SubscribeToAdd(PrintStudent);

            decanat.ItemRemoved += OnStudentRemoved;


            var rnd = new Random();

            for (var i = 1; i <= 100; i++)
                decanat.Add(new Student
                {
                    Name = $"Name {i}",
                    Surname = $"Surname {i}",
                    Patronimyc = $"Patronimyc {i}",
                    //Ratings = rnd.GetValues(rnd.Next(20, 30), 3, 6)
                });

            //foreach (var student in decanat)
            //{
            //    Console.WriteLine(student.Name);
            //}

            var student_to_remove = decanat[0];

            decanat.Remove(student_to_remove);

            var random_student = new Student { Surname = rnd.GetValue("Иванов", "Петров", "Сидоров", "Филин", "Бондарчук", "Лихачев") };


            // var random_rating = rnd.GetValue<int>(2, 3, 4, 5);  // числовой рандомайзер

            decanat.SaveToFile("decanat.csv");

            var decanat2 = new Decanat();
            decanat2.LoadFromFile("decanat.csv");

            StringProcessor str_processor = new StringProcessor(GetStringLength);

            var length = str_processor("Hello world");

            //StudentProcessor process = new StudentProcessor(PrintStudent);

            //process(random_student);

            //process = RateStudent;

            //process(random_student);

            ProcessStudents(decanat2, RateStudent);
            ProcessStudents(decanat2, PrintStudent);

            var decanat3 = new Decanat();

            ProcessStudents(decanat2, decanat3.Add);

            Console.ReadLine();

        }

        private static int GetStringLength(string str)
        {
            return str.Length;
        }

        private static void PrintStudent(Student student)
        {
            Console.WriteLine("[{0}] {1} {2} {3} - {4}", 
                student.Id, student.Surname, student.Name, student.Patronimyc, student.AverageRating);
        }

        private static void RateStudent(Student student)
        {
            var rnd = new Random();
            student.Ratings.AddRange(rnd.GetValues(5, 2, 6));
        }

        private static void ProcessStudents(IEnumerable<Student> students, StudentProcessor Processor)
        {
            foreach (var student in students)
                Processor(student);
        } 
    }
}
