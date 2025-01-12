using K01Y25_Nhom4_BT02.Models;
using K01Y25_Nhom4_BT02.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace K01Y25_Nhom4_BT02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult CreateStudents([FromBody] string value)
        {
            return Ok();

        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateStudents(int id, [FromBody] string value)
        {
            return Ok();

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteStudentsAsync(int id)
        {
            var isDeleted = await _studentService.DeleteByIdAsync(id);

            if (!isDeleted)
            {
                var isEnrollment = await _studentService.GetEnrollmentByCourseIdAsync(id);
                if (isEnrollment != null && isEnrollment.Any())
                {
                    return BadRequest(ApiResponse<object>.Fail("Không thể xóa học viên này vì học viên đang trong một khóa học."));
                }
                else
                {
                    return NotFound(ApiResponse<object>.Fail("Không tìm thấy học viên với ID được cung cấp."));
                }
            }

            return Ok(ApiResponse<object>.Success(null, "Xóa học viên thành công."));
        }
    }
}
