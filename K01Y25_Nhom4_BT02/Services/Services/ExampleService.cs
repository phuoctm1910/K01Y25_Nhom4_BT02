using K01Y25_Nhom4_BT02.Models.Request;
using K01Y25_Nhom4_BT02.Models.Respone;
using K01Y25_Nhom4_BT02.Services.Interfaces;

namespace K01Y25_Nhom4_BT02.Services.Services
{
    public class ExampleService : IExampleService
    {
        private readonly Dictionary<int, Example_Res> _examples;
        private int _currentId;

        public ExampleService()
        {
            // Dữ liệu tạm thời
            _examples = new Dictionary<int, Example_Res>
            {
                { 1, new Example_Res { Id = 1, Name = "Example 1", Description = "Description of Example 1" } },
                { 2, new Example_Res { Id = 2, Name = "Example 2", Description = "Description of Example 2" } }
            };
            _currentId = _examples.Keys.Max();
        }

        public IEnumerable<Example_Res> GetAll()
        {
            return _examples.Values.ToList();
        }

        public Example_Res GetById(int id)
        {
            if (!_examples.ContainsKey(id))
                return null;

            return _examples[id];
        }

        public Example_Res Create(Example_CreateReq newExample)
        {
            if (newExample == null) return null;

            // Tự động tăng ID
            _currentId++;
            var exampleRes = new Example_Res
            {
                Id = _currentId,
                Name = newExample.Name,
                Description = newExample.Description
            };

            // Thêm vào dictionary
            _examples.Add(exampleRes.Id, exampleRes);
            return exampleRes;
        }

        public Example_Res Update(int id, Example_UpdateReq updatedExample)
        {
            if (!_examples.ContainsKey(id))
                return null;

            var existingExample = _examples[id];
            existingExample.Name = updatedExample.Name;
            existingExample.Description = updatedExample.Description;

            return existingExample;
        }

        public bool Delete(int id)
        {
            if (!_examples.ContainsKey(id))
                return false;

            _examples.Remove(id);
            return true;
        }
    }
}
