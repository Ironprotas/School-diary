using JWT.Base;

namespace JWT.Models
{
    public class SettingsLesson : BaseModel
    { 
//        public int Id { get; set; }

        public int Cabinet { get; set; }
        public TimeOnly StartLesson { get; set; }
        public TimeOnly EndLesson { get; set; }

        public string? TeacherId { get; set; }
        public AppUser Teacher { get; set; }

        public SettingsLesson(string startLesson, string endLesson)
        {
            StartLesson = TimeOnly.Parse(startLesson);
            EndLesson = TimeOnly.Parse(endLesson);
        }
        public SettingsLesson()
        {

        }

    }
}

