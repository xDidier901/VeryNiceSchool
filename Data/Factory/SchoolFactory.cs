using Core.IDAO;
using Data.DAO;
using Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Factory
{
    public class SchoolFactory
    {
        private StudentService StudentService { get; set; }
        private InstructorService InstructorService { get; set; }
        private CourseService CourseService { get; set; }
        private UserService UserService { get; set; }

        public SchoolFactory()
        {
            StudentService = new StudentService(new StudentDAO());
            InstructorService = new InstructorService(new InstructorDAO());
            CourseService = new CourseService(new CourseDAO());
            UserService = new UserService(new UserDAO());
        }

        public IStudentDAO GetStudentService()
        {
            return StudentService;
        }

        public IInstructorDAO GetInstructorService()
        {
            return InstructorService;
        }

        public ICourseDAO GetCourseService()
        {
            return CourseService;
        }

        public IUserDAO GetUserService()
        {
            return UserService;
        }
    }
}
