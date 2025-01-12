using K01Y25_Nhom4_BT02.Models.Respone;
using K01Y25_Nhom4_BT02.Models.Respone.Course;
using K01Y25_Nhom4_BT02.Models.Respone.Enrollment;

namespace K01Y25_Nhom4_BT02.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course_Res>> GetAllAsync();
        Task<Course_Res?> GetByIdAsync(int id);
        Task<List<Enrollment_Res?>> GetEnrollmentByCourseIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
    }
}
