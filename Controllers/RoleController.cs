using INTEX2Mock.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace INTEX2Mock.Controllers
{
    public class RoleController : Controller
    {
        //Initialize a few variables that will be used throughout the controller
        RoleManager<IdentityRole> roleManager;
        UserManager<IdentityUser> userManager;

        //Constructor for the controller
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        //Action that displays a list of what roles are available for users
        [Authorize(Policy = "managepolicy")]
        public IActionResult RoleList()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        //Action that allows an admin to create a user role
        [Authorize(Policy = "managepolicy")]
        public IActionResult CreateRole()
        {
            return View(new IdentityRole());
        }

        //Action that allows an admin to see what users are registered as well as what roles 
        //(from admin, researcher, and unassigned) they all have
        [Authorize(Policy = "managepolicy")]
        public async Task<IActionResult> UserRoles()
        {
            //Put info for viewing into the viewbag to be accessed by the userroles view
            ViewBag.Admin = userManager.GetUsersInRoleAsync("Admin").Result;
            ViewBag.Researcher = userManager.GetUsersInRoleAsync("Researcher").Result;
            ViewBag.Unassigned = userManager.GetUsersInRoleAsync("Unassigned").Result;

            return View();
        }

        //Action that allows an admin to change the role associated with a user's account
        [Authorize(Policy = "managepolicy")]
        public IActionResult EditRole(string user, string role)
        {
            //Access what specific role a user is associated with and store everything into the viewbag
            var selectedUser = userManager.FindByIdAsync(user);
            ViewBag.Role = role;
            return View(selectedUser.Result);

        }

        //Action that submits requested changes for a user's assigned role
        [Authorize(Policy = "managepolicy")]
        [HttpPost]
        public async Task<IActionResult> SubmitEdits(string UserId, string newEmail, string Role, string NewRole)
        {
            //Pick out the account details for the specified user, and then modify appropriate information
            var selectedRole = roleManager.FindByNameAsync(NewRole).Result;

            var selectedUser = userManager.FindByIdAsync(UserId).Result;
            selectedUser.Email = newEmail;
            selectedUser.UserName = newEmail;
            await userManager.UpdateAsync(selectedUser);

            //Remove the old role that the user was associated with and assign them to a new one
            await userManager.RemoveFromRoleAsync(selectedUser, Role);
            await userManager.AddToRoleAsync(selectedUser, selectedRole.Name);

            //Store all results into the viewbag for the view to appropriately render
            ViewBag.Researcher = userManager.GetUsersInRoleAsync("Researcher").Result;
            ViewBag.Admin = userManager.GetUsersInRoleAsync("Admin").Result;
            ViewBag.Unassigned = userManager.GetUsersInRoleAsync("Unassigned").Result;

            return View("UserRoles", userManager.Users.ToList());
        }

        //Action that deletes a user's account, along with any login credentials and roles associated with that user
        [Authorize(Policy = "managepolicy")]
        [HttpPost]
        public async Task<IActionResult> RemoveUser(string UserId)
        {
            //Pick out the user's account's details and the roles it are assigned to
            var selectedUser = await userManager.FindByIdAsync(UserId);
            var rolesForUser = await userManager.GetRolesAsync(selectedUser);

            //Find the login credentials if they exist
            var logins = await userManager.GetLoginsAsync(selectedUser);

            //Loop through every user account associated with the userID and remove their login credentials from the database
            foreach(var x in logins)
            {
                var result = await userManager.RemoveLoginAsync(selectedUser, x.LoginProvider, x.ProviderKey);
                if(result != IdentityResult.Success)
                {
                    break;
                }
            }
            
            //Loop through every picked-out user and remove the roles associated with their account
            foreach(var x in rolesForUser)
            {
                var result2 = await userManager.RemoveFromRoleAsync(selectedUser, x);

                if(result2 != IdentityResult.Success)
                {
                    break;
                }
            }

            //Go into the database and delete the user's account's details from the database
            await userManager.DeleteAsync(selectedUser);

            return View("DeleteConfirmation");
        }

        //Confirm page to assure that the admin really does want to delete the specified user
        [Authorize(Policy = "managepolicy")]
        [HttpPost]
        public IActionResult ReviewDeleteUser(string UserId)
        {

            return View("ReviewDeleteUser" ,UserId);
        }

        //Action to create a new role for the database
        [Authorize(Policy = "managepolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }


        //Action that brings an admin to the role-create page
        [Authorize(Policy = "managepolicy")]
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        //Action that helps create the desired role in the database from a page other than the create-role page
        [Authorize(Policy = "managepolicy")]
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

    }
}