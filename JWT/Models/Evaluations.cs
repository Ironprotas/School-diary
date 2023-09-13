namespace JWT.Models
{
    public class Evaluations : BaseModel
    {
      // public int id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int Evaluaton { get; set; }


    }
}

