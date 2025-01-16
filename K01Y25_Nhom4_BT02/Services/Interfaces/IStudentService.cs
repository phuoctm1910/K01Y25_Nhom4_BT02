using K01Y25_Nhom4_BT02.Models.Respone;

using K01Y25_Nhom4_BT02.Models.Request.Student;
using K01Y25_Nhom4_BT02.DB.Table;

namespace K01Y25_Nhom4_BT02.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Student_Res?> GetByIdAsync(int id);

        Task<IEnumerable<Student_Res>> GetAllAsync();
        Student_CreateReq Create(Student_CreateReq req);


        // Các phương thức khác
        Student_UpdateReq Update(int id, Student_UpdateReq req);
        Task<IEnumerable<Enrollment>> GetEnrollmentByCourseIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
    }
}
