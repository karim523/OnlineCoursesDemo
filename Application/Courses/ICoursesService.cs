using Application.Courses.Dtos.CourseDtos;
using Application.Courses.Dtos.LectureDtos;
using Application.Courses.Dtos.ModuleDtos;

namespace Application.Courses
{
    public interface ICoursesService
    {
        Task<AddCourceOutputDto> AddCourse(AddCourseInputDto inputDto);
        Task<AddLectureOutputDto> AddLecture(AddLectureInputDto inputDto);
        Task<AddModuleOutputDto> AddModule(AddModuleInputDto inputDto);

    }
}
