using Core.Entity;
using Core.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Service
{
    public class InstructorService : IInstructorDAO
    {
        private IInstructorDAO InstructorDAO { get; set; }

        public InstructorService(IInstructorDAO instructorDAO)
        {
            InstructorDAO = instructorDAO;
        }

        public Dictionary<string, object> GetAllInstructors(int gender)
        {
            return InstructorDAO.GetAllInstructors(gender);
        }


        public Dictionary<string, object> GetInstructorSelect()
        {
            return InstructorDAO.GetInstructorSelect();
        }
    }
}
