using System;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using AQSOwnerCheckIn.Extensions;
using AQSOwnerCheckIn.Models;
using AQSOwnerCheckIn.Services;
using Hansen.CDR.Use;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using ILog = log4net.ILog;

namespace AQSOwnerCheckIn.Controllers
{
    public class KioskCheckInController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(SampleController));

        ////////////////////
        /// Check The type of HTTP 
        /// GET, POST, PUT, DELETE
        ////////////////////
        [HttpPost]
        // Change name of action. (Match the WebApiConfig)
        [ActionName("FindUser")]
        public Response Search()
        {
            Logger.Debug("Method called.");
            var user = UserSession.GetCurrent();

            {
                // User Securities
                Logger.Info(string.Format("Called by ({0},{1})", user.Username, user.IpsUserKey));

                // Called the SQL Query
                var taskResult = KioskCheckInService.View_Users();

                if (taskResult.Result.HasFailed)
                {
                    Logger.Error(string.Format("({0},{1}) [{2}] {3} Stack: {4}", user.Username, user.IpsUserKey, taskResult.Result.Code, taskResult.Result.Message, taskResult.Result.Stack));
                    Logger.Info("200 Success response sent with failure message.");
                    return Response.Failure(taskResult.Result.Message);
                }

                Logger.Info("200 Success response sent.");
                return Response.Success(taskResult.Data);
            }

            Logger.Info("401 Unauthorized response sent.");
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        //////////////////
        //// For Alert
        //////////////////

        public class AlertCustomMessageCriteria
        {
            [JsonProperty(PropertyName = "AlertCustomMessageID")]
            public string AlertCustomMessageID { get; set; }

            [JsonProperty(PropertyName = "Message")]
            public string Message { get; set; }
        }

        [HttpPost]
        // Change name of action. (Match the WebApiConfig)
        [ActionName("ViewAlertCustomMessage")]
        public Response ViewAlertCustomMessage()
        {
            Logger.Debug("Method called.");
            var user = UserSession.GetCurrent();

            {
                // User Securities
                Logger.Info(string.Format("Called by ({0},{1})", user.Username, user.IpsUserKey));

                // Called the SQL Query
                var taskResult = KioskCheckInService.View_AlertsCustomMessage();

                if (taskResult.Result.HasFailed)
                {
                    Logger.Error(string.Format("({0},{1}) [{2}] {3} Stack: {4}", user.Username, user.IpsUserKey, taskResult.Result.Code, taskResult.Result.Message, taskResult.Result.Stack));
                    Logger.Info("200 Success response sent with failure message.");
                    return Response.Failure(taskResult.Result.Message);
                }

                Logger.Info("200 Success response sent.");
                return Response.Success(taskResult.Data);
            }

            Logger.Info("401 Unauthorized response sent.");
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        [HttpPost]
        // Change name of action. (Match the WebApiConfig)
        [ActionName("UpdateAlertCustomMessage")]
        public Response UpdateAlertCustomMessage([FromBody] AlertCustomMessageCriteria ACMB)
        {
            Logger.Debug("Method called.");
            var user = UserSession.GetCurrent();

            {
                // User Securities
                Logger.Info(string.Format("Called by ({0},{1})", user.Username, user.IpsUserKey));

                // Called the SQL Query
                var taskResult = KioskCheckInService.Update_AlertCustomMessage(ACMB);

                if (taskResult.Result.HasFailed)
                {
                    Logger.Error(string.Format("({0},{1}) [{2}] {3} Stack: {4}", user.Username, user.IpsUserKey, taskResult.Result.Code, taskResult.Result.Message, taskResult.Result.Stack));
                    Logger.Info("200 Success response sent with failure message.");
                    return Response.Failure(taskResult.Result.Message);
                }

                Logger.Info("200 Success response sent.");
                return Response.Success(taskResult.Data);
            }

            Logger.Info("401 Unauthorized response sent.");
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        [HttpPost]
        // Change name of action. (Match the WebApiConfig)
        [ActionName("InsertAlertCustomMessage")]
        public Response InsertAlertCustomMessage([FromBody] AlertCustomMessageCriteria ACMB)
        {
            Logger.Debug("Method called.");
            var user = UserSession.GetCurrent();

            {
                // User Securities
                Logger.Info(string.Format("Called by ({0},{1})", user.Username, user.IpsUserKey));

                // Called the SQL Query
                var taskResult = KioskCheckInService.Insert_AlertCustomMessage(ACMB);

                if (taskResult.Result.HasFailed)
                {
                    Logger.Error(string.Format("({0},{1}) [{2}] {3} Stack: {4}", user.Username, user.IpsUserKey, taskResult.Result.Code, taskResult.Result.Message, taskResult.Result.Stack));
                    Logger.Info("200 Success response sent with failure message.");
                    return Response.Failure(taskResult.Result.Message);
                }

                Logger.Info("200 Success response sent.");
                return Response.Success(taskResult.Data);
            }

            Logger.Info("401 Unauthorized response sent.");
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        [HttpPost]
        // Change name of action. (Match the WebApiConfig)
        [ActionName("DeleteAlertCustomMessage")]
        public Response DeleteAlertCustomMessage([FromBody] AlertCustomMessageCriteria ACMB)
        {
            Logger.Debug("Method called.");
            var user = UserSession.GetCurrent();

            {
                // User Securities
                Logger.Info(string.Format("Called by ({0},{1})", user.Username, user.IpsUserKey));

                // Called the SQL Query
                var taskResult = KioskCheckInService.Delete_AlertCustomMessage(ACMB);

                if (taskResult.Result.HasFailed)
                {
                    Logger.Error(string.Format("({0},{1}) [{2}] {3} Stack: {4}", user.Username, user.IpsUserKey, taskResult.Result.Code, taskResult.Result.Message, taskResult.Result.Stack));
                    Logger.Info("200 Success response sent with failure message.");
                    return Response.Failure(taskResult.Result.Message);
                }

                Logger.Info("200 Success response sent.");
                return Response.Success(taskResult.Data);
            }

            Logger.Info("401 Unauthorized response sent.");
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        //////////////////
        //// For Kiosk User
        //////////////////
        public class UserCriteria
        {
            [JsonProperty(PropertyName = "LastName")]
            public string LastName { get; set; }

            [JsonProperty(PropertyName = "FirstName")]
            public string FirstName { get; set; }

            [JsonProperty(PropertyName = "MicrochipID")]
            public string MicrochipID { get; set; }

            [JsonProperty(PropertyName = "Email")]
            public string Email { get; set; }

            [JsonProperty(PropertyName = "PhoneNumber")]
            public string PhoneNumber { get; set; }
        }

        [HttpPost]
        // Change name of action. (Match the WebApiConfig)
        [ActionName("IsUserAuthorized")]
        public Response IsUserAuthorized([FromBody] UserCriteria UCB)
        {
            Logger.Debug("Method called.");
            var user = UserSession.GetCurrent();

            {
                // User Securities
                Logger.Info(string.Format("Called by ({0},{1})", user.Username, user.IpsUserKey));

                // Called the SQL Query
                var taskResult = KioskCheckInService.View_User(UCB);

                if (taskResult.Result.HasFailed)
                {
                    Logger.Error(string.Format("({0},{1}) [{2}] {3} Stack: {4}", user.Username, user.IpsUserKey, taskResult.Result.Code, taskResult.Result.Message, taskResult.Result.Stack));
                    Logger.Info("200 Success response sent with failure message.");
                    return Response.Failure(taskResult.Result.Message);
                }

                Logger.Info("200 Success response sent.");
                return Response.Success(taskResult.Data);
            }

            Logger.Info("401 Unauthorized response sent.");
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        //////////////////
        //// For Front Display
        //////////////////
        public class FrontDisplay
        {
            [JsonProperty(PropertyName = "LastName")]
            public string LastName { get; set; }

            [JsonProperty(PropertyName = "FirstName")]
            public string FirstName { get; set; }

            [JsonProperty(PropertyName = "Status")]
            public string Status { get; set; }

            [JsonProperty(PropertyName = "PhoneNumber")]
            public string PhoneNumber { get; set; }
        }

        [HttpPost]
        // Change name of action. (Match the WebApiConfig)
        [ActionName("ViewFrontDisplay")]
        public Response ViewFrontDisplay()
        {
            Logger.Debug("Method called.");
            var user = UserSession.GetCurrent();

            {
                // User Securities
                Logger.Info(string.Format("Called by ({0},{1})", user.Username, user.IpsUserKey));

                // Called the SQL Query
                var taskResult = KioskCheckInService.View_FrontDisplay();

                if (taskResult.Result.HasFailed)
                {
                    Logger.Error(string.Format("({0},{1}) [{2}] {3} Stack: {4}", user.Username, user.IpsUserKey, taskResult.Result.Code, taskResult.Result.Message, taskResult.Result.Stack));
                    Logger.Info("200 Success response sent with failure message.");
                    return Response.Failure(taskResult.Result.Message);
                }

                Logger.Info("200 Success response sent.");
                return Response.Success(taskResult.Data);
            }

            Logger.Info("401 Unauthorized response sent.");
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }


    }
}