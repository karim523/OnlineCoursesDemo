using Application.Courses.Dtos.CourseDtos;
using Application.Courses.Dtos.LectureDtos;
using Application.Courses.Dtos.ModuleDtos;
using Domain;
using Domain.ContentContext.IRepository;
using SimpleObjects.ContentContext;

namespace Application.Courses
{
    public class CoursesService : ICoursesService
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

        public async Task<AddCourseOutputDto> AddCourse(AddCourseInputDto inputDto)
        {
            var courseDto = new Course(inputDto.Title, inputDto.Url, inputDto.Level, inputDto.Tag);

            if (inputDto.Modules is not null)
            {
                foreach (var inputModuleDto in inputDto.Modules)
                {
                    var moduleDto = new Module(inputModuleDto.Order, inputModuleDto.Title);

                    var moduleResult = courseDto.AddModule(moduleDto);

                    if ((!moduleResult) && courseDto.IsInvalid)
                    {
                        return new AddCourseOutputDto
                        {
                            Erorrs = courseDto.Notifications
                        };
                    }
                    if (inputModuleDto.Lectures is not null)
                    {
                        foreach (var inputLectureDto in inputModuleDto.Lectures)
                        {
                            var lectureDto = new Lecture(inputLectureDto.Order, inputLectureDto.Title, inputLectureDto.DurationInMinutes, inputLectureDto.Level);

                            var lectureResult = courseDto.AddLecture(moduleDto.Order, lectureDto);

                            if ((!lectureResult) && courseDto.IsInvalid)
                            {
                                return new AddCourseOutputDto
                                {
                                    Erorrs = courseDto.Notifications
                                };
                            }
                        }
                    }
                }
            }
            await _repository.Create(courseDto);

            await _unitOfWork.Commit();

            return new AddCourseOutputDto
            {
                Id = courseDto.Id,
            };
        }

        public async Task<AddModuleOutputDto> AddModule(AddModuleInputDto inputDto)
        {

            var course =await _coursesRepository.GetCourse(inputDto.CourseId);

            var moduleDto = new Module(inputDto.Order, inputDto.Title);

            var moduleResult = course.AddModule(moduleDto);

            if ((!moduleResult) && course.IsInvalid)
            {
                return new AddModuleOutputDto
                {
                    Erorrs = course.Notifications
                };
            }

            if (inputDto.Lectures is not null)
            {
                foreach (var inputLectureDto in inputDto.Lectures)
                {
                    var lectureDto = new Lecture(inputLectureDto.Order, inputLectureDto.Title, inputLectureDto.DurationInMinutes, inputLectureDto.Level);

                    var lectureResult = course.AddLecture(moduleDto.Order, lectureDto);

                    if ((!lectureResult) && course.IsInvalid)
                    {
                        return new AddModuleOutputDto
                        {
                            Erorrs = course.Notifications
                        };
                    }
                }
            }
            await _unitOfWork.Commit();

            return new AddModuleOutputDto()
            {
                ModuleId = moduleDto.Id
            };
        }

        public async Task<AddLectureOutputDto> AddLecture(AddLectureInputDto inputDto)
        {
            var course =await _coursesRepository.GetCourse(inputDto.CourseId);

            var lectureDto = new Lecture(inputDto.Order, inputDto.Title, inputDto.DurationInMinutes, inputDto.Level);

            var lectureResult = course.AddLecture(inputDto.ModuleId, lectureDto);

            if (!lectureResult && course.IsInvalid)
            {
                return new AddLectureOutputDto
                {
                    Erorrs = course.Notifications
                };

            }
            await _unitOfWork.Commit();
            return new AddLectureOutputDto()
            {
                Id = lectureDto.Id
            };
        }


