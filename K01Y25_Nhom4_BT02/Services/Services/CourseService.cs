using K01Y25_Nhom4_BT02.DB;
using K01Y25_Nhom4_BT02.DB.Table;
using K01Y25_Nhom4_BT02.Models.Request.Course;
using K01Y25_Nhom4_BT02.Models.Respone;
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

        public Course_CreateReq Create(Course_CreateReq request)
        {
            try
            {
                if (request == null) { return null; }
                // Tạo đối tượng Course từ request
                var newCourse = new Course()
                {
                    Title = request.Title,
                    Credits = request.Credits
                };
                _context.Courses.Add(newCourse);
                _context.SaveChanges();
                return request;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Course_Res>> GetAllAsync()
        {
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

        public Course_Res Update(int id, Course_UpdateReq req)
        {
            try
            {
                // Tìm khóa học cần cập nhật
                var course = _context.Courses.FirstOrDefault(c => c.Courseid == id);

                if (course == null)
                {
                    return null; // Không tìm thấy khóa học
                }

                // Cập nhật thông tin khóa học
                course.Title = req.Title;
                course.Credits = req.Credits;

                // Lưu thay đổi vào cơ sở dữ liệu
                _context.SaveChanges();

                // Trả về kết quả cập nhật
                return new Course_Res
                {
                    Courseid = course.Courseid,
                    Title = course.Title,
                    Credits = course.Credits
                };
            }
            catch
            {
                return null; // Xử lý lỗi nếu có
            }
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
                    Enrollmentid = c.Enrollmentid,
                    Courseid = c.Courseid,
                    Studentid = c.Studentid,
                    Grade = c.Grade,
                })
                .ToListAsync();

            return enrollments;
        }
    }
}
