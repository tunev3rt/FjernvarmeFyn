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
    public class FeedbackRepository
    {
        private readonly string ConnectionString;
        private List<Feedback> tickets = new List<Feedback>();
        public FeedbackRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            ConnectionString = config.GetConnectionString("MyDBConnection");
        }
        public Feedback Add(Feedback feedback)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO FEEDBACK (FeedbackType, DateAndTime, PriorityLevel, InternalSystem, DescriptiveText) " +
                    "VALUES(@FeedbackType,@DateAndTime,@PriorityLevel,@InternalSystem,@DescriptiveText)" +
                    "SELECT @@IDENTITY", con))
                {
                    cmd.Parameters.Add("@FeedbackType", SqlDbType.NVarChar).Value = feedback.FeedbackType;
                    cmd.Parameters.Add("@DateAndTime", SqlDbType.DateTime).Value = feedback.FormattedDate;
                    cmd.Parameters.Add("@PriorityLevel", SqlDbType.Int).Value = feedback.PriorityLevel;
                    cmd.Parameters.Add("@InternalSystem", SqlDbType.Int).Value = feedback.InternalSystem;
                    cmd.Parameters.Add("@DescriptiveText", SqlDbType.NVarChar).Value = feedback.DescriptiveText;
                    feedback.FeedbackID = Convert.ToInt32(cmd.ExecuteScalar());
                    tickets.Add(feedback);
                }
            }
            return feedback;
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
                                FeedbackID = reader.GetInt32(0),
                                FeedbackType = reader.GetString(1),
                                FormattedDate = reader.GetDateTime(2),
                                PriorityLevel = reader.GetInt32(3),
                                InternalSystem = reader.GetInt32(4),
                                DescriptiveText = reader.GetString(5)
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
