using AutoMapper;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using JWT.Base;
using JWT.Dto;
using JWT.Models;
using JWT.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;
using static LessonController;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class ReportController : Controller
    {

        UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEvaluationsRepository _evalationsRepository;
        private readonly IClassRepository _classRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IScheduleLessonRepository _scheduleLessonRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _appEnvironment;

        public ReportController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager,
            IMapper mapper, IEvaluationsRepository evaluationsRepository, IClassRepository classRepository, ILessonRepository lessonRepository,
            IScheduleLessonRepository scheduleLessonRepository, IScheduleRepository scheduleRepository, IUserRepository userRepository, IWebHostEnvironment appEnvironment)
        {
            _userManager = userManager;
            _mapper = mapper;
            _evalationsRepository = evaluationsRepository;
            _classRepository = classRepository;
            _lessonRepository = lessonRepository;
            _scheduleRepository = scheduleRepository;
            _scheduleLessonRepository = scheduleLessonRepository;
            _userRepository = userRepository;
            _appEnvironment = appEnvironment;
        }

        //Отчет по студенту
        [HttpGet("ReportForStudent")]
        public async Task<IActionResult> ReportForStudent(string userName, int? classyear)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var lessonObjectIds = await _evalationsRepository.GetLessonObjectId(user.Id);

                var response = new List<ResponseEvanuationbyLessonDto>();
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("StudentReport");
                int row = 2;

                foreach (var lessonid in lessonObjectIds.Distinct())
                {

                    var scores = await _evalationsRepository.GetEvaluationsByLessonIdAndUserId(lessonid, user.Id);
                    var firstScore = scores.FirstOrDefault();
                    var lessonName = firstScore?.Lesson.Name;
                    var dateLesson =  await _scheduleLessonRepository.GetDateLesson(lessonid);
                    if (classyear.HasValue)
                    {
                        if (dateLesson.Schedule.Date.Year != classyear)
                        {
                            continue;
                        }
                    }

                    worksheet.Cell(1, 1).Value = "Evaluation";
                    worksheet.Cell(1, 2).Value = "LessonName";
                    worksheet.Cell(1, 3).Value = "Date";

                    foreach (var resp in scores)
                    {
                        worksheet.Cell(row, 1).Value = resp.Evaluaton;
                        worksheet.Cell(row, 2).Value = resp.Lesson.Name;
                        worksheet.Cell(row, 3).Value = dateLesson.Schedule.Date.ToString();                
                        row++;
                    }

                }
                string fileName = $"Report for {userName}.xlsx";
                string filePath = Path.Combine(_appEnvironment.ContentRootPath, fileName);
                workbook.SaveAs(filePath);
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var fileResult = new FileStreamResult(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = fileName
                };

                return fileResult;
            }

            return BadRequest();

        }

        //Отчет по классу 
        [HttpPost("ReportForClass")]
        public async Task<IActionResult> ReportForClass([FromBody] List<string> nameLessons)
        {
            var classAll = _classRepository.GetAll();
            var classesByStudent = new List<ResponseClassByStudentWithEvanuations>();

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("ReportForClass");
            int row = 3;
            foreach (var classes in classAll)
            {
                var users = _userRepository.GetAllUserInClass(classes.Id);

                var userLessonByEvanuations = new List<ResponseEvanuationByUserAndLessonDto>();
                foreach (var nameLesson in nameLessons)
                {

                    foreach (var user in await users)
                    {
                        var lessonId = await _lessonRepository.GetLessonId(nameLesson);
                        var evaluationList =  await _evalationsRepository.GetEvaluationsByLessonIdAndUserId(lessonId, user.Id);
                        var evanuationsResponseList = _mapper.Map<List<ResponseEvanuationsDto>>(evaluationList);
                        userLessonByEvanuations.Add(new ResponseEvanuationByUserAndLessonDto
                        {
                            UserName = user.UserName,
                            Lesson = nameLesson,
                            Evanations = evanuationsResponseList
                        });

                    }

                }

                    classesByStudent.Add(new ResponseClassByStudentWithEvanuations
                    {
                        NumberClass = classes.Number,
                        NameClass = classes.Name,
                        UserLessonByEvanuations = userLessonByEvanuations
                    });

            }

            worksheet.Cell(1, 1).Value = "Name Class";
            worksheet.Cell(1, 2).Value = "Number Class";
            worksheet.Cell(1, 3).Value = "Name Lesson";
            worksheet.Cell(1, 4).Value = "User Name";
            worksheet.Cell(1, 5).Value = "Evanations";

            foreach (var result in classesByStudent)
            {
                worksheet.Cell(row, 1).Value = result.NameClass;
                worksheet.Cell(row, 2).Value = result.NumberClass;
                foreach (var result2 in result.UserLessonByEvanuations)
                {
                    worksheet.Cell(row, 3).Value = result2.Lesson;
                    worksheet.Cell(row, 4).Value = result2.UserName;
                    row++;
                    foreach (var result3 in result2.Evanations)
                    {
                        worksheet.Cell(row, 5).Value = result3.Evanuation;
                        row++;
                    }
                }

                row++;
            }
            string fileName = "Files/Class Response.xlsx";
            string filePath = Path.Combine(_appEnvironment.ContentRootPath, fileName);
            workbook.SaveAs(filePath);
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var fileResult = new FileStreamResult(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = fileName
            };

            return fileResult;

        }


        [HttpGet("ReportForLesson")]
        public async Task<IActionResult> ReportForLesson(string nameLesson)
        {
            var classAll = _classRepository.GetAll();
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("ReportForClass");
            int row = 2;
            var averageEvanuations = new Dictionary<ClassDto, double>();
            foreach (var classes in classAll)
            {
                var userLessonByEvanuations = new List<ResponseEvanuationByUserAndLessonDto>();
                var allEvanuationsClass = new List<int>();
                var users = await _userRepository.GetAllUserInClass(classes.Id);
                var lessonId =  await _lessonRepository.GetLessonId(nameLesson);


                foreach (var user in users)
                {

                    var evaluationList = _evalationsRepository.GetEvaluationsByLessonIdAndUserId(lessonId, user.Id);
                    var evanuationsResponseList = _mapper.Map<List<ResponseEvanuationsDto>>(evaluationList);
                    userLessonByEvanuations.Add(new ResponseEvanuationByUserAndLessonDto
                    {
                        Evanations = evanuationsResponseList
                    });

                }

                foreach (var evanuations in userLessonByEvanuations)
                {
                    foreach (var evanuation in evanuations.Evanations)
                    {
                        allEvanuationsClass.Add(evanuation.Evanuation);
                    }
                }
                if (allEvanuationsClass.Count == 0)
                {
                    allEvanuationsClass.Add(0);
                }

                double evanuationAvarage = Math.Round(allEvanuationsClass.Average(), 2);

                averageEvanuations.Add(new ClassDto { Name = classes.Name, Number = classes.Number}, evanuationAvarage);

            }
             averageEvanuations = averageEvanuations.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
           

            worksheet.Cell(1, 1).Value = "Name";
            worksheet.Cell(1, 2).Value = "Number";
            worksheet.Cell(1, 3).Value = "Average score";

            foreach (var averageEvanuation in averageEvanuations)
            {
                worksheet.Cell(row, 1).Value = averageEvanuation.Key.Name;
                worksheet.Cell(row, 2).Value = averageEvanuation.Key.Number;
                worksheet.Cell(row, 3).Value = averageEvanuation.Value.ToString();
                row++;
            }
            string fileName = $"Average score on {nameLesson}.xlsx";
            string filePath = Path.Combine(_appEnvironment.ContentRootPath, fileName);
            workbook.SaveAs(filePath);
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var fileResult = new FileStreamResult(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = fileName
            };

            return fileResult;
        }         

    }
}

