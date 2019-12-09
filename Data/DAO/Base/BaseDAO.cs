using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Context;
using System.Threading.Tasks;
using static Core.Messages.RequestMessages; // Static import
namespace Data.DAO.Base
{
    public abstract class BaseDAO
    {
        protected MainContext _context;

        protected Dictionary<string, object> result;

        protected BaseDAO()
        {
            _context = new MainContext();
            result = new Dictionary<string, object>();
        }

        protected void ActionSuccess<T>(T item, string message = "")
        {
            result.Add(Success, true);
            result.Add(Item, item);
            if (!string.IsNullOrEmpty(message))
            {
                result.Add(Message, message);
            }
        }

        protected void EnumerableActionSuccess<T>(IEnumerable<T> items, string message = "")
        {
            result.Add(Success, true);
            result.Add(Items, items);
            if (!string.IsNullOrEmpty(message))
            {
                result.Add(Message, message);
            }
        }

        protected void ActionError(string message = "")
        {
            result.Clear();
            result.Add(Success, false);
            if (!string.IsNullOrEmpty(message))
            {
                result.Add(Message, message);
            }
        }


    }
}
