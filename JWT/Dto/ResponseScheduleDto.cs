using System.Text.Json.Serialization;

namespace JWT.Dto
{
    public class ResponseScheduleDto
    {

        
        public int Id { get; set; }

        public List<ResponseLessonDto>? Lessons { get; set; }

        public DateOnly Date { get; set; }

        public ClassDto Class { get; set; }

     
    }
}
