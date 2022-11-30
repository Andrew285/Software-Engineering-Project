using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.SqlClient;
using VitaminsAndTabletsApp.DAL.Entities;
using System.Data;
using System.Xml.Linq;

namespace VitaminsAndTabletsApp.DAL
{
    static class DALL_Class
    {
        private static string connectionString = "Server=DESKTOP-BT5VFT8;Database=Vitamins&Tablets;Trusted_Connection=true";

        public static List<User> SelectUsers(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand selectUser;

                if(user.Email != null)
                {
                    selectUser = new SqlCommand("SELECT * FROM Users " +
                                             "WHERE Name = @0 AND Email = @1 AND Password = @2", conn);
                    selectUser.Parameters.Add(new SqlParameter("0", user.Name));
                    selectUser.Parameters.Add(new SqlParameter("1", user.Email));
                    selectUser.Parameters.Add(new SqlParameter("2", user.Password));
                }
                else
                {
                    selectUser = new SqlCommand("SELECT * FROM Users " +
                                                       "WHERE Name = @0 AND Password = @1", conn);
                    selectUser.Parameters.Add(new SqlParameter("0", user.Name));
                    selectUser.Parameters.Add(new SqlParameter("1", user.Password));
                }
                
                

                SqlDataReader dataRead = selectUser.ExecuteReader();
                List<User> selectedUsers = new List<User>();
                foreach(IDataRecord dbUser in dataRead)
                {
                    selectedUsers.Add(new User(dbUser));
                }

                conn.Close();
                return selectedUsers;
            }
        }

        public static void AddUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Users (Name, Email, Password) VALUES (@0, @1, @2)", conn);
                insertCommand.Parameters.Add(new SqlParameter("0", user.Name));
                insertCommand.Parameters.Add(new SqlParameter("1", user.Email));
                insertCommand.Parameters.Add(new SqlParameter("2", user.Password));
                insertCommand.ExecuteNonQuery();

                conn.Close();
            }
        }
    }
}
