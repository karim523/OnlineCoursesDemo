using Application.Courses.Dtos.CourseDtos;
using Application.Courses.Dtos.LectureDtos;
using Application.Courses.Dtos.ModuleDtos;

namespace Application.Courses
{
    public interface ICoursesService
    { 
        Task<AddCourseOutputDto> AddCourse(AddCourseInputDto inputDto);
        Task<AddLectureOutputDto> AddLecture(AddLectureInputDto inputDto);
        Task<AddModuleOutputDto> AddModule(AddModuleInputDto inputDto);
        
        Task<UpdateCourseOutputDto> UpdateCourse(UpdateCourseIntputDto inputDto);
        Task<UpdateModuleOutputDto> UpdateModule(UpdateModuleInputDto inputDto);
        Task<UpdateLectureOutputDto> UpdateLecture(UpdateLectureInputDto inputDto);

        Task<DeleteCourseOutputDto> DeleteCourse(DeleteCourseInputDto inputDto);
        Task<DeleteModuleOutputDto> DeleteModule(DeleteModuleInputDto inputDto);
        Task<DeleteLectureOutputDto> DeleteLecture(DeleteLectureInputDto inputDto);

        Task<List<CourseDto>> GetAllCourse(GetAllCoursesInputDto inputDto);

        Task <CourseDto> GetCourse(GetCourseInputDto input);
        Task<GetModuleOutputDto> GetModule(GetModuleInputDto input);
        Task<GetLectureOutputDto> GetLecture(GetLectureInputDto input);

        Task<StudentOutputDto> GetStudentCourses(GetStudentCourseInputDto input);

    }
}
