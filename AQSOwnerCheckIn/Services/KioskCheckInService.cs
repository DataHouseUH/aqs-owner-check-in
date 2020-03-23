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
    }
}