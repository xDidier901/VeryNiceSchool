using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IDAO;
using Data.DAO.Base;
using Core.Entity;
using Core.Enum;
using Data.Utilities;

namespace Data.DAO
{
    public sealed class StudentDAO : BaseDAO, IStudentDAO
    {
        public Dictionary<string, object> GetAllStudents(int gender)
        {
            try
            {
                var students = _context.Students
                    .Where(x => x.IsActive && (gender != 0 ? x.Gender == (Gender)gender : true))
                    .ToList()
                    .Select(x => new
                    {
                        x.ID,
                        x.FirstName,
                        x.LastName,
                        Gender = x.Gender.GetDescription(),
                        BirthDate = x.BirthDate.ToShortDateString()
                    });

                EnumerableActionSuccess<object>(students);

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                ActionError("An error ocurred while trying to get the students.");
            }

            return result;
        }
    }
}
