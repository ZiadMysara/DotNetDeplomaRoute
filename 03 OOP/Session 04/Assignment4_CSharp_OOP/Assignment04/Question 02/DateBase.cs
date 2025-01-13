using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04.Question_02
{
    internal static class DateBase
    {
        public static List<User> Users = new List<User>();

        public static bool AddUser(User user)
        {
            if (Users.Any(u => u.Username == user.Username))
            {
                return false;
            }
            Users.Add(user);
            return true;
        }
        public static bool RemoveUser(User user) {
            if (Users.Any(u => u.Username == user.Username))
            {
                Users.Remove(user);
                return true;
            }
            return false;
        }


    }
}
