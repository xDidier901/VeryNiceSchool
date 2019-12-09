using Core.Entity;
using Core.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Service
{
    public class StudentService : IStudentDAO
    {
        private IStudentDAO StudentDAO { get; set; }

        public StudentService(IStudentDAO studentDAO)
        {
            StudentDAO = studentDAO;
        }

        public Dictionary<string, object> GetAllStudents(int gender)
        {
            return StudentDAO.GetAllStudents(gender);
        }
    }
}
