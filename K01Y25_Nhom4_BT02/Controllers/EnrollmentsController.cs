using K01Y25_Nhom4_BT02.Models;
using K01Y25_Nhom4_BT02.Models.Request.Enrollment;
using K01Y25_Nhom4_BT02.Models.Respone.Enrollment;
using K01Y25_Nhom4_BT02.Services.Interfaces;
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
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult CreateEnrollments([FromBody] Enrollment_CreateReq req)
        {
            if (req == null) { return BadRequest(ApiResponse<Enrollment_CreateRes>.Fail("Tạo mới thất bại."));  }

            var Enrollment = _enrollmentService.Create(req);
            if (Enrollment == null) { return BadRequest(ApiResponse<Enrollment_CreateRes>.Fail("Tạo mới thất bại."));  }

            return Ok(ApiResponse<Enrollment_CreateReq>.Success(Enrollment, "Tạo mới thành công."));

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
