using K01Y25_Nhom4_BT02.Models.Respone;
using K01Y25_Nhom4_BT02.Models;
using K01Y25_Nhom4_BT02.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using K01Y25_Nhom4_BT02.Models.Respone;

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
        public async Task<IActionResult> GetAll()
        {
            var student = await _studentService.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<Student_Res>>.Success(student, "Lấy danh sách học sinh thành công."));
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return Ok(ApiResponse<object>.Fail("Không tìm thấy thông tin học sinh."));
            }

            return Ok(ApiResponse<Student_Res>.Success(student, "Lấy thông tin học sinh thành công."));
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
        public IActionResult DeleteStudents(int id)
        {
            return Ok();
        }
    }
}
