using K01Y25_Nhom4_BT02.Models.Respone;
using K01Y25_Nhom4_BT02.Models;
using K01Y25_Nhom4_BT02.Services.Interfaces;
using K01Y25_Nhom4_BT02.Models.Request.Student;
using K01Y25_Nhom4_BT02.Models.Respone.Course;
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
        public IActionResult CreateStudents([FromBody] Student_CreateReq request)
        {
            if (request == null) { return BadRequest(ApiResponse<Student_Res>.Fail("Tạo mới thất bại.")); }

            var student = _studentService.Create(request);

            if (student == null) { return BadRequest(ApiResponse<Student_Res>.Fail("Tạo mới thất bại.")); }

            return Ok(ApiResponse<Student_CreateReq>.Success(student, "Tạo mới thành công."));
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateStudents(int id, [FromBody] Student_UpdateReq request)
        {
            // Kiểm tra nếu request là null
            if (request == null)
            {
                return BadRequest(ApiResponse<object>.Fail("Cập nhật thất bại. Dữ liệu không hợp lệ."));
            }

            // Sử dụng service để thực hiện cập nhật
            var updatedStudent = _studentService.Update(id, request);

            // Kiểm tra nếu không tìm thấy sinh viên hoặc cập nhật thất bại
            if (updatedStudent == null)
            {
                return BadRequest(ApiResponse<object>.Fail("Cập nhật thất bại. Không tìm thấy sinh viên để cập nhật."));
            }

            // Trả về phản hồi thành công
            return Ok(ApiResponse<Student_Res>.Success(updatedStudent, "Cập nhật sinh viên thành công."));
        }



        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStudents(int id)
        {
            return Ok();
        }
    }
}
