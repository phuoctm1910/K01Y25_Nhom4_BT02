namespace K01Y25_Nhom4_BT02.Models.Respone.Student
{
    public class Student_UpdateRes
    {
        public int Id { get; internal set; } // Id của sinh viên sau khi cập nhật

        public string? Lastname { get; internal set; } // Tên của sinh viên sau khi cập nhật

        public string? Firstmidname { get; internal set; } // Tên giữa của sinh viên sau khi cập nhật

        public DateTime Enrollmentdate { get; internal set; } // Ngày nhập học của sinh viên sau khi cập nhật
    }
}
