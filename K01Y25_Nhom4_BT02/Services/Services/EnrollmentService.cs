using K01Y25_Nhom4_BT02.DB;
using K01Y25_Nhom4_BT02.Models.Respone;
using K01Y25_Nhom4_BT02.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using K01Y25_Nhom4_BT02.DB.Table;
using K01Y25_Nhom4_BT02.Models.Request.Enrollment;

namespace K01Y25_Nhom4_BT02.Services.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDbContext _context;

        public EnrollmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enrollment_Res>> GetAllAsync()
        {
            var Enrollments = await _context.Enrollments
                .Select(c => new Enrollment_Res
                {
                    Enrollmentid = c.Enrollmentid,
                    Courseid = c.Courseid,
                    Studentid = c.Studentid,
                    Grade = c.Grade
                })
                .ToListAsync();

            return Enrollments;
        }

        public async Task<Enrollment_Res?> GetByIdAsync(int id)
        {
            // Tìm khóa học theo ID
            var Enrollment = await _context.Enrollments
                .Where(c => c.Enrollmentid == id)
                .Select(c => new Enrollment_Res
                {
                    Enrollmentid = c.Enrollmentid,
                    Studentid = c.Studentid,
                    Courseid = c.Courseid,
                    Grade = c.Grade,
                })
                .FirstOrDefaultAsync();

            return Enrollment;
        }

        public object Enrollments { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Enrollment_CreateReq Create(Enrollment_CreateReq req)
        {
            try
            {
                if (req == null) { return null; }
                var newEnrollment = new Enrollment()
                {
                    Courseid = req.Courseid,
                    Studentid = req.Studentid,
                    Grade = (decimal)req.Grade
                };
                _context.Enrollments.Add(newEnrollment);
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
