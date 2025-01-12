using K01Y25_Nhom4_BT02.DB;
using K01Y25_Nhom4_BT02.Models.Respone.Enrollment;
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
        public async Task<bool> DeleteByIdAsync(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return false;
            var enrollment = _context.Enrollments.Where(e => e.Studentid == student.Id).ToList();
            if (enrollment.Any())
                return false;
            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<Enrollment_Res?>> GetEnrollmentByCourseIdAsync(int id)
        {
            var student = _context.Students.Find(id);
            var enrollments = await _context.Enrollments
                .Where(c => c.Studentid == student.Id)
                .Select(c => new Enrollment_Res
                {
                    EnrollmentID = c.Enrollmentid,
                    CourseID = c.Courseid,
                    StudentID = c.Studentid,
                    Grade = c.Grade,
                })
                .ToListAsync();

            return enrollments;
        }
    }
}
