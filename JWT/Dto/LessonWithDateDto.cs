namespace JWT.Dto
{
    public class LessonWithDateDto
    {
        public List<ResponseLessonDto>? Lessons { get; set; }

        public DateOnly Date { get; set; }
    }
}
