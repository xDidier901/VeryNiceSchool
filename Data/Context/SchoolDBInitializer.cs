using Core.Entity;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class SchoolDBInitializer : CreateDatabaseIfNotExists<MainContext>
    {
        protected override void Seed(MainContext context)
        {
            var instructors = new List<Instructor>
            {
                new Instructor{ FirstName="Raymond",LastName="Holt",Gender = Gender.Male,IsActive=true,Salary=12000,SSN=12345},
                new Instructor{ FirstName="Albus",LastName="Dumbledore",Gender = Gender.Neutral,IsActive=true,Salary=14000,SSN=12245},
                new Instructor{ FirstName="Anakin",LastName="Skywalker",Gender = Gender.Male,IsActive=true,Salary=14000,SSN=00345},
                new Instructor{ FirstName="Leia",LastName="Admidala",Gender = Gender.Female,IsActive=true,Salary=11000,SSN=12344},
            };

            context.Instructors.AddRange(instructors);
            context.SaveChanges();

            var students = new List<Student>
            {
                new Student  {FirstName="Didier",LastName="Valdez",Gender=Gender.Male,BirthDate = DateTime.Now.AddYears(-23),IsActive=true},
                new Student  {FirstName="Pedro",LastName="López",Gender=Gender.Male,BirthDate = DateTime.Now.AddYears(-22),IsActive=true},
                new Student  {FirstName="Jake",LastName="Peralta",Gender=Gender.Female,BirthDate = DateTime.Now.AddYears(-33),IsActive=true},
                new Student  {FirstName="Amy",LastName="Santiago",Gender=Gender.Female,BirthDate = DateTime.Now.AddYears(-31),IsActive=true},
                new Student  {FirstName="Charles",LastName="Boyles",Gender=Gender.Neutral,BirthDate = DateTime.Now.AddYears(-30),IsActive=true},
                new Student  {FirstName="Rosa",LastName="Perez",Gender=Gender.Female,BirthDate = DateTime.Now.AddYears(-29),IsActive=true},
                new Student  {FirstName="Gina",LastName="Linetti",Gender=Gender.Female ,BirthDate = DateTime.Now.AddYears(-30),IsActive=true},
                new Student  {FirstName="Ron",LastName="Captain",Gender=Gender.Neutral,BirthDate = DateTime.Now.AddYears(-43),IsActive=true},
            };
            context.Students.AddRange(students);
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{IsActive=true, Name="Math",Credits=14,Instructor = instructors.OrderBy(x => Guid.NewGuid()).First() },
                new Course{IsActive=true, Name="Magic Potions",Credits=8,Instructor = instructors.OrderBy(x => Guid.NewGuid()).First()},
                new Course{IsActive=true, Name="Chanekes",Credits=11,Instructor = instructors.OrderBy(x => Guid.NewGuid()).First()},
                new Course{IsActive=true, Name="Cop Style",Credits=17,Instructor = instructors.OrderBy(x => Guid.NewGuid()).First()},
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            int i = -1;
            foreach (var course in courses)
            {
                var studentCourses = new List<StudentCourse> {
                    new StudentCourse{Course = course,Student = students[i+1] },
                    new StudentCourse{Course = course,Student = students[i+2] },
                    new StudentCourse{Course = course,Student = students[i+3] },
                    new StudentCourse{Course = course,Student = students[i+4] },
                    new StudentCourse{Course = course,Student = students[i+5] },
                    };
                context.StudentCourses.AddRange(studentCourses);
                i++;
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
