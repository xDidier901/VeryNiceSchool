using Core.Entity;
using Core.Enum;
using Core.IDAO;
using Data.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAO
{
    public class UserDAO : BaseDAO, IUserDAO
    {
        public Dictionary<string, object> LoginUser(string username, string password)
        {
            try
            {
                // Cause of time issues I'm leaving this hardcoded.
                if (username == "user" && password == "1234")
                {
                    result.Add("UserType", UserType.Normal);
                }
                else if (username == "admin" || password == "4321")
                {
                    result.Add("UserType", UserType.Admin);
                }
                else
                {
                    ActionError("Invalid user.");
                    return result;
                }

                result.Add("url", "/Courses");
                ActionSuccess<User>(null);
            }
            catch (Exception)
            {
                ActionError("An error ocurred while trying to verify the user information.");
            }

            return result;
        }
    }
}
