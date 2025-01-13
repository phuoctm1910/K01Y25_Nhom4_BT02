﻿using K01Y25_Nhom4_BT02.Models.Respone;

using K01Y25_Nhom4_BT02.Models.Request.Student;

namespace K01Y25_Nhom4_BT02.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Student_Res?> GetByIdAsync(int id);

        Task<IEnumerable<Student_Res>> GetAllAsync();
        Student_CreateReq Create(Student_CreateReq req);
    }
}
