using K01Y25_Nhom4_BT02.DB;
using K01Y25_Nhom4_BT02.Models.Respone;
using K01Y25_Nhom4_BT02.Services.Interfaces;
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

    }
}
