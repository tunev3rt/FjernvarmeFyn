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
using FjernvarmeFynLogin.DBConnection;

namespace FjernvarmeFynLogin.Model
{
    public class UserRepository
    {
        private readonly string ConnectionString;
        private List<User> users = new List<User>();

        public UserRepository()
        {
            ConnectionString = DBConnectionManager.GetConnectionString();
        }

        public User Add(User user)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO EMPLOYEE (EmployeeEmail, FullName, Department, Passcode) " +
                    "VALUES(@EmployeeEmail,@FullName,@Department,@Passcode)",
                    con))
                {
                    cmd.Parameters.Add("@EmployeeEmail", SqlDbType.NVarChar).Value = user.Email;
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = user.Name;
                    cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = user.Department;
                    cmd.Parameters.Add("@Passcode", SqlDbType.NVarChar).Value = user.Password;
                    cmd.ExecuteNonQuery();
                }
            }
            return user;
        }

        public List<User> GetAll() 
        {
            return users;
        }
    }
}