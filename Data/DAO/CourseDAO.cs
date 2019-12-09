using Core.Entity;
using Core.IDAO;
using Data.DAO.Base;
using Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAO
{
    public class CourseDAO : BaseDAO, ICourseDAO
    {

        public Dictionary<string, object> SaveCourse(Course course)
        {
            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // If id is 0 we create a new course
                    if (course.ID == 0)
                    {
                        CreateNewCourse(course);
                    }
                    // Else, we update the course
                    else
                    {
                        UpdateCourse(course);
                    }

                    ActionSuccess<Course>(course);
                    dbTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbTransaction.Rollback();
                    ActionError("An error ocurred while trying to save the course.");
                }
            }

            return result;
        }

        private void UpdateCourse(Course course)
        {
            var courseSaved = _context.Courses.First(x => x.ID == course.ID);
            courseSaved.Name = course.Name;
            courseSaved.Credits = course.Credits;
            courseSaved.InstructorID = course.InstructorID;
            _context.SaveChanges();
        }

        private void CreateNewCourse(Course course)
        {
            course.IsActive = true;
            _context.Courses.Add(course);
            _context.SaveChanges();

            // We add some random students just for testing purposes
            var randomStudents = _context.Students
                .Where(x => x.IsActive)
                .ToList()
                .OrderBy(x => Guid.NewGuid()).Take(5);

            foreach (var randomStudent in randomStudents)
            {
                _context.StudentCourses.Add(new StudentCourse
                {
                    Course = course,
                    Student = randomStudent
                });
            }
            _context.SaveChanges();
        }

        public Dictionary<string, object> DeleteCourseByID(int courseID)
        {
            try
            {
                var course = _context.Courses.First(x => x.ID == courseID);
                course.IsActive = false;
                _context.SaveChanges();
                ActionSuccess<Course>(null);
            }
            catch (Exception e)
            {
                ActionError("An error ocurred while trying to delete the course.");
            }

            return result;
        }

        public Dictionary<string, object> GetAllCourses()
        {
            try
            {
                var courses = _context.Courses
                    .Where(x => x.IsActive)
                    .OrderByDescending(x => x.ID)
                    .ToList()
                    .Select(x => new { x.ID, x.Name, x.Credits, x.InstructorID });

                EnumerableActionSuccess<object>(courses);
            }
            catch (Exception e)
            {
                ActionError("An error ocurred while trying to get the courses.");
            }

            return result;
        }

        public Dictionary<string, object> GetFullCourseInfo(int courseID)
        {
            try
            {
                var course = _context.Courses.First(x => x.ID == courseID);

                var students = _context.StudentCourses
                    .Where(x => x.CourseID == courseID)
                    .Select(x => x.Student)
                    .ToList()
                    .Select(x => new
                    {
                        x.ID,
                        x.FirstName,
                        x.LastName,
                        Gender = x.Gender.GetDescription(),
                        BirthDate = x.BirthDate.ToShortDateString()
                    });

                var instructorName = course.Instructor.FullName;

                result.Add("instructorName", instructorName);
                result.Add("items", students);
                result.Add("success", true);
            }
            catch (Exception e)
            {
                ActionError("An error ocurred while trying to get the course information.");
            }

            return result;
        }
    }
}
