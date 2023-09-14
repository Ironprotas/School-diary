using AutoMapper;
using JWT.Base;
using JWT.Dto;
using JWT.Models;
using JWT.Repositories.Implementations;
using JWT.Repositories.Interfaces;
using JWT.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


[Route("api/[controller]")]
[ApiController]

[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
public class EvanuationsController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IScheduleLessonRepository _scheduLessonRepository;
    private readonly IClassRepository _classRepository;
    private readonly IEvaluationsRepository _evalationsRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public EvanuationsController(ApplicationDbContext dbContext,
       UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,
        IScheduleLessonRepository scheduLessonRepository,
       IClassRepository classRepository, IEvaluationsRepository evaluationsRepository, IMapper mapper, IUserRepository userRepository)

    {
        _userManager = userManager;
        _roleManager = roleManager;
        _scheduLessonRepository = scheduLessonRepository;
        _classRepository = classRepository;
        _evalationsRepository = evaluationsRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }


    // Добавление оценки ученику
    [Authorize(Roles = "Admin, Masterteacher, teacher")]
    [HttpPost("SendEvanuation")]
    public async Task<IActionResult> SendEvanuation([FromBody] EvanuationsDto info)
    {
        var teacher = User.FindFirstValue(ClaimTypes.Name);
        var teachers = await _userManager.FindByNameAsync(teacher);
        var user = await _userManager.FindByNameAsync(info.UserName);
        var lesson = await _scheduLessonRepository.GetLessonIfon(info.LessonId);
        if (user != null && lesson != null)
        {
            if (user.ClassId == lesson.Schedule.ClassId)
            {
                var checkRole = await _userManager.GetRolesAsync(teachers);
                foreach (var role in checkRole)
                {

                    if (role == "Masterteacher" || lesson.SettingsLesson.TeacherId == teachers.Id)
                    {

                        var evanuation = _mapper.Map<Evaluations>(info, opt => opt.AfterMap((src, dest) => dest.UserId = user.Id));

                        _evalationsRepository.Create(evanuation);

                        return Ok();
                    }
                }
            }

        }
        return BadRequest();
    }

    [Authorize(Roles = "Admin, Masterteacher, teacher")]
    //Получение оценок пользователя по одному предмету
    [HttpGet("GetEvanuationsUserOneObject")]
    public async Task<IActionResult> GetEvanuationsUserOneObject(string userName, string? nameLesson)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user != null)
        {
            var evanuations = await _scheduLessonRepository.GetEvanuationFromNameLesson(nameLesson);
            if (user != null && evanuations != null)
            {
                var result = await _evalationsRepository.GetEvaluationsOneSubject(evanuations.Lesson.Id, user.Id);

                return Ok(result);
            }
            else if (user != null && nameLesson == null)
            {
                var resultAll = await _evalationsRepository.GetEvaluationsForUser(user.Id);
                var x = resultAll;
                return Ok(x);
            }
        }
        return BadRequest();
    }
    [Authorize(Roles = "Admin, Masterteacher, teacher")]
    //Получение всех оценок по всем предметам одного пользоватлея
    [HttpGet("GetAllEvanuationOneUser")]
    public async Task<IActionResult> GetAllEvanuationOneUser(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);

        if (user != null)
        {

            var lessonObjectIds = await _evalationsRepository.GetLessonObjectId(user.Id);

            var response = new List<ResponseEvanuationbyLessonDto>();

            foreach (var lessonid in lessonObjectIds.Distinct())
            {
                var scores = await _evalationsRepository.GetEvaluationsByLessonIdAndUserId(lessonid, user.Id);
                var firstScore = scores.FirstOrDefault();
                var lessonName = firstScore?.Lesson.Name;
                var dateLesson = await _scheduLessonRepository.GetDateLesson(firstScore.LessonId);

                var evanuationsResponseList = _mapper.Map<List<ResponseEvanuationsDto>>(scores);

                response.Add(new ResponseEvanuationbyLessonDto { Name = lessonName, Evanations = evanuationsResponseList, Date = dateLesson.Schedule.Date });

            }
            return Ok(response);

        }

        return BadRequest();

    }


    [Authorize(Roles = "Admin, parent")]
    //Получение оценок своего ребенка
    [HttpGet("GetAllEvanuationMyStudent")]
    public async Task<IActionResult> GetAllEvanuationMyStudent(string userName, bool sendmail = false)
    {

        string userId = User.FindFirstValue(ClaimTypes.Name);
        var user = await _userRepository.GetClassIdFromUser(userId);
        var student = await _userManager.FindByNameAsync(userName);

        if (student.ParentId == user.Id)
        {

            if (student != null)
            {

                var lessonObjectIds = await _evalationsRepository.GetLessonObjectId(student.Id);

                var response = new List<ResponseEvanuationbyLessonDto>();

                foreach (var lessonid in lessonObjectIds.Distinct())
                {
                    var scores = await _evalationsRepository.GetEvaluationsByLessonIdAndUserId(lessonid, student.Id);
                    var firstScore = scores.FirstOrDefault();
                    var lessonName = firstScore?.Lesson.Name;
                    var dateLesson = await _scheduLessonRepository.GetDateLesson(firstScore.LessonId);

                    var evanuationsResponseList = _mapper.Map<List<ResponseEvanuationsDto>>(scores);

                    response.Add(new ResponseEvanuationbyLessonDto { Name = lessonName, Evanations = evanuationsResponseList, Date = dateLesson.Schedule.Date });

                }

                if (sendmail)
                {

                  EmailService emailService = new EmailService();
                 // await emailService.SendMailAsync(user.Email, $"Оценки {userName}", response.ToHtmlString());
                }


                return Ok(response);

            }
        }
        return BadRequest();

    }


    //Получение всех оценок по классу
    [Authorize(Roles = "Admin, Masterteacher, teacher")]
    [HttpGet("GetAllEvanuationClass")]
    public async Task<IActionResult> GetAllEvanuationCLass(string nameClass, int numberClass)
    {
        var classI = await _classRepository.GetClassWithStudents(nameClass, numberClass);
        if (classI == null) return BadRequest("Класса не существует");


        var scheduleLessons = await _scheduLessonRepository.ScheduleLessonEvanuationList(classI.Id);

        var response = new List<ResponseEvanuationAllDto>();
        var lessonIds = scheduleLessons.Select(sl => sl.LessonId);
        var evaluations = await _evalationsRepository.GetEvaluationsByLessonIds(lessonIds.ToList());

        foreach (var user in classI.Student)
        {
            foreach (var scheduleLesson in scheduleLessons)
            {
                var responses = _mapper.Map<List<ResponseEvanuationAllDto>>(scheduleLesson);

                response.Add(new ResponseEvanuationAllDto
                {
                    LessonName = scheduleLesson.Lesson.Name,
                    UserName = user.UserName,
                    Evanations = evaluations.Where(ev => ev.LessonId == scheduleLesson.LessonId && ev.User.Id == user.Id).Select(e => e.Evaluaton).ToList(),
                    Date = scheduleLesson.Schedule.Date
                });
            }

        }

        return Ok(response);
    }

}

