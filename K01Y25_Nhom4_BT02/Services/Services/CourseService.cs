using K01Y25_Nhom4_BT02.DB;
using K01Y25_Nhom4_BT02.DB.Table;
using K01Y25_Nhom4_BT02.Models.Respone.Course;
using K01Y25_Nhom4_BT02.Models.Respone.Enrollment;
using K01Y25_Nhom4_BT02.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace K01Y25_Nhom4_BT02.Services.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Course_Res>> GetAllAsync()
        {
            // Truy vấn danh sách khóa học từ DB và ánh xạ sang `Course_Res`
            var courses = await _context.Courses
                .Select(c => new Course_Res
                {
                    Courseid = c.Courseid,
                    Title = c.Title,
                    Credits = c.Credits
                })
                .ToListAsync();

            return courses;
        }

        public async Task<Course_Res?> GetByIdAsync(int id)
        {
            // Tìm khóa học theo ID
            var course = await _context.Courses
                .Where(c => c.Courseid == id)
                .Select(c => new Course_Res
                {
                    Courseid = c.Courseid,
                    Title = c.Title,
                    Credits = c.Credits
                })
                .FirstOrDefaultAsync();

            return course;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
                return false;
            var enrollment = _context.Enrollments.Where(e => e.Courseid == course.Courseid).ToList();
            if (enrollment.Any())
                return false;
            _context.Courses.Remove(course);
            _context.SaveChanges(); 
            return true; 
        }

        public async Task<List<Enrollment_Res?>> GetEnrollmentByCourseIdAsync(int id)
        {
            var course = _context.Courses.Find(id);
            var enrollments = await _context.Enrollments
                .Where(c => c.Courseid == course.Courseid)
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
