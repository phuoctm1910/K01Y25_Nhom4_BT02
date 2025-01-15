using K01Y25_Nhom4_BT02.Models.Respone.Course;
using K01Y25_Nhom4_BT02.Models;
using Microsoft.AspNetCore.Mvc;
using K01Y25_Nhom4_BT02.Services.Interfaces;
using K01Y25_Nhom4_BT02.Models.Request.Course;
using K01Y25_Nhom4_BT02.DB.Table;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K01Y25_Nhom4_BT02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public int Courseid { get; private set; }
        public double Credits { get; private set; }

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
        public IActionResult CreateCourse([FromBody] Course_CreateReq request)
        {
            if (request == null)
            {
                return BadRequest(ApiResponse<Course_Res>.Fail("Tạo mới thất bại."));
            }

            // Gọi service để tạo mới khóa học
            var result = _courseService.Create(request);

            // Kiểm tra kết quả trả về
            if (result == null)
            {
                return BadRequest(ApiResponse<Course_Res>.Fail("Tạo mới thất bại."));
            }

            // Trả về kết quả thành công
            return Ok(ApiResponse<Course_CreateReq>.Success(result, "Tạo mới thành công."));
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] Course_UpdateReq req)
        {
            if (req == null)
            {
                return BadRequest(ApiResponse<object>.Fail("Dữ liệu cập nhật không hợp lệ."));
            }

            var updatedCourse = _courseService.Update(id, req);

            if (updatedCourse == null)
            {
                return NotFound(ApiResponse<object>.Fail("Không tìm thấy khóa học để cập nhật."));
            }

            return Ok(ApiResponse<Course_UpdateRes>.Success(updatedCourse, "Cập nhật khóa học thành công."));
        }
    

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            return Ok();
        }
    }
}
