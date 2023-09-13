using Application.Courses.Dtos;
using Domain;
using SimpleObjects.ContentContext;

namespace Application.Courses
{
    public class CoursesService:ICoursesService
    {
        private readonly IRepository<Course> _repository;

        public CoursesService( IRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<AddCourceOutputDto> Add(AddCourseInputDto inputDto)
        {
            var courseDto = new Course(inputDto.Title, inputDto.Url, inputDto.Level, inputDto.Tag);

            if (inputDto.Modules is not null)
            {
                foreach (var inputModuleDto in inputDto.Modules)
                {
                    var moduleDto = new Module(inputModuleDto.Order, inputModuleDto.Title);

                    if (inputModuleDto.Lectures is not null)
                    {

                        foreach (var inputLectureDto in inputModuleDto.Lectures)
                        {
                            var lectureDto = new Lecture(inputLectureDto.Order, inputLectureDto.Title, inputLectureDto.DurationInMinutes, inputLectureDto.Level);

                            moduleDto.AddLecture(lectureDto);
                        }

                        courseDto.AddModule(moduleDto);
                    }
                }
            }

            await _repository.Create(courseDto);
         
            var outputDto= new AddCourceOutputDto
            {
                Id=courseDto.Id,
            };

            return outputDto;
        }
    }
}
