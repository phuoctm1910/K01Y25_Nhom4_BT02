using System.Threading.Tasks;
using K01Y25_Nhom4_BT02.Models.Request.Course;
using K01Y25_Nhom4_BT02.Models.Respone;

namespace K01Y25_Nhom4_BT02.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course_Res>> GetAllAsync();
        Course_CreateReq Create(Course_CreateReq request);
        Task<Course_Res?> GetByIdAsync(int id);
    }
}
