using ETickets.Data.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult AddRole()
        {
            return View("AddRole");
        }
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> SaveRole(RoleViewModel Model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = Model.RoleName;
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    ViewBag.Sucess = true;
                    return View("AddRole");
                }
                foreach (var i in result.Errors)
                {
                    ModelState.AddModelError("", i.Description);
                }
            }
            return View("AddRole", Model);
        }
    }
}
