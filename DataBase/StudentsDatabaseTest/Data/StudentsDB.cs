using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StudentsDatabaseTest.Data.Entityes;

namespace StudentsDatabaseTest.Data
{
    public class StudentsDB:DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<StudentsGroup> Groups { get; set; }

        public DbSet<Course> Courses { get; set; }

        //public StudentsDB() : this("StudentsDB") { }

        public StudentsDB() : this("name=StudentsDB") { }

        public StudentsDB(string ConnectionString) : base(ConnectionString) { }
    }
}
