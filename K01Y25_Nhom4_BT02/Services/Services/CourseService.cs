﻿using K01Y25_Nhom4_BT02.DB;
using K01Y25_Nhom4_BT02.Models.Respone.Course;
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
    }
}
