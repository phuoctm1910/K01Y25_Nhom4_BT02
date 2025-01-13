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

    }
}
