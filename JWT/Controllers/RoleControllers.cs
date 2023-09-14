using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace JWT.Controllers

{

    [Route("api/[controller]")]
    [ApiController]

    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class RoleController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;

        public RoleController(Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin, Masterteacher")]
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (ModelState.IsValid)
            {

                var result = await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
                if (result.Succeeded)
                    return Ok();
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin, Masterteacher")]
        [HttpPost("AddRoleUser ")]
        public async Task<IActionResult> AddRole(string userName, string roleName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var role = await _roleManager.FindByNameAsync(roleName);

            if (user != null && role != null)
            {
                await _userManager.AddToRoleAsync(user, roleName);
                return Ok("Role added to user successfully.");
            }

            return BadRequest("User or role not found.");
        }

        [Authorize(Roles = "Admin, Masterteacher")]
        [HttpPost("DeleteUserRole")]
        public async Task<IActionResult> DeleteUserRole(string userName, string roleName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var role = await _roleManager.FindByNameAsync(roleName);
            if (user != null)
            {
                var deluser = await _userManager.RemoveFromRoleAsync(user, roleName);
                return Ok("You deleted role to user");
            }
            return BadRequest("User or role not found");

        }

        [Authorize(Roles = "Admin, Masterteacher")]
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
            {
                var delrole = await _roleManager.DeleteAsync(role);
                return Ok("You deleted role");
            }
            return BadRequest("Role not found");
        }

        [Authorize(Roles = "Admin, Masterteacher")]
        [HttpGet("CheckRole")]
        public async Task<IActionResult> CheckRole(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var result = await _userManager.GetRolesAsync(user);
                return Ok(result);
            }
            return BadRequest("No Role");
        }

        [Authorize(Roles = "Admin, Masterteacher")]
        [HttpGet("Checker")]
        public async Task<IActionResult> CheckRoles(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
            {
                var result = await _roleManager.GetRoleNameAsync(role);
                return Ok(result);
            }
            return BadRequest("No User");
        }

    }
}