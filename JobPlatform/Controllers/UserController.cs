using JobPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobPlatform.Controllers
{
    //[Authorize(Roles ="Admin")]
    [RoutePrefix("api/user")]
    [AllowAnonymous]
    public class UserController : ApiController
    {
        private UserRepo repo;

        // private UserRepo repo { get; }

        public UserController()
        {
            repo = new UserRepo();
        }
        [Route("get")]
        [HttpGet]
        public IEnumerable<ApplicationUser> Get()
        {
            
            return repo.GetUsers();
        }

       // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

    // POST api/values
    public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
