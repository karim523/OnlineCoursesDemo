using Application.Students.Dtos;
using AutoMapper;
using Domain;
using SimpleObjects.SubscriptionContext;


namespace Application.Students
{
    public class StudentsService : IStudentsService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Student> _repository;

        public StudentsService(IMapper mapper, IRepository<Student> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<SignUpOutputDto> SignUp(SignUpInputDto dto)
        {
            var userDto = new User(dto.Username, dto.Password);

            var student = Student.SignUp(dto.Name, dto.Email, userDto);

            await _repository.Create(student);
            var signUpOutput = new SignUpOutputDto
            {
                Id = student.Id
            };
            return signUpOutput;
        }
    }
}
