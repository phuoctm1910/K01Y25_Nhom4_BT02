using K01Y25_Nhom4_BT02.Models.Request.Student;
using K01Y25_Nhom4_BT02.Models.Respone.Student;

namespace K01Y25_Nhom4_BT02.Services.Interfaces
{
    public interface IStudentService
    {
        Student_CreateReq Create(Student_CreateReq req);


        // Các phương thức khác
        Student_UpdateRes Update(int id, Student_UpdateReq req);
    }
}
