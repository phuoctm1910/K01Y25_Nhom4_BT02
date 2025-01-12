using K01Y25_Nhom4_BT02.Models.Respone;

namespace K01Y25_Nhom4_BT02.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<Enrollment_Res?> GetByIdAsync(int id);

    }
}
