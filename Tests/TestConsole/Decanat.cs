using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestConsole
{
    internal class Decanat : Storage<Student>
    {
        public override void SaveToFile(string FileName)
        {
            using(var file_writer = File.CreateText(FileName))
                foreach(var student in this)
                {
                    file_writer.WriteLine(string.Join(",",
                        student.Surname, student.Name, student.Patronimyc,
                        string.Join(";", student.Ratings)));
                }
        }

        public override void LoadFromFile(string Filename)
        {
            base.LoadFromFile(Filename);

            using(var file_reader = File.OpenText(Filename))
                while (!file_reader.EndOfStream)
                {
                    var str = file_reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(str))
                        continue;

                    var components = str.Split(',');

                    var student = new Student
                    {
                        Surname = components[0],
                        Name = components[1],
                        Patronimyc = components[2]
                    };

                    var ratings = components[3].Split(',');
                    foreach (var rating in ratings)
                        student.Ratings.Add(int.Parse(rating));

                    Add(student);
                }
        }
    }

    internal abstract class EntityStorage<TEntity> : Storage<TEntity> 
        where TEntity : class, IEntity, new()
    {


        private int _MaxId = 1; 

        public override void Add(TEntity item)
        {
            item.Id = _MaxId++;
            base.Add(item);
        }
    }
}
