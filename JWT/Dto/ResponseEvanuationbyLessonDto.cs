using System.Text.Json.Serialization;

namespace JWT.Dto
{
    public class ResponseEvanuationbyLessonDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ResponseEvanuationsDto>? Evanations { get; set; }
        public DateOnly Date { get; set; }
       
    
    }
}
