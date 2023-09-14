using Application.Courses.Dtos.CourseDtos;
using Application.Courses.Dtos.LectureDtos;
using Application.Courses.Dtos.ModuleDtos;
using Domain;
using Domain.ContentContext;
using SimpleObjects.ContentContext;

namespace Application.Courses
{
    public class CoursesService:ICoursesService
    {
        private readonly IRepository<Course> _repository;
        private readonly ICourseRepository _coursesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CoursesService(IRepository<Course> repository, IUnitOfWork unitOfWork, ICourseRepository coursesRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _coursesRepository = coursesRepository;
        }

        public async Task<AddCourceOutputDto> AddCourse(AddCourseInputDto inputDto)
        {
            var courseDto = new Course(inputDto.Title, inputDto.Url, inputDto.Level, inputDto.Tag);

            if (inputDto.Modules is not null)
            {
                foreach (var inputModuleDto in inputDto.Modules)
                {
                    var moduleDto = new Module(inputModuleDto.Order, inputModuleDto.Title);
                    
                    var  moduleResult = courseDto.AddModule(moduleDto);

                    if ((!moduleResult) && courseDto.IsInvalid)
                    {

                        var outputError = new AddCourceOutputDto
                        {
                            Erorrs = courseDto.Notifications
                        };

                        return outputError;
                    }

                    if (inputModuleDto.Lectures is not null)
                    {

                        foreach (var inputLectureDto in inputModuleDto.Lectures)
                        {
                            var lectureDto = new Lecture(inputLectureDto.Order, inputLectureDto.Title, inputLectureDto.DurationInMinutes, inputLectureDto.Level);

                            var lectureResult = courseDto.AddLecture(moduleDto.Order,lectureDto);

                            if ((!lectureResult) && courseDto.IsInvalid)
                            {

                                var outputError = new AddCourceOutputDto
                                {
                                    Erorrs = courseDto.Notifications
                                };

                                return outputError;

                            }
                        }
                    }                 
                }
            }
                      
            await _repository.Create(courseDto);

            await _unitOfWork.Commit();

            var outputDto = new AddCourceOutputDto
            {
                Id=courseDto.Id,
            };

            return outputDto;
        }
      
        public async Task<AddModuleOutputDto> AddModule(AddModuleInputDto inputDto)
        {

            var course =await _coursesRepository.GetCourse(inputDto.CourseId);

            var moduleDto = new Module(inputDto.Order, inputDto.Title);
            
            var moduleResult = course.AddModule(moduleDto);

            if ((!moduleResult) && course.IsInvalid)
            {
                var outputError = new AddModuleOutputDto
                {
                    Erorrs = course.Notifications
                };

                return outputError;

            }

            if (inputDto.Lectures is not null)
            {

                foreach (var inputLectureDto in inputDto.Lectures)
                {
                    var lectureDto = new Lecture(inputLectureDto.Order, inputLectureDto.Title, inputLectureDto.DurationInMinutes, inputLectureDto.Level);                  

                    
                     var lectureResult = course.AddLecture(moduleDto.Order, lectureDto);

                    if ((!lectureResult) && course.IsInvalid)
                    {
                        var outputError = new AddModuleOutputDto
                        {
                            Erorrs = course.Notifications
                        };

                        return outputError;

                    }
                }
            }

            await _unitOfWork.Commit();
           
            var outputDto = new AddModuleOutputDto()
            {
                ModuleId = moduleDto.Id
            };

            return outputDto;           
        }

        public async Task<AddLectureOutputDto> AddLecture(AddLectureInputDto inputDto)
        {
            var course =await _coursesRepository.GetCourse(inputDto.CourseId);

            var lectureDto = new Lecture(inputDto.Order, inputDto.Title, inputDto.DurationInMinutes, inputDto.Level);

            var lectureResult=  course.AddLecture(inputDto.ModuleId, lectureDto);

            if (!lectureResult && course.IsInvalid)
            {
                var outputError = new AddLectureOutputDto
                {
                    Erorrs = course.Notifications
                };

                return outputError;

            }
            await _unitOfWork.Commit();
            var outputDto = new AddLectureOutputDto()
            {
                Id = lectureDto.Id
            };

            return outputDto;
        }   
    }
}