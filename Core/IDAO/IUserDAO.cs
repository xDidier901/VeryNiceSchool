using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IDAO
{
    public interface IUserDAO
    {
        // Verifys if the username exists in the database and compares the hash of the password with the hash stored in db.
        Dictionary<string, object> LoginUser(string username, string password);
    }
}
