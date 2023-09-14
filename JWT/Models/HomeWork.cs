namespace JWT.Models
{
    public class HomeWork : BaseModel
    { 
   //     public int Id { get; set; }

        public string Work { get; set; }

        public int LessonId { get; set; }

        public Lesson Lesson { get; set; }
    }
       
}
