using JobPlatform.Messaging;
using JobPlatform.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using static JobPlatform.Models.ApplicationDbContext;

namespace JobPlatform.Controllers
{
    [RoutePrefix("api/mailapi")]
    public class MailApiController : ApiController
    {
        [Route("sendmail")]
        [HttpPost]

        public HttpResponseMessage SendMail(Emailview user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, "your fields are not valid");
                }

                string key = ConfigurationManager.AppSettings["Sendgrid.Key"];
                EmailService service = new EmailService(key);

                string htmlBody = $@"Dear {user.Name} ,Thank you for signing up with us. A great job awaits you. We have jobs relating to  all fields, especially your field, {user.Career}. YOU ARE WELCOME!!!";

                EmailMessage msg = new EmailMessage
                {
                    Body = htmlBody,
                    Subject = "Welcome to JOB CREATE!",
                    From = "info@jobcreate.com",
                    Recipient = user.Email
                };
                service.SendMail(msg, true);

                return Request.CreateResponse(HttpStatusCode.OK, "Successfully sent mail");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

    }
}