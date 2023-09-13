using AutoMapper;
using JWT.Base;
using JWT.Dto;
using JWT.Migrations;
using JWT.Models;
using JWT.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]

[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
public class LessonController : Controller
{

    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILessonRepository _lessonRepository;
    private readonly IScheduleLessonRepository _scheduleLessonRepository;
    private readonly ISettingsLessonRepository _settingsLessonRepository;
    private readonly IMapper _mapper;


    public LessonController(ApplicationDbContext dbContext,
       UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ILessonRepository lessonRepository,
       IScheduleLessonRepository scheduleLessonRepository, ISettingsLessonRepository settingsLessonRepository, IMapper mapper)

    {

        _userManager = userManager;
        _roleManager = roleManager;
        _lessonRepository = lessonRepository;
        _scheduleLessonRepository = scheduleLessonRepository;
        _settingsLessonRepository = settingsLessonRepository;
        _mapper = mapper;
    }

    //Создание предмета
    [Authorize(Roles = "admin, masterteacher")]
    [HttpPost("CreateSubjectLesson")]
    public async Task<IActionResult> CreateSubjectLesson(string lessonName)
    {
        var subjectLesson = _lessonRepository.Get(l => l.Name == lessonName);
        if (subjectLesson == null)
        {

            var namesubject = new Lesson { Name = lessonName };
            _lessonRepository.Create(namesubject);
            return Ok(namesubject);

        }
        return BadRequest("Subject Lesson was created earlier");
    }

    // создание урока
    [Authorize(Roles = "admin, masterteacher")]
    [HttpPost("CreateLesson")]
    public async Task<IActionResult> CreateLesson([FromBody] LessonDto info)

    {
        TimeLessons timeLessons = new TimeLessons();

        
        var lessonInfo = new SettingsLesson
        {
            Cabinet = info.Cabinet,
            StartLesson = timeLessons.lessons[info.Number].start,
            EndLesson = timeLessons.lessons[info.Number].end,

        };

        var result = _settingsLessonRepository.Create(lessonInfo);
        return Ok(result.Id);
    }


    //Получение ифнормации об уроке
    [HttpGet("GetInfoLesson")]
    public async Task<IActionResult> GetInfoLesson(string name)
    {
        var result = await _lessonRepository.GetLessonId(name);
             
        return Ok(result);

    }

    //Добавление учителя
    [Authorize(Roles = "admin, masterteacher")]
    [HttpPut("AddTeacherInClass")]
    public async Task<IActionResult> AddTeacherInclass(int idLesson, string userName)
    {
        var lessons = _settingsLessonRepository.Get(l => l.Id == idLesson);
        var user = await _userManager.FindByNameAsync(userName);
        if (lessons != null && user != null)
        {

            var checkRole = await _userManager.GetRolesAsync(user);
            foreach (var role in checkRole)
            {

                if (role == "teacher" || role == "masterteacher")
                {
                    _lessonRepository.AddTeacher(lessons, user);
                    return Ok("Teacher added ");
                }
            }

        }
        return BadRequest("Error");
    }

    //Удаление урока
    [Authorize(Roles = "admin, masterteacher")]
    [HttpDelete("DeleteLesson")]
    public async Task<IActionResult> DeleteLesson(int lessonid)
    {
        var lessonId = _settingsLessonRepository.Get(l => l.Id == lessonid);
        if (lessonId != null)
        {

            _settingsLessonRepository.Delete(lessonid);
            return Ok("lesson deleted");
        }
        return BadRequest("Error");

    }

    //Убираем учителя с урока
    [Authorize(Roles = "admin, masterteacher")]
    [HttpDelete("DeleteTeacher")]
    public async Task<IActionResult> DeleteTeacher(int lessonId)
    {
        var lessonDel = await _settingsLessonRepository.GetIdLessonTeach(lessonId);
        if (lessonDel != null)
        {
            _lessonRepository.DeleteTeacher(lessonDel);
            return Ok(lessonDel);
        }

        return BadRequest("Teacher not found");

    }

    //Редактирование урока
    [Authorize(Roles = "admin, masterteacher")]
    [HttpPut("EditLesson")]
    public async Task<IActionResult> EditLesson([FromBody] LessonDto info, int lessonId)
    {
        var lesson = await _scheduleLessonRepository.GetInfoLessonForUpdate(lessonId);

        if (lesson != null)
        {
            TimeLessons timeLessons = new TimeLessons();

            lesson.SettingsLesson.Cabinet = info.Cabinet;
            lesson.SettingsLesson.StartLesson = timeLessons.lessons[info.Number].start;
            lesson.SettingsLesson.EndLesson = timeLessons.lessons[info.Number].end;

            _scheduleLessonRepository.Update(lesson);
            return Ok(lesson);


        }
        return BadRequest("Lesson not found");

    }
    public class TimeLessons
    {
        public static Dictionary<int, (TimeOnly start, TimeOnly end)> less = new Dictionary<int, (TimeOnly start, TimeOnly end)>()
            {
                {1, (TimeOnly.Parse("8:30"), TimeOnly.Parse("9:10")) },
                {2, (TimeOnly.Parse("9:15"), TimeOnly.Parse("9:55")) },
                {3, (TimeOnly.Parse("10:00"), TimeOnly.Parse("10:40")) },
                {4, (TimeOnly.Parse("10:50"), TimeOnly.Parse("11:30")) },
                {5, (TimeOnly.Parse("11:35"), TimeOnly.Parse("12:15")) },
                {6, (TimeOnly.Parse("12:20"), TimeOnly.Parse("13:00")) },
                {7, (TimeOnly.Parse("13:15"), TimeOnly.Parse("13:55")) },
                {8, (TimeOnly.Parse("14:00"), TimeOnly.Parse("14:40")) },
                {9, (TimeOnly.Parse("14:50"), TimeOnly.Parse("15:30")) },
                {10, (TimeOnly.Parse("15:35"), TimeOnly.Parse("16:15")) },
                {11, (TimeOnly.Parse("16:20"), TimeOnly.Parse("17:00")) },
                {12, (TimeOnly.Parse("17:05"), TimeOnly.Parse("17:45")) },
                {13, (TimeOnly.Parse("17:50"), TimeOnly.Parse("18:30")) },
            };
        public Dictionary<int, (TimeOnly start, TimeOnly end)> lessons
        {
            get { return less; }
        }
    }

}