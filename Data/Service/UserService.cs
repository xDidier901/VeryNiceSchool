using Core.Entity;
using Core.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Service
{
    public class UserService : IUserDAO
    {
        private IUserDAO UserDAO { get; set; }

        public UserService(IUserDAO userDAO)
        {
            UserDAO = userDAO;
        }

        public Dictionary<string, object> LoginUser(string username, string password)
        {
            return UserDAO.LoginUser(username, password);
        }
    }
}
