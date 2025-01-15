namespace K01Y25_Nhom4_BT02.Models.Request.Student
{
    public class Student_UpdateReq
    {
        public string? Lastname { get; set; } // Tên có thể được cập nhật

        public string? Firstmidname { get; set; } // Tên giữa có thể được cập nhật

        public DateTime? Enrollmentdate { get; set; } // Ngày nhập học có thể được cập nhật (nullable)
    }
}
