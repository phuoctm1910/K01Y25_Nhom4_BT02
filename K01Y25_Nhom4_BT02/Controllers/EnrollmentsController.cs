﻿using K01Y25_Nhom4_BT02.Models;
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

            return Ok(ApiResponse<Enrollment_UpdateRes>.Success(updatedEnrollment, "Cập nhật thành công."));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteEnrollments(int id)
        {
            return Ok();
        }
    }
}
