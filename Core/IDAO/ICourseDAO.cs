using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IDAO
{
    public interface ICourseDAO
    {
        /// <summary>
        /// Gets all the active courses.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, object> GetAllCourses();

        /// <summary>
        /// Gets data about the course, instructor and students.
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        Dictionary<string, object> GetFullCourseInfo(int courseID);

        /// <summary>
        /// Creates or updates a course.
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Dictionary<string, object> SaveCourse(Course course);

        /// <summary>
        /// Sets a course as inactive.
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        Dictionary<string, object> DeleteCourseByID(int courseID);
    }
}
