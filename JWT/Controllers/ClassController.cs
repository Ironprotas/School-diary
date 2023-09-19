using AutoMapper;
using JWT.Base;
using JWT.Dto;
using JWT.Models;
using JWT.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class ClassController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public ClassController(ApplicationDbContext dbContext,
           UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IClassRepository classRepository, IMapper mapper)

        {
            _userManager = userManager;
            _roleManager = roleManager;
            _classRepository = classRepository;
            _mapper = mapper;

        }
        //Создание класса
        [Authorize(Roles = "h, Masterteacher")]
        [HttpPost("CreateClass")]
        public async Task<IActionResult> CreateClass([FromBody] ClassDto inform)
        {
           

            var addClass = new Models.Class();
            _mapper.Map(inform, addClass);
            var result = _classRepository.Create(addClass);
            return Ok(result);
        }

        //Получение информации о классе
        [HttpGet("GetClass")]
        public async Task<IActionResult> GetClass(string name, int number)
        {
            var result =await _classRepository.GetClassId(name, number);
            return Ok(result);
        }

        //Добавление ученика в класс
        [Authorize(Roles = "Admin, Masterteacher, teacher")]
        [HttpPost("AddStudentInClass")]
        public async Task<IActionResult> AddStudentInClass(string name, string nameClass, int numberClass)
        {

            var user = await _userManager.FindByNameAsync(name);
            var classI = await _classRepository.GetClassId(nameClass, numberClass);

            if (classI != null && user != null)
            {
                if (classI == 0) return BadRequest("Class not found");

                _classRepository.AddStudentInClass(user, classI);
                return Ok();
            }
            return BadRequest("Student or Class not found");
        }

        // Удаление ученика из класса
        [Authorize(Roles = "Admin, Masterteacher")]
        [HttpDelete("DeletStudent")]
        public async Task<IActionResult> DeleteSchedules(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                if (user.ClassId == null)
                {
                    return Ok("Sudent haven't class");
                }

                _classRepository.Delete(Convert.ToInt32(user.ClassId));
                return Ok("Student deleted from class");
            }

            return BadRequest();
        }
        //Редактирование класса
        [Authorize(Roles = "Admin, Masterteacher")]
        [HttpPut("EditClass")]
        public async Task<IActionResult> EditClass(int classId, int numberClass, string nameClass)
        {
            _classRepository.UpdateClass(classId, nameClass, numberClass);
            return Ok();

        }


    }
}