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
    public class FeedbackRepository
    {
        private readonly string ConnectionString;
        private List<Feedback> tickets = new List<Feedback>();
        public FeedbackRepository()
        {
            ConnectionString = DBConnectionManager.GetConnectionString();
        }
        public Feedback Add(Feedback feedback)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO FEEDBACK (FeedbackType, DateAndTime, PriorityLevel, InternalSystem, DescriptiveText, FeedbackStatus, EmployeeEmail) " +
                    "VALUES(@FeedbackType,@DateAndTime,@PriorityLevel,@InternalSystem,@DescriptiveText,@FeedbackStatus,@EmployeeEmail)" +
                    "SELECT @@IDENTITY", con))
                {
                    cmd.Parameters.Add("@FeedbackType", SqlDbType.NVarChar).Value = feedback.FeedbackType;
                    cmd.Parameters.Add("@DateAndTime", SqlDbType.DateTime).Value = feedback.FormattedDate;
                    cmd.Parameters.Add("@PriorityLevel", SqlDbType.Int).Value = feedback.PriorityLevel;
                    cmd.Parameters.Add("@InternalSystem", SqlDbType.Int).Value = feedback.InternalSystem;
                    cmd.Parameters.Add("@DescriptiveText", SqlDbType.NVarChar).Value = feedback.DescriptiveText;
                    cmd.Parameters.Add("@FeedbackStatus", SqlDbType.NVarChar).Value = feedback.FeedbackStatus;
                    cmd.Parameters.Add("@EmployeeEmail", SqlDbType.NVarChar).Value = feedback.EmployeeEmail;
                    feedback.FeedbackId = Convert.ToInt32(cmd.ExecuteScalar());
                    tickets.Add(feedback);
                }
            }
            return feedback;
        }

        public void Update(Feedback feedback)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE FEEDBACK SET FeedbackType = @FeedbackType, DateAndTime = @DateAndTime, PriorityLevel = @PriorityLevel, InternalSystem = @InternalSystem, DescriptiveText = @DescriptiveText, FeedbackStatus = @FeedbackStatus WHERE FeedbackID = @FeedbackID", con))
                {
                    cmd.Parameters.Add("@FeedbackType", SqlDbType.NVarChar).Value = feedback.FeedbackType;
                    cmd.Parameters.Add("@DateAndTime", SqlDbType.DateTime).Value = feedback.FormattedDate;
                    cmd.Parameters.Add("@PriorityLevel", SqlDbType.Int).Value = feedback.PriorityLevel;
                    cmd.Parameters.Add("@InternalSystem", SqlDbType.Int).Value = feedback.InternalSystem;
                    cmd.Parameters.Add("@DescriptiveText", SqlDbType.NVarChar).Value = feedback.DescriptiveText;
                    cmd.Parameters.Add("@FeedbackStatus", SqlDbType.NVarChar).Value = feedback.FeedbackStatus;
                    cmd.Parameters.Add("@FeedbackID", SqlDbType.Int).Value = feedback.FeedbackId;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Feedback feedback)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM FEEDBACK WHERE FeedbackID = @FeedbackID", con))
                {
                    cmd.Parameters.Add("@FeedbackID", SqlDbType.Int).Value = feedback.FeedbackId;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Feedback> GetAll()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM FEEDBACK", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Feedback feedback = new Feedback()
                            {
                                FeedbackId = reader.GetInt32(0),
                                FeedbackType = reader.GetString(1),
                                FormattedDate = reader.GetDateTime(2),
                                PriorityLevel = reader.GetInt32(3),
                                InternalSystem = reader.GetInt32(4),
                                DescriptiveText = reader.GetString(5),
                                FeedbackStatus = reader.GetString(6)
                            };
                            tickets.Add(feedback);
                        }
                    }
                }
            }
            return tickets;
        }
        public List<Feedback> GetAllUnanswered()
        {
            tickets.Clear();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM FEEDBACK WHERE FeedbackStatus = @FeedbackStatus", con))
                {
                    cmd.Parameters.Add("@FeedbackStatus", SqlDbType.NVarChar).Value = "Unanswered";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Feedback feedback = new Feedback()
                            {
                                FeedbackId = reader.GetInt32(0),
                                FeedbackType = reader.GetString(1),
                                FormattedDate = reader.GetDateTime(2),
                                PriorityLevel = reader.GetInt32(3),
                                InternalSystem = reader.GetInt32(4),
                                DescriptiveText = reader.GetString(5),
                                FeedbackStatus = reader.GetString(6)
                            };
                            tickets.Add(feedback);
                        }
                    }
                }
            }
            return tickets;
        }
        public List<Feedback> GetAllAccepted()
        {
            tickets.Clear();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM FEEDBACK WHERE FeedbackStatus = @FeedbackStatus", con))
                {
                    cmd.Parameters.Add("@FeedbackStatus", SqlDbType.NVarChar).Value = "Accepted";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Feedback feedback = new Feedback()
                            {
                                FeedbackId = reader.GetInt32(0),
                                FeedbackType = reader.GetString(1),
                                FormattedDate = reader.GetDateTime(2),
                                PriorityLevel = reader.GetInt32(3),
                                InternalSystem = reader.GetInt32(4),
                                DescriptiveText = reader.GetString(5),
                                FeedbackStatus = reader.GetString(6)
                            };
                            tickets.Add(feedback);
                        }
                    }
                }
            }
            return tickets;
        }
        public List<Feedback> GetAllSolved()
        {
            tickets.Clear();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM FEEDBACK WHERE FeedbackStatus = @FeedbackStatus", con))
                {
                    cmd.Parameters.Add("@FeedbackStatus", SqlDbType.NVarChar).Value = "Solved";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Feedback feedback = new Feedback()
                            {
                                FeedbackId = reader.GetInt32(0),
                                FeedbackType = reader.GetString(1),
                                FormattedDate = reader.GetDateTime(2),
                                PriorityLevel = reader.GetInt32(3),
                                InternalSystem = reader.GetInt32(4),
                                DescriptiveText = reader.GetString(5),
                                FeedbackStatus = reader.GetString(6)
                            };
                            tickets.Add(feedback);
                        }
                    }
                }
            }
            return tickets;
        }
    }
}
