using Application.Courses;
using Application.Courses.Dtos;
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
            var outputDto = await _coursesService.Add(inputDto);
          
            return Ok(outputDto);
        }
    }
}
