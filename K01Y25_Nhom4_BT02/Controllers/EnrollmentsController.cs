using K01Y25_Nhom4_BT02.DB.Table;
using K01Y25_Nhom4_BT02.Models.Respone.Course;
using K01Y25_Nhom4_BT02.Models;
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
        public async Task<IActionResult> DeleteEnrollmentsAsync(int id)
        {
            var isDelete = await _enrollmentService.DeleteByIdAsync(id);
            if (!isDelete)
            {
                return Ok(ApiResponse<object>.Fail("Xóa không thành công"));
            }

            return Ok(ApiResponse<Course_Res>.Success(null, "Xóa thành công"));
        }
    }
}
