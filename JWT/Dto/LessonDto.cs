using System.Text.Json.Serialization;

namespace JWT.Dto
{
    public class LessonDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        public int Cabinet { get; set; }
        public int Number { get; set; }
        public string TeacherId { get; set; }


    }
}





