using System.Text.Json.Serialization;

namespace JWT.Dto
{
    public class ResponseClassByStudentWithEvanuations
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string NameClass { get; set; }
        public int NumberClass { get; set; }
        public List<ResponseEvanuationByUserAndLessonDto> UserLessonByEvanuations { get; set; }

    }
}
