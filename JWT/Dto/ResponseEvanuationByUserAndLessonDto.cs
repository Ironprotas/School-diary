using DocumentFormat.OpenXml.Spreadsheet;
using JWT.Models;
using System.Text.Json.Serialization;

namespace JWT.Dto
{
    public class ResponseEvanuationByUserAndLessonDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string UserName {get;set;}
        public string Lesson { get;set;}
        public List<ResponseEvanuationsDto>? Evanations { get; set; }

    }
}
