using Core.DTO;
using Core.Entity;
using Core.Enum;
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
    public class InstructorDAO : BaseDAO, IInstructorDAO
    {
        public Dictionary<string, object> GetAllInstructors(int gender)
        {
            try
            {
                var instructors = _context.Instructors
                    .Where(x => x.IsActive && (gender != 0 ? x.Gender == (Gender)gender : true))
                    .ToList()
                    .Select(x => new
                    {
                        x.ID,
                        x.FirstName,
                        x.LastName,
                        Gender = x.Gender.GetDescription(),
                        x.SSN,
                        Salary = string.Format("{0:C}", x.Salary)
                    });

                EnumerableActionSuccess<Object>(instructors);

            }
            catch (Exception e)
            {
                ActionError("An error ocurred while trying to get the instructors.");
            }

            return result;
        }

        public Dictionary<string, object> GetInstructorSelect()
        {
            try
            {
                var instructors = _context.Instructors
                    .Where(x => x.IsActive)
                    .ToList().Select(x => new Select2ItemDTO
                    {
                        id = x.ID,
                        text = x.FullName
                    }).ToList();

                EnumerableActionSuccess<object>(instructors);

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                ActionError("An error ocurred while trying to get the information.");
            }

            return result;
        }
    }
}
