using Application.Students;
using Application.Students.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineCourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentsService _studentService;

        public StudentController(IStudentsService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpInputDto inputDto )
        {
            var outputDto = await _studentService.SignUp(inputDto);

            return Ok(outputDto);
        }
    }
}