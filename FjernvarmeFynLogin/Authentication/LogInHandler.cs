using FjernvarmeFynLogin.DBConnection;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FjernvarmeFynLogin.Authentication
{
    public static class LogInHandler
    {
        private static readonly string ConnectionString = DBConnectionManager.GetConnectionString();
        public static bool LogIn(string email, string password)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM MANAGER WHERE ManagerEmail = @ManagerEmail AND Passcode = @Passcode", con))
                {
                    cmd.Parameters.Add("@ManagerEmail", SqlDbType.NVarChar).Value = email;
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

        public static bool LogIn2(string email, string password)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM EMPLOYEE WHERE EmployeeEmail = @EmployeeEmail AND Passcode = @Passcode", con))
                {
                    cmd.Parameters.Add("@EmployeeEmail", SqlDbType.NVarChar).Value = email;
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
    }
}
