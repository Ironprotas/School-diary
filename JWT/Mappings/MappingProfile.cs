using AutoMapper;
using JWT.Base;
using JWT.Dto;
using JWT.Models;
using Microsoft.AspNet.Identity;

namespace JWT.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EditUserDto, AppUser>();

            CreateMap<AppUser, UserDto>().ReverseMap();

            CreateMap<ScheduleDto, Schedule>().ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.ClassId, opt => opt.Ignore());

            CreateMap<ScheduleDto, ScheduleLesson>().ForMember(dest => dest.LessonId, opt => opt.MapFrom(src => src.NameLessonId))
                .ForMember(dest => dest.SettingsLessonId, opt => opt.MapFrom(src => src.LessonId))
                .ForMember(dest => dest.ScheduleId, opt => opt.Ignore());

            CreateMap<ScheduleLesson, ResponseLessonDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Lesson.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Lesson.Name))
                .ForMember(dest => dest.Cabinet, opt => opt.MapFrom(src => src.SettingsLesson.Cabinet))
                .ForMember(dest => dest.EndLesson, opt => opt.MapFrom(src => src.SettingsLesson.EndLesson))
                .ForMember(dest => dest.StartLesson, opt => opt.MapFrom(src => src.SettingsLesson.StartLesson));

            CreateMap<ResponseLessonDto, LessonWithDateDto>();

            CreateMap<Class, ClassDto>();

            CreateMap<EvanuationsDto, Evaluations>().ForMember(dest => dest.Evaluaton, opt => opt.MapFrom(src => src.Evaluaton))
                .ForMember(dest => dest.UserId, opt => opt.Ignore()).ForMember(dest => dest.LessonId, opt => opt.MapFrom(src => src.LessonId));

            CreateMap< Evaluations, ResponseEvanuationsDto>().ForMember(dest => dest.Evanuation, opt => opt.MapFrom(src => src.Evaluaton));

            CreateMap<Evaluations, ResponseEvanuationbyLessonDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Lesson.Name))
                .ForMember(dest => dest.Evanations, opt => opt.Ignore()).ForMember(dest => dest.Date, opt => opt.Ignore());


           //CreateMap<List<int>, List<ResponseEvanuationsDto>>();
        }  

    }
}



