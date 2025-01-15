using K01Y25_Nhom4_BT02.Models.Request.Enrollment;
using K01Y25_Nhom4_BT02.Models.Respone.Enrollment;

namespace K01Y25_Nhom4_BT02.Services.Interfaces
{
    public interface IEnrollmentService
    {
        object Enrollments { get; set; }

        Enrollment_CreateReq Create(Enrollment_CreateReq req);

        // Thêm phương thức Update
        Enrollment_UpdateRes Update(int id, Enrollment_UpdateReq req);


    }
}