        public async Task<UpdateCourseOutputDto> UpdateCourse(UpdateCourseIntputDto inputDto)
        {
            var course =await _coursesRepository.GetCourse(inputDto.Id);

            if (course == null)
            {
                return new UpdateCourseOutputDto
                {
                    Erorrs = new List<string>
                    {
                        "Course is not Found"
                    }
                };
            }
            var resultCourse = course.UpdateCourse(inputDto.Url, inputDto.Level, inputDto.Title, inputDto.Tag);

            if (resultCourse)
            {
                await _unitOfWork.Commit();

                return new UpdateCourseOutputDto()
                {
                    UpdatedCourseId = course.Id,
                };
            }
            return new UpdateCourseOutputDto()
            {
                Erorrs = course.Notifications,
            };
        }

        public async Task<UpdateModuleOutputDto> UpdateModule(UpdateModuleInputDto inputDto)
        {
            var course =await _coursesRepository.GetCourse(inputDto.CourseId);

            if (course == null)
            {
                return new UpdateModuleOutputDto
                {
                    Erorrs = new List<string>
                    {
                        "Course is not Found"
                    }
                };
            }

            var resultModule = course.UpdateModule(inputDto.ModuleId, inputDto.Order, inputDto.Title);
            if (resultModule)
            {
                await _unitOfWork.Commit();

                return new UpdateModuleOutputDto()
                {
                    UpdatedModuleId = inputDto.ModuleId,
                };
            }
            return new UpdateModuleOutputDto
            {
                Erorrs = course.Notifications
            };
        }

        public async Task<UpdateLectureOutputDto> UpdateLecture(UpdateLectureInputDto inputDto)
        {
            var course =await _coursesRepository.GetCourse(inputDto.CourseId);

            if (course == null)
            {
                return new UpdateLectureOutputDto
                {
                    Erorrs = new List<string>
                    {
                        "Course is not Found"
                    }
                };
            }

            var resultLecture = course.UpdateLecture(inputDto.ModuleId, inputDto.LectureId, inputDto.Title, inputDto.Level, inputDto.Order, inputDto.DurationInMinutes);
            if (resultLecture)
            {
                await _unitOfWork.Commit();
                return new UpdateLectureOutputDto
                {
                    UpdatedLectureId = inputDto.LectureId
                };
            }
            return new UpdateLectureOutputDto
            {
                Erorrs = course.Notifications
            };
        }


        public async Task<DeleteCourseOutputDto> DeleteCourse(DeleteCourseInputDto inputDto)
        {
            var course =await _coursesRepository.GetCourse(inputDto.Id);

            if (course != null)
            {
                return new DeleteCourseOutputDto
                {
                    Erorrs = new List<string>
                    {
                        "Course is not Found"
                    }
                };
            }
            _coursesRepository.Delete(course);

            await _unitOfWork.Commit();

            return new DeleteCourseOutputDto()
            {
                DeletedCourseId = inputDto.Id,
            };
        }

        public async Task<DeleteModuleOutputDto> DeleteModule(DeleteModuleInputDto inputDto)
        {
            var course =await _coursesRepository.GetCourse(inputDto.CourseId);

            if (course == null)
            {
                return new DeleteModuleOutputDto
                {
                    Erorrs = new List<string>
                    {
                        "Course is not Found"
                    }
                };

            }

            var moduleReslt = course.DeleteModule(inputDto.ModuleId);

            if (moduleReslt)
            {
                await _unitOfWork.Commit();

                return new DeleteModuleOutputDto()
                {
                    DeletedModuleId = inputDto.ModuleId
                };
            }

            return new DeleteModuleOutputDto()
            {
                Erorrs = course.Notifications
            };
        }

