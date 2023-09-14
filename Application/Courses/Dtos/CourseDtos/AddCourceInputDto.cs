using SimpleObjects.ContentContext.Enums;

namespace Application.Courses.Dtos.CourseDtos
{

    public class AddCourseInputDto
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string? Tag { get; set; }
        public EContentLevel Level { get; set; }
        public List<ModuleDto>? Modules { get; set; }
    }
    public class ModuleDto
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public List<LectureDto>? Lectures { get; set; }

    }
    public class LectureDto
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }
    }
}
