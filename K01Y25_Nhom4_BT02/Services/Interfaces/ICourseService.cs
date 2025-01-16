using System.Threading.Tasks;
using K01Y25_Nhom4_BT02.DB.Table;
using K01Y25_Nhom4_BT02.Models.Request.Course;
using K01Y25_Nhom4_BT02.Models.Respone;

namespace K01Y25_Nhom4_BT02.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course_Res>> GetAllAsync();
        Course_CreateReq Create(Course_CreateReq request);
        Task<Course_Res?> GetByIdAsync(int id);

        Course_Res Update(int id, Course_UpdateReq req);
        Task<IEnumerable<Enrollment>> GetEnrollmentByCourseIdAsync(int courseId);
        Task<bool> DeleteByIdAsync(int id);
    }
}
