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


        [HttpPut("UpdateCourse")]
        public async Task  <IActionResult> UpdateCourse(UpdateCourseIntputDto intputDto)
        {
            var outputDto =await  _coursesService.UpdateCourse(intputDto);
            return Ok(outputDto);
        }

        [HttpPut("UpdateModule")]
        public async Task <IActionResult> UpdateModule(UpdateModuleInputDto intputDto)
        {
            var outputDto = await _coursesService.UpdateModule(intputDto);
            return Ok(outputDto);
        }

        [HttpPut("UpdateLecture")]
        public async Task <IActionResult> UpdateLecture(UpdateLectureInputDto intputDto)
        {
            var outputDto = await _coursesService.UpdateLecture(intputDto);
            return Ok(outputDto);
        }
      
        

        [HttpDelete("DeleteCourse")]
        public async Task <IActionResult> DeleteCourse(DeleteCourseInputDto inputDto)
        {
            var ouputDto =await  _coursesService.DeleteCourse(inputDto);
            return Ok(ouputDto);
        }

        [HttpDelete("DeleteModule")]
        public async Task <IActionResult> DeleteModule(DeleteModuleInputDto inputDto)
        {
            var ouputDto =await _coursesService.DeleteModule(inputDto);
            return Ok(ouputDto);
        }

        [HttpDelete("DeleteLecture")]
        public async Task <IActionResult> DeleteLecture(DeleteLectureInputDto inputDto)
        {
            var ouputDto =await  _coursesService.DeleteLecture(inputDto);
            return Ok(ouputDto);
        }


        [HttpGet("GetAllCourses")]
        public async Task<IActionResult> GetAllCourse()
        {
            var output= await _coursesService.GetAllCourse();
            return Ok(output);
        }


        [HttpGet("GetCourse")]
        public async Task< IActionResult> GetCourse(GetCourseInputDto input)
        {
            var output =await _coursesService.GetCourse(input);
            return Ok(output);
        }
        [HttpGet("GetModule")]
        public async Task<IActionResult> GetModule(GetModuleInputDto input)
        {
            var output =await _coursesService.GetModule(input);
            return Ok(output);
        }
        [HttpGet("GetLecture")]
        public async Task<IActionResult> GetLecture(GetLectureInputDto input)
        {
            var output =await _coursesService.GetLecture(input);
            return Ok(output);
        }
    }
}
