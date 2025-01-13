using K01Y25_Nhom4_BT02.Models.Respone;
using K01Y25_Nhom4_BT02.Models;
using Microsoft.AspNetCore.Mvc;
using K01Y25_Nhom4_BT02.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K01Y25_Nhom4_BT02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<Course_Res>>.Success(courses, "Lấy danh sách khóa học thành công."));
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return Ok(ApiResponse<object>.Fail("Không tìm thấy khóa học với ID được cung cấp."));
            }

            return Ok(ApiResponse<Course_Res>.Success(course, "Lấy thông tin khóa học thành công."));
        }

        [HttpPost("create")]
        public IActionResult CreateCourse([FromBody] string value)
        {
            return Ok();

        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] string value)
        {
            return Ok();

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            return Ok();
        }
    }
}
