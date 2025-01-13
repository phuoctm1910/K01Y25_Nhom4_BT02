using K01Y25_Nhom4_BT02.Models.Respone;

namespace K01Y25_Nhom4_BT02.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course_Res>> GetAllAsync();
        Task<Course_Res?> GetByIdAsync(int id);
    }
}
