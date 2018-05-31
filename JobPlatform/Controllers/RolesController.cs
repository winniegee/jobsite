using JobPlatform.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace JobPlatform.Controllers
{
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        [HttpPost]
        [Route("roles")]
        public IHttpActionResult Get(UserViewModel model)
        {
                //create a variable user with data from the users identity
               // var user = User.Identity;
                //create a new instance of the Dbcontext
                ApplicationDbContext context = new ApplicationDbContext();
                //give variable UserManager data from the user
                var UserManager = new UserManager<ApplicationUser> (new UserStore<ApplicationUser>(context));
               var user = UserManager.Users.FirstOrDefault(u => u.Email == model.UName );


                bool isUser = UserManager.IsInRole(user.Id, "Admin");
                //get the role of the current user
               // var s = UserManager.GetRoles(user.GetUserId());
                //check to see if the current role is Admin
                if (isUser)
                {
                //return true;
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.OK, "Admin"));
            }
                else
                {
                //return false;
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not admin"));
            }

        }
    }
}
