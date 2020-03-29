using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AQSOwnerCheckIn.Controllers;
using AQSOwnerCheckIn.Extensions;
using AQSOwnerCheckIn.Models;
using Hansen.Billing;
using Microsoft.Ajax.Utilities;
using Hansen.CDR.Use;
using log4net;
using ILog = log4net.ILog;

namespace AQSOwnerCheckIn.Services
{
    public class KioskCheckInService
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(SampleService));

        public static TaskResult View_Users()
        {
            Logger.Debug(string.Format("Method called."));

            // SQL QUERY
            string coreQuery = "EXEC [KioskCheckIn].[View_Users_Proc]";

            using (var connection = new SqlConnection(InforConfig.IpsDatabaseConnectionString))
            {
                try
                {
                    // Call the query
                    Logger.Debug(string.Format("Execute SQL query: {0}", coreQuery));
                    var command = new SqlCommand(coreQuery, connection);

                    // Open connection
                    connection.Open();

                    // Read data
                    var reader = command.ExecuteReader();

                    // Create variables to storage the data
                    var UserID = new List<int>();
                    var FirstName = new List<string>();
                    var LastName = new List<string>();
                    var PhoneNumber = new List<string>();
                    var Email = new List<string>();

                    // Get data 
                    while (reader.Read())
                    {
                        // Check if it is NULL or not, if not add it to our variable
                        if (!(reader["UserID"] is DBNull)) UserID.Add(Convert.ToInt32(reader["UserID"]));
                        if (!(reader["FirstName"] is DBNull)) FirstName.Add(Convert.ToString(reader["FirstName"]));
                        if (!(reader["LastName"] is DBNull)) LastName.Add(Convert.ToString(reader["LastName"]));
                        if (!(reader["PhoneNumber"] is DBNull)) PhoneNumber.Add(Convert.ToString(reader["PhoneNumber"]));
                        if (!(reader["Email"] is DBNull)) Email.Add(Convert.ToString(reader["Email"]));
                    }

                    // Select query successful
                    reader.Close();

                    // Display data
                    var data = new
                    {
                        UserID,
                        FirstName,
                        LastName,
                        PhoneNumber,
                        Email
                    };

                    return TaskResult.Success(data);
                }
                catch (Exception e)
                {
                    // Log exception
                    return TaskResult.Failure(e.Message, e.StackTrace);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// FOR ALERTSCUSTOMMESSAGE
        /// </summary>
        /// <returns></returns>
        public static TaskResult View_AlertsCustomMessage()
        {
            Logger.Debug(string.Format("Method called."));

            // SQL QUERY
            string coreQuery = "EXEC [KioskCheckIn].[View_AlertCustomMessage_Proc]";

            using (var connection = new SqlConnection(InforConfig.IpsDatabaseConnectionString))
            {
                try
                {
                    // Call the query
                    Logger.Debug(string.Format("Execute SQL query: {0}", coreQuery));
                    var command = new SqlCommand(coreQuery, connection);

                    // Open connection
                    connection.Open();

                    // Read data
                    var reader = command.ExecuteReader();

                    // Create variables to storage the data
                    var AlertCustomMessageID = new List<int>();
                    var Message = new List<string>();

                    // Get data 
                    while (reader.Read())
                    {
                        // Check if it is NULL or not, if not add it to our variable
                        if (!(reader["AlertCustomMessageID"] is DBNull)) AlertCustomMessageID.Add(Convert.ToInt32(reader["AlertCustomMessageID"]));
                        if (!(reader["Message"] is DBNull)) Message.Add(Convert.ToString(reader["Message"]));
                    }

                    // Select query successful
                    reader.Close();

                    // Display data
                    var data = new
                    {
                        AlertCustomMessageID,
                        Message
                    };

                    return TaskResult.Success(data);
                }
                catch (Exception e)
                {
                    // Log exception
                    return TaskResult.Failure(e.Message, e.StackTrace);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static TaskResult Update_AlertCustomMessage(KioskCheckInController.AlertCustomMessageCriteria ACMC)
        {
            Logger.Debug(string.Format("Method called."));

            // SQL QUERY
            string coreQuery = "EXEC [KioskCheckIn].[Update_AlertCustomMessage_Proc] @AlertCustomMessageID, @Message ";

            using (var connection = new SqlConnection(InforConfig.IpsDatabaseConnectionString))
            {
                try
                {
                    // Call the query
                    Logger.Debug(string.Format("Execute SQL query: {0}", coreQuery));
                    var command = new SqlCommand(coreQuery, connection);
                    command.Parameters.AddWithValue("@AlertCustomMessageID", ACMC.AlertCustomMessageID);
                    command.Parameters.AddWithValue("@Message", ACMC.Message);

                    // Open connection
                    connection.Open();

                    // Read data
                    var reader = command.ExecuteReader();

                    // Create variables to storage the data
                    var AlertCustomMessageID = new List<int>();
                    var Message = new List<string>();

                    // Get data 
                    while (reader.Read())
                    {
                        // Check if it is NULL or not, if not add it to our variable
                        if (!(reader["AlertCustomMessageID"] is DBNull)) AlertCustomMessageID.Add(Convert.ToInt32(reader["AlertCustomMessageID"]));
                        if (!(reader["Message"] is DBNull)) Message.Add(Convert.ToString(reader["Message"]));
                    }

                    // Select query successful
                    reader.Close();

                    // Display data
                    var data = new
                    {
                        AlertCustomMessageID,
                        Message
                    };

                    return TaskResult.Success(data);
                }
                catch (Exception e)
                {
                    // Log exception
                    return TaskResult.Failure(e.Message, e.StackTrace);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static TaskResult Insert_AlertCustomMessage(KioskCheckInController.AlertCustomMessageCriteria ACMC)
        {
            Logger.Debug(string.Format("Method called."));

            // SQL QUERY
            string coreQuery = "EXEC [KioskCheckIn].[Create_AlertCustomMessage_Proc] @Message ";

            using (var connection = new SqlConnection(InforConfig.IpsDatabaseConnectionString))
            {
                try
                {
                    // Call the query
                    Logger.Debug(string.Format("Execute SQL query: {0}", coreQuery));
                    var command = new SqlCommand(coreQuery, connection);
                    command.Parameters.AddWithValue("@Message", ACMC.Message);

                    // Open connection
                    connection.Open();

                    // Read data
                    var reader = command.ExecuteReader();

                    // Create variables to storage the data
                    var Message = new List<string>();

                    // Get data 
                    while (reader.Read())
                    {
                        // Check if it is NULL or not, if not add it to our variable
                         if (!(reader["Message"] is DBNull)) Message.Add(Convert.ToString(reader["Message"]));
                    }

                    // Select query successful
                    reader.Close();

                    // Display data
                    var data = new
                    {
                        Message
                    };

                    return TaskResult.Success(data);
                }
                catch (Exception e)
                {
                    // Log exception
                    return TaskResult.Failure(e.Message, e.StackTrace);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}