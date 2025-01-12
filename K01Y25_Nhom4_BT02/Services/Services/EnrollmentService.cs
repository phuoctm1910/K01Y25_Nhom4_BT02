using K01Y25_Nhom4_BT02.DB;
using K01Y25_Nhom4_BT02.Models.Respone;
using K01Y25_Nhom4_BT02.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace K01Y25_Nhom4_BT02.Services.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDbContext _context;

        public EnrollmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Enrollment_Res?> GetByIdAsync(int id)
        {
            // Tìm khóa học theo ID
            var enrollment = await _context.Enrollments
                .Where(e => e.Enrollmentid == id)
                .Select(e => new Enrollment_Res
                {
                    Enrollmentid = e.Enrollmentid,
                    Courseid = e.Courseid,
                    Studentid = e.Studentid,
                    Grade = e.Grade
                })
                .FirstOrDefaultAsync();

            return enrollment;
        }

    }
}
