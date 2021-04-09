/*using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppAuthAndAuthorize.Controllers
{
	public class RoleController : Controller
	{
		private RoleManager<IdentityRole> _roleManager;

        private UserManager<IdentityRole> _userManager;


        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityRole> userManager)
		{
			_roleManager = roleManager;
            _userManager = userManager;
		}

		public IActionResult Index()
		{
			var roles = _roleManager.Roles.ToList();
			return View(roles);
		}

		public IActionResult Create()
		{
			return View(new IdentityRole());
		}

		[HttpPost]
		public async Task<IActionResult> Create(IdentityRole role)
		{
			await _roleManager.CreateAsync(role);
			return RedirectToAction("Index");
		}

        public async Task<IActionResult> UserRoles()
        {
            ViewBag.Admin = _userManager.GetUsersInRoleAsync("Admin").Result;
            ViewBag.User = _userManager.GetUsersInRoleAsync("User").Result;
            ViewBag.Unassigned = _userManager.GetUsersInRoleAsync("Unassigned").Result;

            return View();
        }

        public IActionResult EditRole(string user, string role)
        {
            var selectedUser = _userManager.FindByIdAsync(user);
            ViewBag.Role = role;
            return View(selectedUser.Result);
        }
        [HttpPost]
        public async Task<IActionResult> SubmitEdits(string UserId, string newEmail, string Role, string NewRole)
        {
            var selectedRole = _roleManager.FindByNameAsync(NewRole).Result;

            var selectedUser = _userManager.FindByIdAsync(UserId).Result;
            selectedUser.Email = newEmail;
            selectedUser.UserName = newEmail;
            await _userManager.UpdateAsync(selectedUser);

            await _userManager.RemoveFromRoleAsync(selectedUser, Role);
            await _userManager.AddToRoleAsync(selectedUser, selectedRole.Name);

            ViewBag.User = _userManager.GetUsersInRoleAsync("User").Result;
            ViewBag.Admin = _userManager.GetUsersInRoleAsync("Admin").Result;
            ViewBag.Unassigned = _userManager.GetUsersInRoleAsync("Unassigned").Result;

            return View("UserRoles", _userManager.Users.ToList());
        }

    }
}*/

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
        public IActionResult RoleList()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }
        //[Authorize(Policy = "writepolicy")]
        public IActionResult CreateRole()
        {
            return View(new IdentityRole());
        }

        public async Task<IActionResult> UserRoles()
        {
            ViewBag.Admin = userManager.GetUsersInRoleAsync("Admin").Result;
            ViewBag.Researcher = userManager.GetUsersInRoleAsync("Researcher").Result;
            ViewBag.Unassigned = userManager.GetUsersInRoleAsync("Unassigned").Result;

            return View();
        }

        public IActionResult EditRole(string user, string role)
        {
            var selectedUser = userManager.FindByIdAsync(user);
            ViewBag.Role = role;
            return View(selectedUser.Result);

        }
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

        //[Authorize(Policy = "writepolicy")]
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

    }
}