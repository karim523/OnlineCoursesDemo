using Application.Students.Dtos;
using SimpleObjects.SubscriptionContext;

namespace Application.Students
{
    public interface IStudentsService
    {
        Task<SignUpOutputDto> SignUp(SignUpInputDto dto);
        Task<List<StudentDto>> GetAllStudents();
        Task<EnrollToCourseOutputDto> Enroll(EnrollToCourseInputDto inputDto);
        Task<CourseOutputDto> GetCourseStudents(GetCourseStudentInputDto inputDto);
    }
}
