using Application.Courses.Dtos.ModuleDtos;

namespace Application.Courses.Dtos.CourseDtos
{
    public class AddCourceOutputDto
    {
        public Guid? Id { get; set; }
        public List<string>? Erorrs { get; set; }

    }
}
