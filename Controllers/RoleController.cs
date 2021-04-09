using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace INTEX2Mock.Controllers
{
    public class RoleController : Controller
    {

        RoleManager<IdentityRole> roleManager;
        UserManager<IdentityUser> userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        //[Authorize(Policy = "readpolicy")]
        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }
        [Authorize(Policy = "writepolicy")]
        public IActionResult CreateRole()
        {
            return View(new IdentityRole());
        }

        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> UserRoles()
        {
            ViewBag.Admin = userManager.GetUsersInRoleAsync("Admin").Result;
            ViewBag.Researcher = userManager.GetUsersInRoleAsync("Researcher").Result;
            ViewBag.Unassigned = userManager.GetUsersInRoleAsync("Unassigned").Result;

            return View();
        }

        [Authorize(Policy = "writepolicy")]
        public IActionResult EditRole(string user, string role)
        {
            var selectedUser = userManager.FindByIdAsync(user);
            ViewBag.Role = role;
            return View(selectedUser.Result);

        }

        [Authorize(Policy = "writepolicy")]
        [HttpPost]
        public async Task<IActionResult> SubmitEdits(string UserId, string newEmail, string Role, string NewRole)
        {
            var selectedRole = roleManager.FindByNameAsync(NewRole).Result;

            var selectedUser = userManager.FindByIdAsync(UserId).Result;
            selectedUser.Email = newEmail;
            selectedUser.UserName = newEmail;
            await userManager.UpdateAsync(selectedUser);

            await userManager.RemoveFromRoleAsync(selectedUser, Role);
            await userManager.AddToRoleAsync(selectedUser, selectedRole.Name);

            ViewBag.Researcher = userManager.GetUsersInRoleAsync("Researcher").Result;
            ViewBag.Admin = userManager.GetUsersInRoleAsync("Admin").Result;
            ViewBag.Unassigned = userManager.GetUsersInRoleAsync("Unassigned").Result;

            return View("UserRoles", userManager.Users.ToList());
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "writepolicy")]
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [Authorize(Policy = "writepolicy")]
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

    }
}