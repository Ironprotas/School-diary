using JWT.Base;

namespace JWT.Models
{
    public class ScheduleLesson : BaseModel
    {
   //   public int Id { get; set; }

        public int ScheduleId { get; set; }

         public int LessonId { get; set; }

        public Schedule Schedule { get; set; }

        public Lesson Lesson { get; set; }

        public int SettingsLessonId { get; set; }
        public SettingsLesson SettingsLesson { get; set; }



    }
}


