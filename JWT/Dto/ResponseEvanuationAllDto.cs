using System.Text.Json.Serialization;

namespace JWT.Dto
{
    public class ResponseEvanuationAllDto
    {

        public string LessonName { get; set; }
        public List<int>? Evanations { get; set; }
        public DateOnly Date { get; set; }
        public string UserName { get; set; }
    }
}
