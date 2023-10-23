using Application.Students.Dtos;
using Domain;
using Domain.ContentContext.IRepository;
using Domain.SubscriptionContext;
using SimpleObjects.SubscriptionContext;


namespace Application.Students
{
    public class StudentsService : IStudentsService
    {
        private readonly IRepository<Student> _repository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentsService(IRepository<Student> repository, IStudentRepository studentRepository, IUnitOfWork unitOfWork, ICourseRepository courseRepository)
        {
            _repository = repository;
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
        }
        public async Task<SignUpOutputDto> SignUp(SignUpInputDto dto)
        {
            var userDto = new User(dto.Username, dto.Password);

            var student = Student.SignUp(dto.Name, dto.Email, userDto);

            await _repository.Create(student);
            
            await _unitOfWork.Commit();

            return new SignUpOutputDto
            {
                Id = student.Id
            };
        }

        public async Task<List<StudentDto>> GetAllStudents()
        {
            var students =await _studentRepository.GetAll();

            List<StudentDto> studentsDto = students.Select(student => new StudentDto
            {
                StudentId = student.Id,
                Name = student.Name,
                Email = student.Email
               
            }).ToList();
            return studentsDto;
        }

        public async Task<EnrollToCourseOutputDto> Enroll(EnrollToCourseInputDto inputDto)
        {
            var student = await _studentRepository.GetStudent(inputDto.StudentId);
          
            if (student == null)
            { 
                return new EnrollToCourseOutputDto()
                {
                    Erorrs = new List<string> 
                    {
                        "Student is not Found"
                    }
                }; 
            }
            var course= await _courseRepository.GetCourse (inputDto.CourseId);
            if (course == null)
            {
                return new EnrollToCourseOutputDto()
                {
                    Erorrs = new List<string>
                    {
                        "Course is not Found"
                    }
                };
            }

            var studentResult = student.EnrollToCourse(course);
           
            if (!studentResult)
            {
                return new EnrollToCourseOutputDto()
                {
                    Erorrs = student.Notifications
                };
            }
            await _unitOfWork.Commit();
            
            return new EnrollToCourseOutputDto()
            {
               CourseEnrollmentId =student.Courses.Last().Id
            };
        }

        public async Task<CourseOutputDto> GetCourseStudents(GetCourseStudentInputDto inputDto)
        {
            var course = await _courseRepository.GetCourseStudents(inputDto.CourseId);
            if (course is null)
            {
                return new CourseOutputDto()
                {
                    Erorr = "Course is not Exist"
                };
            }
            CourseOutputDto courseOutputDto = new()
            {
                CourseId = course.Id,
                Level = course.Level,
                Tag = course.Tag,
                Title = course.Title,
                Url = course.Url,

                Students = course.Students.Select(student => new GetCourseStudentOutputDto()
                {
                    StudentEmail = student.Student.Email,
                    StudentId = student.Student.Id,
                    StudentName = student.Student.Name
                }).ToList()
            };

            return courseOutputDto;
        }

    }
}
