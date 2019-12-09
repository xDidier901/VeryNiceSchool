using Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MainContext : DbContext
    {
        public MainContext() : base()
        {
            Database.SetInitializer(new SchoolDBInitializer());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
