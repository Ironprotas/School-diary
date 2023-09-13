using System.Text.Json.Serialization;

namespace JWT.Dto
{
    public class ResponseLessonDto
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public int Cabinet { get; set; }
        public TimeOnly StartLesson { get; set; }
        public TimeOnly EndLesson { get; set; }
    }
}
