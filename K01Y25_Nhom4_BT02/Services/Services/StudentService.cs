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

        // Hàm Update
        public Student_UpdateReq Update(int id, Student_UpdateReq req)
        {
            try
            {
                // Tìm sinh viên theo ID
                var student = _context.Students.FirstOrDefault(s => s.Id == id);

                if (student == null)
                {
                    return null; // Sinh viên không tìm thấy
                }

                // Cập nhật thông tin sinh viên
                student.Lastname = req.Lastname;
                student.Firstmidname = req.Firstmidname;
                student.Enrollmentdate = (DateTime)req.Enrollmentdate;

                // Lưu lại thay đổi
                _context.SaveChanges();

                // Trả về đối tượng Student_UpdateReq sau khi đã cập nhật thành công
                return req;
            }
            catch
            {
                return null; // Xử lý lỗi nếu có
            }
        }

        private object Student()
        {
            throw new NotImplementedException();
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
