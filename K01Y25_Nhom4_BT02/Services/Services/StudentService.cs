using K01Y25_Nhom4_BT02.DB;
using K01Y25_Nhom4_BT02.DB.Table;
using K01Y25_Nhom4_BT02.Models.Request.Student;
using K01Y25_Nhom4_BT02.Services.Interfaces;
namespace K01Y25_Nhom4_BT02.Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public Student_CreateReq Create(Student_CreateReq req)
        {
            try
            {
                if(req == null) { return null; }

                var newStudent = new Student()
                {
                    Lastname = req.Lastname,
                    Firstmidname = req.Firstmidname,
                    Enrollmentdate = req.Enrollmentdate
                };
                _context.Students.Add(newStudent);
                _context.SaveChanges();
                return req;
            }
            catch
            {
                return null;
            }
        }

        private object Student()
        {
            throw new NotImplementedException();
        }
    }
}
