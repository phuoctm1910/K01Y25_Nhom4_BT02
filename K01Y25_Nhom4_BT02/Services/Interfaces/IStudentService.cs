using K01Y25_Nhom4_BT02.Models.Request.Student;

namespace K01Y25_Nhom4_BT02.Services.Interfaces
{
    public interface IStudentService
    {
        Student_CreateReq Create(Student_CreateReq req);
    }
}
