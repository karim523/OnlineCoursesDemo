using SimpleObjects.ContentContext.Enums;

namespace Application.Courses.Dtos.ModuleDtos
{
    public class AddModuleInputDto
    {
        public Guid CourseId { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public List<LectureModuleDto>? Lectures { get; set; }

    }
    public class LectureModuleDto
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }
    }

}
