using SimpleObjects.ContentContext.Enums;

namespace Application.Courses.Dtos.CourseDtos
{
    public class UpdateCourseOutputDto
    {
        public Guid? UpdatedCourseId { get;  set; }

        public List<string>? Erorrs { get; set; }
    }
}
