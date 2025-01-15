using System.Diagnostics;
using K01Y25_Nhom4_BT02.DB;
using K01Y25_Nhom4_BT02.DB.Table;
using K01Y25_Nhom4_BT02.Models.Request.Enrollment;
using K01Y25_Nhom4_BT02.Models.Respone.Enrollment;
using K01Y25_Nhom4_BT02.Services.Interfaces;

namespace K01Y25_Nhom4_BT02.Services.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDbContext _context;

        public EnrollmentService(AppDbContext context)
        {
            _context = context;
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

        public Enrollment_UpdateRes Update(int id, Enrollment_UpdateReq req)
        {
            try
            {
                // Tìm bản ghi Enrollment dựa trên id
                var enrollment = _context.Enrollments.FirstOrDefault(e => e.Enrollmentid == id);

                if (enrollment == null)
                {
                    return null; // Trả về null nếu không tìm thấy
                }

                // Cập nhật các trường dữ liệu
                enrollment.Courseid = req.Courseid;
                enrollment.Studentid = req.Studentid;
                enrollment.Grade = (decimal)req.Grade;

                // Lưu thay đổi vào cơ sở dữ liệu
                _context.SaveChanges();

                // Trả về kết quả cập nhật
                return new Enrollment_UpdateRes
                {
                    EnrollmentID = enrollment.Enrollmentid,
                    CourseID = enrollment.Courseid,
                    StudentID = enrollment.Studentid,
                    Grade = (float)enrollment.Grade
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error updating enrollment: {ex.Message}");
                return null; // Trả về null nếu có lỗi
            }
        }

    }
}
