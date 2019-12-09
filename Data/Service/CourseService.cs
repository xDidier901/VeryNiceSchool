using Core.Entity;
using Core.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Service
{
    public class CourseService : ICourseDAO
    {
        private ICourseDAO CourseDAO { get; set; }

        public CourseService(ICourseDAO courseDAO)
        {
            CourseDAO = courseDAO;
        }

        public Dictionary<string, object> SaveCourse(Course course)
        {
            return CourseDAO.SaveCourse(course);
        }

        public Dictionary<string, object> DeleteCourseByID(int courseID)
        {
            return CourseDAO.DeleteCourseByID(courseID);
        }

        public Dictionary<string, object> GetFullCourseInfo(int courseID)
        {
            return CourseDAO.GetFullCourseInfo(courseID);
        }

        public Dictionary<string, object> GetAllCourses()
        {
            return CourseDAO.GetAllCourses();
        }
    }
}
