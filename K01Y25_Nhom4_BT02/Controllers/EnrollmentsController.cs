using K01Y25_Nhom4_BT02.Models;
using K01Y25_Nhom4_BT02.Models.Respone;
using K01Y25_Nhom4_BT02.Services.Interfaces;
using K01Y25_Nhom4_BT02.Models.Request.Enrollment;
using K01Y25_Nhom4_BT02.DB.Table;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace K01Y25_Nhom4_BT02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var enrollments = await _enrollmentService.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<Enrollment_Res>>.Success(enrollments, "Lấy danh sách tuyển sinh thành công."));
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var enrollment = await _enrollmentService.GetByIdAsync(id);
            if (enrollment == null)
            {
                return Ok(ApiResponse<object>.Fail("Không tìm thấy thông tin tuyển sinh."));
            }

            return Ok(ApiResponse<Enrollment_Res>.Success(enrollment, "Lấy thông tin tuyển sinh thành công."));

        }

        [HttpPost("create")]
        public IActionResult CreateEnrollments([FromBody] Enrollment_CreateReq req)
        {
            if (req == null) { return BadRequest(ApiResponse<Enrollment_Res>.Fail("Tạo mới thất bại."));  }

            var Enrollment = _enrollmentService.Create(req);
            if (Enrollment == null) { return BadRequest(ApiResponse<Enrollment_Res>.Fail("Tạo mới thất bại."));  }

            return Ok(ApiResponse<Enrollment_CreateReq>.Success(Enrollment, "Tạo mới thành công."));

        }

       
        [HttpPut("update/{id}")]
        public IActionResult UpdateEnrollments(int id, [FromBody] Enrollment_UpdateReq request)
        {
            if (request == null)
            {
                return BadRequest(ApiResponse<object>.Fail("Dữ liệu cập nhật không hợp lệ."));
            }

            var updatedEnrollment = _enrollmentService.Update(id, request);

            if (updatedEnrollment == null)
            {
                return NotFound(ApiResponse<object>.Fail("Không tìm thấy bản ghi để cập nhật."));
            }

            return Ok(ApiResponse<Enrollment_Res>.Success(updatedEnrollment, "Cập nhật thành công."));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEnrollmentsAsync(int id)
        {
            var isDelete = await _enrollmentService.DeleteByIdAsync(id);
            if (!isDelete)
            {
                return Ok(ApiResponse<object>.Fail("Xóa không thành công"));
            }

            return Ok(ApiResponse<Enrollment_Res>.Success(new Enrollment_Res(), "Xóa thành công"));
        }
    }
}
