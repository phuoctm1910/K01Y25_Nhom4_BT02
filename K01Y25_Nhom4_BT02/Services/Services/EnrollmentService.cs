using K01Y25_Nhom4_BT02.DB;
using K01Y25_Nhom4_BT02.Models.Respone.Course;
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

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var enrollment = _context.Enrollments.Find(id);
            if (enrollment == null)
                return false;
            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
            return true;

        }
    }
}
