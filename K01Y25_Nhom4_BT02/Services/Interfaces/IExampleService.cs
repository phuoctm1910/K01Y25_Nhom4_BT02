using K01Y25_Nhom4_BT02.Models.Request;
using K01Y25_Nhom4_BT02.Models.Respone;
using System.Security.AccessControl;

namespace K01Y25_Nhom4_BT02.Services.Interfaces
{
    public interface IExampleService
    {
        IEnumerable<Example_Res> GetAll();
        Example_Res GetById(int id);
        Example_Res Create(Example_CreateReq newObjective);
        Example_Res Update(int id, Example_UpdateReq updatedObjective);
        bool Delete(int id);
    }
}
