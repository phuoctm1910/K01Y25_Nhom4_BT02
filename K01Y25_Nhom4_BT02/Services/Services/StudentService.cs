using K01Y25_Nhom4_BT02.DB;
using K01Y25_Nhom4_BT02.DB.Table;
using K01Y25_Nhom4_BT02.Models.Request.Student;
using K01Y25_Nhom4_BT02.Services.Interfaces;
using K01Y25_Nhom4_BT02.Models.Respone;
using Microsoft.EntityFrameworkCore;

namespace K01Y25_Nhom4_BT02.Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student_Res>> GetAllAsync()
        {
            var student = await _context.Students
                .Select(c => new Student_Res
                {
                    Id = c.Id,
                    Lastname = c.Lastname,
                    Firstmidname = c.Firstmidname
                })
                .ToListAsync();

            return student;
        }
        public async Task<Student_Res?> GetByIdAsync(int id)
        {
            // Tìm khóa học theo ID
            var student = await _context.Students
                .Where(s => s.Id == id)
                .Select(s => new Student_Res
                {
                    Id = s.Id,
                    Lastname = s.Lastname,
                    Firstmidname = s.Firstmidname,
                    Enrollmentdate = s.Enrollmentdate
                })
                .FirstOrDefaultAsync();

            return student;
        }
        public Student_CreateReq Create(Student_CreateReq req)
        {
            try
            {
                if (req == null) { return null; }

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
    }
}
