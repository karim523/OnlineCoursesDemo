using SimpleObjects.ContentContext.Enums;
namespace Application.Courses.Dtos.CourseDtos
{
    public class CourseDto
    {
        public Guid? CourseId { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Tag { get; set; }
        public EContentLevel? Level { get; set; }
        public List<ModuleInListDto>? Modules { get; set; }
        public List<string>? Erorrs { get; set; }

    }
    public class ModuleInListDto
    {
        public Guid ModuleId { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public List<LectureInListDto>? Lectures { get; set; }

    }
    public class LectureInListDto
    {
        public Guid LectureId { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }
    }
}
