using K01Y25_Nhom4_BT02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace K01Y25_Nhom4_BT02.Controllers
{

    public class Example
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        // Dictionary làm data store tạm thời
        private static Dictionary<int, Example> examples = new Dictionary<int, Example>
        {
            { 1, new Example { Id = 1, Name = "Objective 1", Description = "Description of Objective 1" } },
            { 2, new Example { Id = 2, Name = "Objective 2", Description = "Description of Objective 2" } }
        };


        [HttpGet]
        public IActionResult GetAllExamples()
        {
            var Examples = examples.Values.ToList();
            return Ok(ApiResponse<IEnumerable<Example>>.Success(Examples, null)); // có thể thêm message nếu thành công
        }

        // GET: /api/Examples/{id}
        [HttpGet("{id}")]
        public IActionResult GetObjectiveById(int id)
        {
            if (!examples.ContainsKey(id))
            {
                return Ok(ApiResponse<object>.Fail("Không tìm thấy..."));
            }

            var objective = examples[id];
            return Ok(ApiResponse<Example>.Success(objective, null));
        }


    }
}
