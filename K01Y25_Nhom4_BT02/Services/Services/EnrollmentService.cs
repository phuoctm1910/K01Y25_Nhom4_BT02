using System.Diagnostics;
using K01Y25_Nhom4_BT02.DB;
using K01Y25_Nhom4_BT02.DB.Table;
using K01Y25_Nhom4_BT02.Models.Request.Enrollment;
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
    }
}
