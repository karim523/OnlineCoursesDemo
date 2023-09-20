
using SimpleObjects.ContentContext.Enums;

namespace Application.Courses.Dtos.CourseDtos
{
    public class UpdateCourseIntputDto
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string? Tag { get; set; }
        public EContentLevel Level { get;  set; }


    }
}
