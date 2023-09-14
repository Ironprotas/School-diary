using JWT.Models;
using System.Text.Json.Serialization;

namespace JWT.Dto
{
    public class EvanuationsDto
    {
        [JsonIgnore]
        public int id { get; set; }

        public string UserName { get; set; }

        public int LessonId { get; set; }

        public int Evaluaton { get; set; }

    }
}
