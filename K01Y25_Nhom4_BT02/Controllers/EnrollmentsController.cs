using K01Y25_Nhom4_BT02.Models.Respone;
using K01Y25_Nhom4_BT02.Models;
using K01Y25_Nhom4_BT02.Services.Interfaces;
using K01Y25_Nhom4_BT02.Services.Services;
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
        public IActionResult GetAll()
        {
            return Ok();
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
        public IActionResult CreateEnrollments([FromBody] string value)
        {
            return Ok();

        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateEnrollments(int id, [FromBody] string value)
        {
            return Ok();

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteEnrollments(int id)
        {
            return Ok();
        }
    }
}