        public async Task<DeleteLectureOutputDto> DeleteLecture(DeleteLectureInputDto inputDto)
        {
            var course =await _coursesRepository.GetCourse(inputDto.CourseId);
            if (course == null)
            {
                return new DeleteLectureOutputDto
                {
                    Erorrs = new List<string>
                    {
                        "Course is not Found"
                    }
                };
            }
            var lectureResult = course.DeleteLecture(inputDto.ModuleId, inputDto.LectureId);

            if (lectureResult)
            {
                await _unitOfWork.Commit();

                return new DeleteLectureOutputDto()
                {
                    DeletedLectureId = inputDto.LectureId,
                };

            }
            return new DeleteLectureOutputDto
            {
                Erorrs = course.Notifications
            };
        }


        public async Task<List<CourseDto>> GetAllCourse(GetAllCoursesInputDto inputDto)
        {
            var courses =await _coursesRepository
                .GetAllCourse(inputDto.Title, inputDto.Level);
            
            List<CourseDto> coursesDto = courses.Select(course => new CourseDto
            {
                CourseId= course.Id,
                Url = course.Url,
                Level = course.Level,
                Title = course.Title,
                Tag = course.Tag,
                Modules = course.Modules.Select(module => new ModuleInListDto
                {
                    ModuleId= module.Id,
                    Order = module.Order,
                    Title = module.Title,
                    Lectures = module.Lectures.Select(lecture => new LectureInListDto
                    {
                        LectureId=lecture.Id,
                        Order = lecture.Order,
                        Title = lecture.Title,
                        Level = lecture.Level,
                        DurationInMinutes = lecture.DurationInMinutes
                    }).ToList()
                }).ToList()
            }).ToList();
           
            return coursesDto;
        }


        public async Task<CourseDto> GetCourse(GetCourseInputDto input)
        {
            var course =await _coursesRepository.GetCourse(input.CourseId);
            if (course==null) 
            {
                return new CourseDto 
                {
                    Erorrs = new List<string>
                    {
                        "Course is not Found"
                    }
                };
            }
            var courseDto = new CourseDto
            {
                CourseId = input.CourseId,
                Url = course.Url,
                Level = course.Level,
                Title = course.Title,
                Tag = course.Tag,
                Modules = course.Modules.Select(module => new ModuleInListDto
                {
                    ModuleId = module.Id,
                    Order = module.Order,
                    Title = module.Title,
                    Lectures = module.Lectures.Select(lecture => new LectureInListDto
                    {
                        LectureId = lecture.Id,
                        Order = lecture.Order,
                        Title = lecture.Title,
                        Level = lecture.Level,
                        DurationInMinutes = lecture.DurationInMinutes
                    }).ToList()
                }).ToList()
            };
           
            return courseDto;
        }

        public async Task<GetModuleOutputDto> GetModule(GetModuleInputDto input)
        {
           
            var module=await _coursesRepository.GetModule(input.ModuleId);
            if(module == null)
            {
                return new GetModuleOutputDto
                {
                    Erorrs = new List<string>
                    {
                        "Module is not Found"
                    }
                };
            }
            var moduleDto = new GetModuleOutputDto
            {
                ModuleId = module.Id,
                Order = module.Order,
                Title = module.Title,
                Lectures = module.Lectures.Select(lecture => new GetModuleLectureDto
                {
                    LectureId = lecture.Id,
                    Order = lecture.Order,
                    Title = lecture.Title,
                    Level = lecture.Level,
                    DurationInMinutes = lecture.DurationInMinutes
                }).ToList()

            };
            return moduleDto;
        }

        public async Task<GetLectureOutputDto> GetLecture(GetLectureInputDto input)
        {
            var lecture = await _coursesRepository.GetLecture(input.LectureId);
            if (lecture == null)
            {
                return new GetLectureOutputDto
                {
                    Erorrs = new List<string>
                    {
                        "Lecture is no Found"
                    }
                };
            }
            var lectureDto = new GetLectureOutputDto
            {
                LectureId = lecture.Id,
                Order = lecture.Order,
                DurationInMinutes = lecture.DurationInMinutes,
                Level = lecture.Level,
                Title = lecture.Title
            };
            return lectureDto;
        }
    }
}