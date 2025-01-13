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
    }
}
