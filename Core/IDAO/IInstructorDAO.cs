using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IDAO
{
    public interface IInstructorDAO
    {
        /// <summary>
        /// Gets all the instructors.
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        Dictionary<string, object> GetAllInstructors(int gender);

        /// <summary>
        /// Gets all the instructors in a list format to show on a select list.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, object> GetInstructorSelect();
    }
}
