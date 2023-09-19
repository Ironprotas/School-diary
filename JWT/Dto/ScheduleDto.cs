using JWT.Models;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace JWT.Dto
{
    public class ScheduleDto
    {

        [JsonIgnore]
        public int Id { get; set; }

        public int LessonId { get; set; }

        public DateOnly Date { get; set; }

        public int NameLessonId { get; set; }

        public int? ClassId { get; set; }

        public int ScheduleId { get; set; }
    }
}


