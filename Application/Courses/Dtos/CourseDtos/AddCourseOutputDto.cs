using Application.Courses.Dtos.ModuleDtos;

namespace Application.Courses.Dtos.CourseDtos
{
    public class AddCourseOutputDto
    {
        public Guid? Id { get; set; }
        public List<string>? Erorrs { get; set; }

    }
}
