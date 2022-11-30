using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitaminsAndTabletsApp.DAL;
using VitaminsAndTabletsApp.DAL.Entities;

namespace VitaminsAndTabletsApp.BLL.Authorization
{
    static class AuthClass
    {
        
        public static string SignIn(string login, string password)
        {
            List<User> users = DALL_Class.SelectUsers(new User(login, password));
            if (users.Count == 0)
            {
                return "Please, sign up firstly";
            }
            else
            {
                //Logged into the system
                return "You are in the system";
            }
        }


        public static string SignUp(string login, string email, string password)
        {
            User user = new User(login, email, password);
            List<User> users = DALL_Class.SelectUsers(user);

            if (users.Count == 0)
            {
                DALL_Class.AddUser(user);
                return "You are signed up!. Please sign in";
            }
            else
            {
                return "You are signed up!. Please sign in";
            }
        }
    }
}
