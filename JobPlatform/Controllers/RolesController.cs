//using Microsoft.AspNet.Identity.EntityFramework;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http;
//using System.Web.Security;

//namespace JobPlatform.Controllers
//{
//    [Authorize(Roles="Admin")]
//    [RoutePrefix("api/roles")]
//     public class RolesController: BaseRoleController
//     {
//        public async Task<IHttpActionResult> GetRole(string Id)
//        {
//            var role = await this.AppRoleManager.FindByIdAsync(Id);
//            if (role != null)
//            {
//                return Ok(TheModelFactory.Create(role));
//            }
//            return NotFound();
//        }

//        [Route("", Name ="GetAllRoles")]
//        public IHttpActionResult GetAllRoles()
//        {
//            var roles = this.AppRoleManager.Roles;
//            return Ok(roles);
//        }

//        [Route("create")]
//        public async Task<IHttpActionResult> Create(CreateRoleBindingModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var role = new IdentityRole { Name = model.Name };

//            var result = await this.AppRoleManager.CreateAsync(role);

//            if (!result.Succeeded)
//            {
//                return GetErrorResult(result);
//            }

//            Uri locationHeader = new Uri(Url.Link("GetRoleById", new { id = role.Id }));

//            return Created(locationHeader, TheModelFactory.Create(role));

//        }
//        public class CreateRoleBindingModel
//        {
//            [Required]
//            [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
//            [Display(Name = "Role Name")]
//            public string Name { get; set; }

//        }
//        public class ModelFactory
//        {
//            //Code removed for brevity

//            public RoleReturnModel Create(IdentityRole appRole)
//            {

//                return new RoleReturnModel
//                {
//                    Url = _UrlHelper.Link("GetRoleById", new { id = appRole.Id }),
//                    Id = appRole.Id,
//                    Name = appRole.Name
//                };
//            }
//        }

//        public class RoleReturnModel
//        {
//            public string Url { get; set; }
//            public string Id { get; set; }
//            public string Name { get; set; }
//        }
//    }
//}