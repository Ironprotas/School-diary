using JWT.Base;
using JWT.Dto;
using JWT.Models;
using JWT.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Security.Claims;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;


[Route("api/[controller]")]
[ApiController]

[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
public class HomeWorkController : Controller
{

    private readonly IDistributedCache _cache;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IHomeWorkRepository _homeWorkRepository;
    private readonly IScheduleLessonRepository _scheduleLessonRepository;
    private readonly IClassRepository _classRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILessonRepository _lessonRepository;

    public HomeWorkController(ApplicationDbContext dbContext,
       UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IHomeWorkRepository homeWorkRepository, IScheduleLessonRepository scheduleLessonRepository,
       IClassRepository classRepository, IUserRepository userRepository, ILessonRepository lessonRepository, IDistributedCache cache)

    {

        _userManager = userManager;
        _roleManager = roleManager;
        _homeWorkRepository = homeWorkRepository;
        _scheduleLessonRepository = scheduleLessonRepository;
        _classRepository = classRepository;
        _userRepository = userRepository;
        _lessonRepository = lessonRepository;
        _cache = cache;
    }

    //Добавление ДЗ
    [Authorize(Roles = "masterteacher, teacher, admin")]
    [HttpPost("AddHomework")]
    public async Task<IActionResult> AddHomeWork([FromBody] HomeWorkDto info)
    {
        var teacher = User.FindFirstValue(ClaimTypes.Name);
        var teachers = await _userManager.FindByNameAsync(teacher);
        var checkRole = await _userManager.GetRolesAsync(teachers);

        var lesson = await _scheduleLessonRepository.GetLesson(info.LessonId);
            
        foreach (var role in checkRole)
        {
            if (lesson.SettingsLesson.TeacherId == null) return BadRequest();

            if (role == "masterteacher" || lesson.SettingsLesson.TeacherId == teachers.Id || role == "admin")
            {
                var homework = new HomeWork { Work = info.Work, LessonId = info.LessonId };
                var result = _homeWorkRepository.Create(homework);
                return Ok(result.Id);
            }
        }
        return BadRequest("Error");
    }

    //Получение ДЗ
    [HttpGet("GetHomework")]
    public async Task<IActionResult> GetHomeWork(DateOnly date)
    {
        string userId = User.FindFirstValue(ClaimTypes.Name);
        var user = await _userRepository.GetClassIdFromUser(userId);

        List<ResponseHomeWorkDto>? homeWorks = null;
        var casheKey = $"{user.Id}";
        var casheHomeWork = await _cache.GetStringAsync(casheKey);

        if (casheHomeWork != null) homeWorks = JsonSerializer.Deserialize<List<ResponseHomeWorkDto>>(casheHomeWork);

        if (casheHomeWork == null)
        {

            var classI = _classRepository.Get(cl => cl.Id == user.ClassId);
            if (classI == null) return BadRequest();
            var scheduleLesson = _scheduleLessonRepository.SheduleLessonGet(classI.Id);
            var dateSchedules = await scheduleLesson.Where(d => d.Schedule.Date == date).ToListAsync();
            if (!dateSchedules.Any())
            {
                return Ok("Schedule's at this day not");
            }
            var lessonsList = dateSchedules.Select(l => l.Lesson).ToList();

            var homeWorkResposeList = new List<ResponseHomeWorkDto>();


            foreach (var lesson in lessonsList)
            {
                var lessons = _homeWorkRepository.Get(l => l.LessonId == lesson.Id);
                if (lessons == null)
                {
                    homeWorkResposeList.Add(new ResponseHomeWorkDto
                    {
                        Id = lesson.Id,
                        Name = lessonsList.Where(x => x.Id == lesson.Id).Select(x => x.Name).FirstOrDefault(),
                        HomeWork = "homework not"
                    });
                }
                else homeWorkResposeList.Add(new ResponseHomeWorkDto { Id = lessons.LessonId, Name = lessons.Lesson.Name, HomeWork = lessons.Work });
            }
            casheHomeWork = JsonSerializer.Serialize(homeWorkResposeList);
            await _cache.SetStringAsync(casheKey, casheHomeWork, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
            });
            return Ok(homeWorkResposeList);
        }

        return Ok(homeWorks);

    }

    //Получение Дз пользователя
    [Authorize(Roles = "admin, masterteacher, teacher")]
    [HttpGet("GetHomeworkUser")]
    public async Task<IActionResult> GetHomeUser(DateOnly date, string userName)
    {
        var user = await _userRepository.GetClassIdFromUser(userName);

        if (user != null)
        {
            List<ResponseHomeWorkDto>? homeWorks = null;
            var casheKey = $"{user.Id}";

            var casheHomeWork = await _cache.GetStringAsync(casheKey);

            if (casheHomeWork != null) homeWorks = JsonSerializer.Deserialize<List<ResponseHomeWorkDto>>(casheHomeWork);

            if (casheHomeWork == null)
            {

                var classI = _classRepository.Get(cl => cl.Id == user.ClassId);
                if (classI == null) return BadRequest("class Not");


                var scheduleLesson = _scheduleLessonRepository.SheduleLessonGet(classI.Id);

                var dateSchedules = await scheduleLesson.Where(d => d.Schedule.Date == date).ToListAsync();
                if (!dateSchedules.Any())
                {
                    return Ok("Schedule's at this day not");
                }
                var lessonsList = dateSchedules.Select(l => l.Lesson).ToList();

                var homeWorkResposeList = new List<ResponseHomeWorkDto>();

                foreach (var lesson in lessonsList)
                {
                    var lessons = _homeWorkRepository.Get(l => l.LessonId == lesson.Id);
                    if (lessons == null)
                    {
                        homeWorkResposeList.Add(new ResponseHomeWorkDto
                        {
                            Id = lesson.Id,
                            Name = lessonsList.Where(x => x.Id == lesson.Id).Select(x => x.Name).FirstOrDefault(),
                            HomeWork = "homework not"
                        });
                    }
                    else homeWorkResposeList.Add(new ResponseHomeWorkDto { Id = lessons.LessonId, Name = lessons.Lesson.Name, HomeWork = lessons.Work });
                }
                casheHomeWork = JsonSerializer.Serialize(homeWorkResposeList);
                await _cache.SetStringAsync(casheKey, casheHomeWork, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
                });
                return Ok(homeWorkResposeList);
            }

            return Ok(homeWorks);
        }

        return BadRequest("User not Found");
    }

    //Получение ДЗ ребенка
    [HttpGet("GetHomeworkParent")]
    public async Task<IActionResult> GetHomeWorkParent(DateOnly date, string nameStudent)
    {
        string userId =  User.FindFirstValue(ClaimTypes.Name);
        var user = await _userRepository.GetClassIdFromUser(userId);
        var student = await _userManager.FindByNameAsync(nameStudent);
        if (student == null) return BadRequest();

        if (student.ParentId == user.Id)
        {

            List<ResponseHomeWorkDto>? homeWorks = null;
            var casheKey = $"{user.Id}";
            var casheHomeWork = await _cache.GetStringAsync(casheKey);

            if (casheHomeWork != null) homeWorks = JsonSerializer.Deserialize<List<ResponseHomeWorkDto>>(casheHomeWork);

            if (casheHomeWork == null)
            {

                var classI = _classRepository.Get(cl => cl.Id == student.ClassId);
                if (classI == null) return BadRequest();
                var scheduleLesson = _scheduleLessonRepository.SheduleLessonGet(classI.Id);
                var dateSchedules = await scheduleLesson.Where(d => d.Schedule.Date == date).ToListAsync();
                if (!dateSchedules.Any())
                {
                    return Ok("Schedule's at this day not");
                }
                var lessonsList = dateSchedules.Select(l => l.Lesson).ToList();

                var homeWorkResposeList = new List<ResponseHomeWorkDto>();

                foreach (var lesson in lessonsList)
                {
                    var lessons = _homeWorkRepository.Get(l => l.LessonId == lesson.Id);
                    if (lessons == null)
                    {
                        homeWorkResposeList.Add(new ResponseHomeWorkDto
                        {
                            Id = lesson.Id,
                            Name = lessonsList.Where(x => x.Id == lesson.Id).Select(x => x.Name).FirstOrDefault(),
                            HomeWork = "homework not"
                        });
                    }
                    else homeWorkResposeList.Add(new ResponseHomeWorkDto { Id = lessons.LessonId, Name = lessons.Lesson.Name, HomeWork = lessons.Work });
                }
                casheHomeWork = JsonSerializer.Serialize(homeWorkResposeList);
                await _cache.SetStringAsync(casheKey, casheHomeWork, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
                });
                return Ok(homeWorkResposeList);
            }

            return Ok(homeWorks);
        }
        return BadRequest("This user it't your child");
    }

    //Удаление ДЗ
    [Authorize(Roles = "admin, masterteacher, teacher")]
    [HttpDelete("DeleteHomework")]
    public async Task<IActionResult> DeleteHomeWork(int idlesson)
    {
        var delHomeWork = _homeWorkRepository.Get(h => h.Id == idlesson);
        if (delHomeWork != null)
        {

            _homeWorkRepository.Delete(delHomeWork.Id);

            return Ok("Homework deleted");

        }
        return BadRequest("Homework not found");
    }

    //Редактирование ДЗ
    [Authorize(Roles = "admin, masterteacher, teacher")]
    [HttpPut("EditHomework")]
    public async Task<IActionResult> EditHomeWork(int idLesson, string homeWork)
    {
        var editHomeWork = _homeWorkRepository.Get(h => h.Id == idLesson);
        if (editHomeWork != null)
        {
            editHomeWork.Work = homeWork;
            _homeWorkRepository.Update(editHomeWork);
            return Ok("Homework changed");

        }
        return BadRequest("Homework not found");

    }
}