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

        public static TaskResult Delete_AlertCustomMessage(KioskCheckInController.AlertCustomMessageCriteria ACMC)
        {
            Logger.Debug(string.Format("Method called."));

            // SQL QUERY
            string coreQuery = "EXEC [KioskCheckIn].[Delete_AlertCustomMessage_Proc] @AlertCustomMessageID ";

            using (var connection = new SqlConnection(InforConfig.IpsDatabaseConnectionString))
            {
                try
                {
                    // Call the query
                    Logger.Debug(string.Format("Execute SQL query: {0}", coreQuery));
                    var command = new SqlCommand(coreQuery, connection);
                    command.Parameters.AddWithValue("@AlertCustomMessageID", ACMC.AlertCustomMessageID);

                    // Open connection
                    connection.Open();

                    // Read data
                    var reader = command.ExecuteReader();

                    // Create variables to storage the data
                    var AlertCustomMessageID = new List<int>();

                    // Get data 
                    while (reader.Read())
                    {
                        // Check if it is NULL or not, if not add it to our variable
                        if (!(reader["AlertCustomMessageID"] is DBNull)) AlertCustomMessageID.Add(Convert.ToInt32(reader["AlertCustomMessageID"]));
                    }

                    // Select query successful
                    reader.Close();

                    // Display data
                    var data = new
                    {
                        AlertCustomMessageID,
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
        public static TaskResult Submit_AlertCustomMessage(KioskCheckInController.AlertCustomMessageCriteria ACMC)
        {
            Logger.Debug(string.Format("Method called."));

            // SQL QUERY
            string coreQuery = "EXEC [KioskCheckIn].[Create_Alert_Proc] NULL, @Message ";

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
                    var Status = new List<int>();

                    // Get data 
                    while (reader.Read())
                    {
                        // Check if it is NULL or not, if not add it to our variable
                        if (!(reader["Status"] is DBNull)) Status.Add(Convert.ToInt32(reader["Status"]));
                    }

                    // Select query successful
                    reader.Close();

                    // Display data
                    var data = new
                    {
                        Status
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

        //////////////////
        //// For Kiosk User
        //////////////////
        public static TaskResult View_User(KioskCheckInController.UserCriteria UCB)
        {
            Logger.Debug(string.Format("Method called."));

            // SQL QUERY
            string coreQuery = "EXEC [KioskCheckIn].[View_User_Proc] @LastName, @FirstName, @MicrochipID, @Email, @PhoneNumber ";

            using (var connection = new SqlConnection(InforConfig.IpsDatabaseConnectionString))
            {
                try
                {
                    // Call the query
                    Logger.Debug(string.Format("Execute SQL query: {0}", coreQuery));
                    var command = new SqlCommand(coreQuery, connection);
                    command.Parameters.AddWithValue("@LastName", UCB.LastName);
                    command.Parameters.AddWithValue("@FirstName", UCB.FirstName);
                    command.Parameters.AddWithValue("@MicrochipID", UCB.MicrochipID);
                    command.Parameters.AddWithValue("@Email", UCB.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", UCB.PhoneNumber);

                    // Open connection
                    connection.Open();

                    // Read data
                    var reader = command.ExecuteReader();

                    // Create variables to storage the data
                    var Status = new List<int>();
                    var Error = new List<string>();
                    var UserID = new List<int>();

                    // Get data 
                    while (reader.Read())
                    {
                        // Check if it is NULL or not, if not add it to our variable
                        if (!(reader["Status"] is DBNull)) Status.Add(Convert.ToInt32(reader["Status"]));
                        if (!(reader["Error"] is DBNull)) Error.Add(Convert.ToString(reader["Error"]));
                        if (!(reader["UserID"] is DBNull)) UserID.Add(Convert.ToInt32(reader["UserID"]));
                    }

                    // Select query successful
                    reader.Close();

                    // Display data
                    var data = new
                    {
                        Status,
                        Error,
                        UserID
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

        public static TaskResult Create_UserIsNotQualifiedUser(KioskCheckInController.UserCriteria UCB)
        {
            Logger.Debug(string.Format("Method called."));

            // SQL QUERY
            string coreQuery = "EXEC [KioskCheckIn].[Create_UserIsnotQualified_Proc] @LastName, @FirstName, @MicrochipID, @Email, @PhoneNumber ";

            using (var connection = new SqlConnection(InforConfig.IpsDatabaseConnectionString))
            {
                try
                {
                    // Call the query
                    Logger.Debug(string.Format("Execute SQL query: {0}", coreQuery));
                    var command = new SqlCommand(coreQuery, connection);
                    command.Parameters.AddWithValue("@LastName", UCB.LastName);
                    command.Parameters.AddWithValue("@FirstName", UCB.FirstName);
                    command.Parameters.AddWithValue("@MicrochipID", UCB.MicrochipID);
                    command.Parameters.AddWithValue("@Email", UCB.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", UCB.PhoneNumber);

                    // Open connection
                    connection.Open();

                    // Read data
                    var reader = command.ExecuteReader();

                    // Create variables to storage the data
                    var Status = new List<int>();
                    var Error = new List<string>();
                    var UserID = new List<int>();

                    // Get data 
                    while (reader.Read())
                    {
                        // Check if it is NULL or not, if not add it to our variable
                        if (!(reader["Status"] is DBNull)) Status.Add(Convert.ToInt32(reader["Status"]));
                        if (!(reader["Error"] is DBNull)) Error.Add(Convert.ToString(reader["Error"]));
                        if (!(reader["UserID"] is DBNull)) UserID.Add(Convert.ToInt32(reader["UserID"]));
                    }

                    // Select query successful
                    reader.Close();

                    // Display data
                    var data = new
                    {
                        Status,
                        Error,
                        UserID
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

        //////////////////
        //// For Front-End
        //////////////////
        public static TaskResult View_FrontDisplay()
        {
            Logger.Debug(string.Format("Method called."));

            // SQL QUERY
            string coreQuery = "EXEC [KioskCheckIn].[View_FrontDisplay_Proc]";

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
                    var DisplayID = new List<int>();
                    var UserDisplayName = new List<string>();
                    var StatusName = new List<string>();

                    // Get data 
                    while (reader.Read())
                    {
                        // Check if it is NULL or not, if not add it to our variable
                        if (!(reader["DisplayID"] is DBNull)) DisplayID.Add(Convert.ToInt32(reader["DisplayID"]));
                        if (!(reader["UserDisplayName"] is DBNull)) UserDisplayName.Add(Convert.ToString(reader["UserDisplayName"]));
                        if (!(reader["StatusName"] is DBNull)) StatusName.Add(Convert.ToString(reader["StatusName"]));
                    }

                    // Select query successful
                    reader.Close();

                    // Display data
                    var data = new
                    {
                        DisplayID,
                        UserDisplayName,
                        StatusName
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


        public static TaskResult Confirmation_FrontDisplay(KioskCheckInController.FrontDisplay FD)
        {
            Logger.Debug(string.Format("Method called."));

            // SQL QUERY
            string coreQuery = "EXEC [KioskCheckIn].[View_Confirmation_Proc] @UserID, @Is_Qualified";

            using (var connection = new SqlConnection(InforConfig.IpsDatabaseConnectionString))
            {
                try
                {

                    // Call the query
                    Logger.Debug(string.Format("Execute SQL query: {0}", coreQuery));
                    var command = new SqlCommand(coreQuery, connection);
                    command.Parameters.AddWithValue("@UserID", FD.UserID);
                    command.Parameters.AddWithValue("@Is_Qualified", FD.Is_Qualified);
                    // Open connection
                    connection.Open();

                    // Read data
                    var reader = command.ExecuteReader();

                    // Create variables to storage the data
                    var DisplayID = new List<int>();
                    var UserDisplayName = new List<string>();

                    // Get data 
                    while (reader.Read())
                    {
                        // Check if it is NULL or not, if not add it to our variable
                        if (!(reader["DisplayID"] is DBNull)) DisplayID.Add(Convert.ToInt32(reader["DisplayID"]));
                        if (!(reader["UserDisplayName"] is DBNull)) UserDisplayName.Add(Convert.ToString(reader["UserDisplayName"]));
                    }

                    // Select query successful
                    reader.Close();

                    // Display data
                    var data = new
                    {
                        DisplayID,
                        UserDisplayName
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

        //////////////////
        //// For Back-Display
        //////////////////
        public static TaskResult View_BackDisplay()
        {
            Logger.Debug(string.Format("Method called."));

            // SQL QUERY
            string coreQuery = "EXEC [KioskCheckIn].[View_BackDisplay_Proc]";

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
                    var BackDisplayID = new List<int>();
                    var UserDisplayName = new List<string>();
                    var PetName = new List<string>();
                    var MicroChipID = new List<string>();
                    var Is_Arrived = new List<bool>();
                    var Is_Inspected = new List<bool>();
                    var Is_Released = new List<bool>();
                    var Colour = new List<string>();

                    // Get data 
                    while (reader.Read())
                    {
                        // Check if it is NULL or not, if not add it to our variable
                        if (!(reader["BackDisplayID"] is DBNull)) BackDisplayID.Add(Convert.ToInt32(reader["BackDisplayID"]));
                        if (!(reader["UserDisplayName"] is DBNull)) UserDisplayName.Add(Convert.ToString(reader["UserDisplayName"]));
                        if (!(reader["PetName"] is DBNull)) PetName.Add(Convert.ToString(reader["PetName"]));
                        if (!(reader["MicroChipID"] is DBNull)) MicroChipID.Add(Convert.ToString(reader["MicroChipID"]));
                        if (!(reader["Is_Arrived"] is DBNull)) Is_Arrived.Add(Convert.ToBoolean(reader["Is_Arrived"]));
                        if (!(reader["Is_Inspected"] is DBNull)) Is_Inspected.Add(Convert.ToBoolean(reader["Is_Inspected"]));
                        if (!(reader["Is_Released"] is DBNull)) Is_Released.Add(Convert.ToBoolean(reader["Is_Released"]));
                        if (!(reader["Colour"] is DBNull)) Colour.Add(Convert.ToString(reader["Colour"]));
                    }

                    // Select query successful
                    reader.Close();

                    // Display data
                    var data = new
                    {
                        BackDisplayID,
                        UserDisplayName,
                        PetName,
                        MicroChipID,
                        Is_Arrived,
                        Is_Inspected,
                        Is_Released,
                        Colour
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

        public static TaskResult Update_BackDisplay(KioskCheckInController.BackDisplay BC)
        {
            Logger.Debug(string.Format("Method called."));

            // SQL QUERY
            string coreQuery = "EXEC [KioskCheckIn].[Update_BackDisplay_Proc] @BackDisplayID, @Is_Arrived, @Is_Inspected, @Is_Released ";

            using (var connection = new SqlConnection(InforConfig.IpsDatabaseConnectionString))
            {
                try
                {
                       
                    // Call the query
                    Logger.Debug(string.Format("Execute SQL query: {0}", coreQuery));
                    var command = new SqlCommand(coreQuery, connection);
                    command.Parameters.AddWithValue("@BackDisplayID", BC.BackDisplayID);
                    command.Parameters.AddWithValue("@Is_Arrived", BC.Is_Arrived ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@Is_Inspected", BC.Is_Inspected ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@Is_Released", BC.Is_Released ?? Convert.DBNull);
                    // Open connection
                    connection.Open();

                    // Read data
                    var reader = command.ExecuteReader();

                    // Create variables to storage the data
                    var Status = new List<int>();
                    var Error = new List<string>();

                    // Get data 
                    while (reader.Read())
                    {
                        // Check if it is NULL or not, if not add it to our variable
                        if (!(reader["Status"] is DBNull)) Status.Add(Convert.ToInt32(reader["Status"]));
                        if (!(reader["Error"] is DBNull)) Error.Add(Convert.ToString(reader["Error"]));
                    }

                    // Select query successful
                    reader.Close();

                    // Display data
                    var data = new
                    {
                        Status,
                        Error
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

        public static TaskResult View_Alert()
        {
            Logger.Debug(string.Format("Method called."));

            // SQL QUERY
            string coreQuery = "EXEC [KioskCheckIn].[View_Alert_Proc]";

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
                    var AlertID = new List<int>();
                    var BackDisplayID = new List<int>();
                    var Message = new List<string>();
                    var TimeCreated = new List<DateTime>();

                    // Get data 
                    while (reader.Read())
                    {
                        // Check if it is NULL or not, if not add it to our variable
                        if (!(reader["AlertID"] is DBNull)) AlertID.Add(Convert.ToInt32(reader["AlertID"]));
                        if (!(reader["BackDisplayID"] is DBNull)) BackDisplayID.Add(Convert.ToInt32(reader["BackDisplayID"]));
                        if (!(reader["Message"] is DBNull)) Message.Add(Convert.ToString(reader["Message"]));
                        if (!(reader["TimeCreated"] is DBNull)) TimeCreated.Add(Convert.ToDateTime(reader["TimeCreated"]));
                    }

                    // Select query successful
                    reader.Close();

                    // Display data
                    var data = new
                    {
                        AlertID,
                        BackDisplayID,
                        Message,
                        TimeCreated
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

        public static TaskResult Update_Alert(KioskCheckInController.BackDisplay BC)
        {
            Logger.Debug(string.Format("Method called."));

            // SQL QUERY
            string coreQuery = "EXEC [KioskCheckIn].[Update_Alert_Proc] @AlertID";

            using (var connection = new SqlConnection(InforConfig.IpsDatabaseConnectionString))
            {
                try
                {

                    // Call the query
                    Logger.Debug(string.Format("Execute SQL query: {0}", coreQuery));
                    var command = new SqlCommand(coreQuery, connection);
                    command.Parameters.AddWithValue("@AlertID", BC.AlertID);
                    // Open connection
                    connection.Open();

                    // Read data
                    var reader = command.ExecuteReader();

                    // Create variables to storage the data
                    var Status = new List<int>();
                    var Error = new List<string>();

                    // Get data 
                    while (reader.Read())
                    {
                        // Check if it is NULL or not, if not add it to our variable
                        if (!(reader["Status"] is DBNull)) Status.Add(Convert.ToInt32(reader["Status"]));
                        if (!(reader["Error"] is DBNull)) Error.Add(Convert.ToString(reader["Error"]));
                    }

                    // Select query successful
                    reader.Close();

                    // Display data
                    var data = new
                    {
                        Status,
                        Error
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