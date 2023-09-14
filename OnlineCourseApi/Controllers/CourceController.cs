using Application.Courses;
using Application.Courses.Dtos.CourseDtos;
using Application.Courses.Dtos.LectureDtos;
using Application.Courses.Dtos.ModuleDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineCourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICoursesService _coursesService;

        public CourseController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddCourse(AddCourseInputDto inputDto)
        {
            var outputDto = await _coursesService.AddCourse(inputDto);
          
            return Ok(outputDto);
        }
        [HttpPost("AddModule")]
        public async Task<IActionResult> AddModule(AddModuleInputDto inputDto)
        {
            var outputDto = await _coursesService.AddModule(inputDto);

            return Ok(outputDto);
        }
        [HttpPost("AddLecture")]
        public async Task<IActionResult> AddLecture(AddLectureInputDto inputDto)
        {
            var outputDto = await _coursesService.AddLecture(inputDto);

            return Ok(outputDto);
        }

    }
}
