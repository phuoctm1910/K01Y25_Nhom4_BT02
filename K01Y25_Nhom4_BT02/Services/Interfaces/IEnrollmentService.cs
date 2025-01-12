using K01Y25_Nhom4_BT02.Models.Respone;
using K01Y25_Nhom4_BT02.Models.Respone.Course;
using K01Y25_Nhom4_BT02.Models.Respone.Enrollment;

namespace K01Y25_Nhom4_BT02.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<bool> DeleteByIdAsync(int id);
    }
}
