using Application.Courses.Dtos;

namespace Application.Courses
{
    public interface ICoursesService
    {
        Task<AddCourceOutputDto> Add(AddCourseInputDto inputDto);
    }
}
