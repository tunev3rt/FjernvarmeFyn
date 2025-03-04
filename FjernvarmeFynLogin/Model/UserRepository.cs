using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration.Json;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace FjernvarmeFynLogin.Model
{
    public class UserRepository
    {
        private readonly string ConnectionString;
        private List<User> users = new List<User>();

        public UserRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            users = new List<User>();

            ConnectionString = config.GetConnectionString("MyDBConnection");
        }

        public User Add(User user)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO EMPLOYEE (Email, FullName, Department, Passcode) " +
                    "VALUES(@Email,@FullName,@Department,@Passcode)",
                    con))
                {
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = user.Name;
                    cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = user.Department;
                    cmd.Parameters.Add("@Passcode", SqlDbType.NVarChar).Value = user.Password;
                    cmd.ExecuteNonQuery();
                }
            }
            return user;
        }

        public bool LogIn(string email, string password)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM EMPLOYEE WHERE Email = @Email AND Passcode = @Passcode", con))
                {
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                    cmd.Parameters.Add("@Passcode", SqlDbType.NVarChar).Value = password;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        public List<User> GetAll() 
        {
            return users;
        }
    }
}