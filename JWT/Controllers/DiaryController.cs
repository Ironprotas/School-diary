using AutoMapper;
using JWT.Base;
using JWT.Dto;
using JWT.Models;
using JWT.Repositories.Implementations;
using JWT.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using ClosedXML;
using ClosedXML.Excel;
using JWT.Migrations;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class DiaryController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IScheduleLessonRepository _scheduLessonRepository;
        private readonly IClassRepository _classRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;

        public DiaryController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager,
            IScheduleLessonRepository scheduLessonRepository, IClassRepository classRepository, IScheduleRepository scheduleRepository,
            IUserRepository userRepository, IMapper mapper, IWebHostEnvironment appEnvironment)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _scheduLessonRepository = scheduLessonRepository;
            _classRepository = classRepository;
            _scheduleRepository = scheduleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }
        ////Добавление расписания
        [HttpPost("AddSchedule")]
        public async Task<IActionResult> AddSchedule([FromBody] ScheduleDto info)
        {
            var lessonsGet = await _scheduLessonRepository.GetAllLessons();
            var classI = _classRepository.Get(c => c.Id == info.ClassId);
            var shedule = _scheduleRepository.Get(s => s.ClassId == classI.Id && s.Date == info.Date);
            int sheduleId = 0;

            if (shedule is null)
            {

                var tasks = _mapper.Map<Schedule>(info, opt => opt.AfterMap((src, dest) => dest.ClassId = classI.Id));

                var result = _scheduleRepository.Create(tasks);
                sheduleId = result.Id;
            }
            else
            {
                sheduleId = shedule.Id;
            }

            var lessonSchedule = _mapper.Map<ScheduleLesson>(info, opt => opt.AfterMap((src, dest) => dest.ScheduleId = sheduleId));

            _scheduLessonRepository.Create(lessonSchedule);

            return Ok();

        }

        //Получение расписание пользователя
        [Authorize(Roles = "admin, masterteacher, teacher")]
        [HttpGet("GetSchedule")]
        public async Task<IActionResult> GetSchedule(string name)
        {
            var user = await _userRepository.GetClassIdFromUser(name);


            var response = new List<ResponseScheduleByClassDto>();
            if (user != null)
            {
                var classId = _classRepository.Get(cl => cl.Id == user.ClassId);
                if (classId == null)
                {
                    return BadRequest("Student haven't class");
                }
                var sheduleResponseList = new List<ResponseScheduleDto>();

                var lessonResponse = new List<LessonWithDateDto>();

                var scheduleLesson = _scheduLessonRepository.SheduleLessonGet(classId.Id);

                var shedules = await scheduleLesson.Select(sl => sl.Schedule).ToListAsync();
                if (!shedules.Any())
                {
                    return BadRequest("Student haven't schedules");
                }

                foreach (var shedule in shedules.Distinct())
                {

                    var lessons = await scheduleLesson.Where(sl => sl.ScheduleId == shedule.Id).ToListAsync();


                    var lessonMapping = _mapper.Map<List<ResponseLessonDto>>(lessons);
                    var lessonMappingWithDate = _mapper.Map<List<LessonWithDateDto>>(lessonMapping);


                    lessonResponse.Add(new LessonWithDateDto { Lessons = lessonMapping, Date = shedule.Date });
                }

                ClassDto calssMapping = _mapper.Map<ClassDto>(classId);

                response.Add(new ResponseScheduleByClassDto { Class = calssMapping, Lessons = lessonResponse });

                return Ok(response);

            }
            return BadRequest("User not found");

        }

        //Получение своего расписания
        [HttpGet("MySchedules")]
        public async Task<IActionResult> MySchedules()
        {
            string userId = User.FindFirstValue(ClaimTypes.Name);
            var user = await _userRepository.GetClassIdFromUser(userId);
            var classId = _classRepository.Get(cl => cl.Id == user.ClassId);
            var response = new List<ResponseScheduleByClassDto>();
            if (classId == null)
            {
                return BadRequest("Student haven't class");
            }

            var sheduleResponseList = new List<ResponseScheduleDto>();
            var lessonResponse = new List<LessonWithDateDto>();
            var scheduleLesson = _scheduLessonRepository.SheduleLessonGet(classId.Id); ;
            var shedules = await scheduleLesson.Select(sl => sl.Schedule).ToListAsync();

            if (!shedules.Any())
            {
                return BadRequest("Student haven't schedules");
            }

            foreach (var shedule in shedules.Distinct())
            {

                var lessons = await scheduleLesson.Where(sl => sl.ScheduleId == shedule.Id).ToListAsync();


                var lessonMapping = _mapper.Map<List<ResponseLessonDto>>(lessons);
                var lessonMappingWithDate = _mapper.Map<List<LessonWithDateDto>>(lessonMapping);


                lessonResponse.Add(new LessonWithDateDto { Lessons = lessonMapping, Date = shedule.Date });
            }

            ClassDto calssMapping = _mapper.Map<ClassDto>(classId);


            response.Add(new ResponseScheduleByClassDto { Class = calssMapping, Lessons = lessonResponse });

            return Ok(response);

        }

        //Получение всего расписания
        [HttpGet("GetAllSchedules")]
        public async Task<IActionResult> GetAllShedules(int? day, int? month, int? year, bool export = false)
        {

            var allclasses = await _classRepository.GetAllClass();

            var response = new List<ResponseScheduleByClassDto>();

            var scheduleQuery = _scheduleRepository.GetAll();

            if (year.HasValue)
            {
                scheduleQuery = scheduleQuery.Where(x => x.Date.Year == year.Value);
            }

            if (month.HasValue)
            {
                scheduleQuery = scheduleQuery.Where(x => x.Date.Month == month.Value);
            }

            if (day.HasValue)
            {
                scheduleQuery = scheduleQuery.Where(x => x.Date.Day == day.Value);
            }

            var schedules = scheduleQuery.ToList();

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Schedules");
            int row = 1;

            foreach (var cl in allclasses.Distinct())
            {

                var sheduleResponseList = new List<ResponseScheduleDto>();

                var lessonResponse = new List<LessonWithDateDto>();

                var scheduleLesson = _scheduLessonRepository.SheduleLessonGet(cl.Id);


                foreach (var shedule in schedules.Distinct())
                {

                    var lessons = await scheduleLesson.Where(sl => sl.ScheduleId == shedule.Id).ToListAsync();
                    var lessonMapping = _mapper.Map<List<ResponseLessonDto>>(lessons);
                    var lessonMappingWithDate = _mapper.Map<List<LessonWithDateDto>>(lessonMapping);

                    lessonResponse.Add(new LessonWithDateDto { Lessons = lessonMapping, Date = shedule.Date });
                    if (export)
                    {
                        worksheet.Cell(1, 1).Value = "Class name";
                        worksheet.Cell(1, 2).Value = "Class number";
                        worksheet.Cell(1, 3).Value = "Date";
                        worksheet.Cell(1, 4).Value = "Lesson name";
                        worksheet.Cell(1, 5).Value = "Cabinet";
                        worksheet.Cell(1, 6).Value = "StartLesson";
                        worksheet.Cell(1, 7).Value = "EndLesson";
                        worksheet.Cell(1, 8).Value = "ID";

                        foreach (var lesson in lessons)
                        {
                            worksheet.Cell(row, 1).Value = lesson.Schedule.Class.Name;
                            worksheet.Cell(row, 2).Value = lesson.Schedule.Class.Number.ToString();
                            worksheet.Cell(row, 3).Value = lesson.Schedule.Date.ToString();
                            worksheet.Cell(row, 4).Value = lesson.Lesson.Name;
                            worksheet.Cell(row, 5).Value = lesson.SettingsLesson.Cabinet;
                            worksheet.Cell(row, 6).Value = lesson.SettingsLesson.StartLesson.ToString();
                            worksheet.Cell(row, 7).Value = lesson.SettingsLesson.EndLesson.ToString();
                            worksheet.Cell(row, 8).Value = lesson.Id;

                            row++;

                        }

                        workbook.SaveAs("Schedules.xlsx");
                        string path = Path.Combine(_appEnvironment.ContentRootPath, "Schedules.xlsx");
                        string file_type = "application/xlsx";
                        return PhysicalFile(path, file_type);
                    }

                }

                ClassDto calssMapping = _mapper.Map<ClassDto>(cl);

                response.Add(new ResponseScheduleByClassDto { Class = calssMapping, Lessons = lessonResponse });

            }


            return Ok(response);
        }



        //Получение расписание одного класса
        [HttpGet("GetOneClassScheduele")]
        public async Task<IActionResult> GetOneClassSchedule(int numberClass, string nameClass)
        {
            var classId = _classRepository.Get(cl => cl.Name == nameClass && cl.Number == numberClass);
            var respose = new List<ResponseScheduleByClassDto>();
            if (classId != null)
            {
                var sheduleResponseList = new List<ResponseScheduleDto>();

                var lessonResponse = new List<LessonWithDateDto>();

                var scheduleLesson = _scheduLessonRepository.SheduleLessonGet(classId.Id);

                var shedules = await scheduleLesson.Select(sl => sl.Schedule).ToListAsync();

                if (!shedules.Any())
                {
                    return BadRequest("Student haven't schedules");
                }

                foreach (var shedule in shedules.Distinct())
                {

                    var lessons = await scheduleLesson.Where(sl => sl.ScheduleId == shedule.Id).ToListAsync();


                    var lessonMapping = _mapper.Map<List<ResponseLessonDto>>(lessons);
                    var lessonMappingWithDate = _mapper.Map<List<LessonWithDateDto>>(lessonMapping);


                    lessonResponse.Add(new LessonWithDateDto { Lessons = lessonMapping, Date = shedule.Date });
                }

                ClassDto calssMapping = _mapper.Map<ClassDto>(classId);


                respose.Add(new ResponseScheduleByClassDto { Class = calssMapping, Lessons = lessonResponse });

                return Ok(respose);
            }
            return BadRequest();

        }

        //Редактирование расписание
        [HttpPut("EdditSchedule")]
        public async Task<IActionResult> EditSchedule([FromBody] ScheduleDto info)
        {
            var shedule = _scheduleRepository.Get(sh => sh.Id == info.Id);
            if (shedule != null)
            {

                var shedules = _mapper.Map<Schedule>(info);

                _scheduleRepository.Update(shedules);
                return Ok(shedules);

            }

            return BadRequest("Schedule not found");
        }
        //Получение своего ребенка расписания
        [HttpGet("GetMyStudentSchedules")]
        public async Task<IActionResult> GetMyStudentSchedules(string nameStudent)
        {
            string userId = User.FindFirstValue(ClaimTypes.Name);
            var user = await _userRepository.GetClassIdFromUser(userId);
            var student = await _userManager.FindByNameAsync(nameStudent);
            if (student.ParentId == user.Id)
            {
                var classes = _classRepository.Get(cl => cl.Id == student.ClassId);


                var response = new List<ResponseScheduleByClassDto>();
                if (student == null)
                {
                    return BadRequest("Student haven't class");
                }
                var sheduleResponseList = new List<ResponseScheduleDto>();

                var lessonResponse = new List<LessonWithDateDto>();

                var scheduleLesson = _scheduLessonRepository.SheduleLessonGet(classes.Id);

                var shedules = await scheduleLesson.Select(sl => sl.Schedule).ToListAsync();

                if (!shedules.Any())
                {
                    return BadRequest("Student haven't schedules");
                }

                foreach (var shedule in shedules.Distinct())
                {
                    var lessons = await scheduleLesson.Where(sl => sl.ScheduleId == shedule.Id).ToListAsync();

                    var lessonMapping = _mapper.Map<List<ResponseLessonDto>>(lessons);
                    var lessonMappingWithDate = _mapper.Map<List<LessonWithDateDto>>(lessonMapping);

                    lessonResponse.Add(new LessonWithDateDto { Lessons = lessonMapping, Date = shedule.Date });
                }

                ClassDto calssMapping = _mapper.Map<ClassDto>(classes);

                response.Add(new ResponseScheduleByClassDto { Class = calssMapping, Lessons = lessonResponse });

                return Ok(response);
            }
            return BadRequest("this user it't your child");

        }

    }

}