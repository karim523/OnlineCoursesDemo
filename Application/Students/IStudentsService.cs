using Application.Students.Dtos;

namespace Application.Students
{
    public interface IStudentsService
    {
        Task<SignUpOutputDto> SignUp(SignUpInputDto dto);
    }
}
