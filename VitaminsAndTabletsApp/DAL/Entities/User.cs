using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitaminsAndTabletsApp.DAL.Entities
{
    class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(IDataRecord user)
        {
            Name = (string)user["Name"];
            Email = (string)user["Email"];
            Password = (string)user["Password"];
        }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
