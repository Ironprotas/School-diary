using JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Serilog;
using JWT.Dto;
using Microsoft.AspNetCore.Identity;
using JWT.Base;
using JWT.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using static JWT.Base.ApplicationDbContext;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Xml.Linq;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class authController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IClassRepository _classRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public authController(ApplicationDbContext dbContext,
           UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IClassRepository classRepository, IUserRepository userRepository, IMapper mapper, 
           IDistributedCache cache)

        {

            _userManager = userManager;
            _roleManager = roleManager;
            _classRepository = classRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDto model)
        {

            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid request data.");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = _mapper.Map<AppUser>(model);
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {

                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine("Error: " + error.Description);
                    }

                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                Log.Error(ex, "An error occurred while processing the registration request.");
                return StatusCode(500, "Internal server error.");
            }

        }

        [HttpPost("Login")]
        public async Task<IActionResult> login([FromBody] LoginDto loginData)
        {
            var options = new DbContextOptionsBuilder().Options;
            using (var dbContext = new ApplicationDbContext(options))
            {

                AppUser user = await _userRepository.GetUserName(loginData.UserName);

                if (user is null || !await _userManager.CheckPasswordAsync(user, loginData.Password)) return Unauthorized(); // Если пользователь null или пароль не правильный то ошибка

                var userRoles = await _userManager.GetRolesAsync(user);

                var claims = new List<Claim>
                {
                new Claim(ClaimsIdentity.DefaultNameClaimType, loginData.UserName),
                new Claim("userId", user.Id)

                };

                foreach (var userRole in userRoles)
                {
                    claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole));
                }

                var jwt = new JwtSecurityToken(issuer: AuthOptions.ISSUER,
                           audience: AuthOptions.AUDIENCE,
                           claims: claims,
                           expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(15)),
                           signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                var response = new
                {
                    access_token = encodedJwt,
                    username = loginData.UserName,
                };
                return Json(response);
            };


        }

        [Authorize(Roles = "admin, masterteacher")]
        [HttpPut("EditUser")]
        public async Task<IActionResult> EditUser([FromBody] EditUserDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                _mapper.Map(model, user);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded) return Ok(user);
            }

            return BadRequest();

        }

 
        [Authorize(Roles = "admin, masterteacher")]
        [HttpGet("GetInFouser")]
        public async Task<IActionResult> GetInfoUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {

                var dataUser = _mapper.Map<UserDto>(user);

                return Ok(dataUser);

            }
            return BadRequest();

        }

        //Удаление пользователя
        [Authorize(Roles = "admin, masterteacher")]
        [HttpDelete("DeletUser")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var result = _userManager.DeleteAsync(user);
                return Ok(user + " deleted");

            }
            return BadRequest(username + "not found");
        }
        [Authorize(Roles = "admin, masterteacher")]
        [HttpPut("addstudentparent")]
        public async Task<IActionResult> AddStudentParent(string NameParent, string NameStudent)
        {
            var parent = await _userManager.FindByNameAsync(NameParent);
            var student = await _userManager.FindByNameAsync(NameStudent);
            if (parent != null && student != null)
            {
                var checkRoleParent = await _userManager.GetRolesAsync(parent);
                foreach (var role in checkRoleParent)
                {
                    if (role == "parent")
                    {
                        var checkRoleStudent = await _userManager.GetRolesAsync(student);
                        foreach (var rol in checkRoleStudent)
                        {
                            if (rol == "student")
                            {
                                _userRepository.AddParrent(student, parent);

                                return Ok("Student coupled with Parent success ");
                            }
                        }
                    }
                }

            }
            return BadRequest("Error");
        }

        [HttpDelete("DeletStudentFromParent")]
        public async Task<IActionResult> DelStudentFromParent(string NameStundet)
        {
            var student = await _userManager.FindByNameAsync(NameStundet);
            if (student != null)
            {

                _userRepository.DeleteParrent(student);

                return Ok("Student is without Parent");
            }
            return BadRequest();
        }



    }

      


}