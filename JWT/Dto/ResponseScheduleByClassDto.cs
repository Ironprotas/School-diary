namespace JWT.Dto
{
    public class ResponseScheduleByClassDto
    {
        public ClassDto Class { get; set; }

        public List<LessonWithDateDto>? Lessons { get; set; }
    }
}
