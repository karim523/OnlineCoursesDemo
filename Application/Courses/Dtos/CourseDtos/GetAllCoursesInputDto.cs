using SimpleObjects.ContentContext.Enums;

namespace Application.Courses.Dtos.CourseDtos
{
    public class GetAllCoursesInputDto
    {
        public string? Title { get; set; }
        public EContentLevel? Level { get; set; }

    }
}
