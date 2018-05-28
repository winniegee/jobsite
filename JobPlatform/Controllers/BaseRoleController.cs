//using Microsoft.AspNet.Identity.Owin;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Web;
//using System.Web.Http;
//using System.Web.Mvc;
//using static JobPlatform.Models.ApplicationDbContext;

//namespace JobPlatform.Controllers
//{
//    public class BaseRoleController : ApiController
//    {
//        // GET: BaseRole
//        private ApplicationRoleManager appRoleManager = null;
//        protected ApplicationRoleManager AppRoleManager
//        {
//            get
//            {
//                return appRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
//            }
//        }
//    }
//}