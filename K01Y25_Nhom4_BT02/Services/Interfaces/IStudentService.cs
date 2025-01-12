using K01Y25_Nhom4_BT02.Models.Respone;

namespace K01Y25_Nhom4_BT02.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Student_Res?> GetByIdAsync(int id);

        Task<IEnumerable<Student_Res>> GetAllAsync();
    }
}
