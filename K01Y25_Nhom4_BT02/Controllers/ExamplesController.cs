using K01Y25_Nhom4_BT02.Models.Respone;
using K01Y25_Nhom4_BT02.Models.Request;
using K01Y25_Nhom4_BT02.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using K01Y25_Nhom4_BT02.Models;

namespace K01Y25_Nhom4_BT02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamplesController : ControllerBase
    {
        private readonly IExampleService _exampleService;

        public ExamplesController(IExampleService exampleService)
        {
            _exampleService = exampleService;
        }

        // GET: /api/Example_Res
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var exampleRess = _exampleService.GetAll();
            return Ok(ApiResponse<IEnumerable<Example_Res>>.Success(exampleRess, "Lấy danh sách thành công."));
        }

        // GET: /api/Example_Res/{id}
        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var example = _exampleService.GetById(id);
            if (example == null)
            {
                return Ok(ApiResponse<object>.Fail("Không tìm thấy Example với ID được cung cấp."));
            }

            return Ok(ApiResponse<Example_Res>.Success(example, "Lấy dữ liệu thành công."));
        }

        // POST: /api/Example_Res
        [HttpPost("create")]
        public IActionResult CreateExample([FromBody] Example_CreateReq newExample)
        {
            if (newExample == null || string.IsNullOrEmpty(newExample.Name))
            {
                return Ok(ApiResponse<object>.Fail("Dữ liệu không hợp lệ."));
            }

            var createdExample = _exampleService.Create(newExample);
            return Ok(ApiResponse<Example_Res>.Success(createdExample, "Tạo mới Example thành công."));
        }

        // PUT: /api/Example_Res/{id}
        [HttpPut("update/{id}")]
        public IActionResult UpdateExample(int id, [FromBody] Example_UpdateReq updatedExample)
        {
            if (updatedExample == null || string.IsNullOrEmpty(updatedExample.Name))
            {
                return Ok(ApiResponse<object>.Fail("Dữ liệu không hợp lệ."));
            }

            var updated = _exampleService.Update(id, updatedExample);
            if (updated == null)
            {
                return Ok(ApiResponse<object>.Fail("Không tìm thấy Example để cập nhật."));
            }

            return Ok(ApiResponse<Example_Res>.Success(updated, "Cập nhật Example thành công."));
        }

        // DELETE: /api/Example_Res/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteExample(int id)
        {
            var deleted = _exampleService.Delete(id);
            if (!deleted)
            {
                return Ok(ApiResponse<object>.Fail("Không tìm thấy Example để xóa."));
            }

            return Ok(ApiResponse<object>.Success(null, "Xóa Example thành công."));
        }
    }
}
