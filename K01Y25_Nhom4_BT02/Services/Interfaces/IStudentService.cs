using K01Y25_Nhom4_BT02.Models.Respone.Enrollment;

namespace K01Y25_Nhom4_BT02.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<Enrollment_Res?>> GetEnrollmentByCourseIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
    }
}
