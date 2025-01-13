namespace K01Y25_Nhom4_BT02.Models.Respone.Student
{
    public class Student_CreateRes
    {
        public int Id { get; internal set; }
        public string? Lastname { get; internal set; }

        public string? Firstmidname { get; internal set; }

        public DateTime Enrollmentdate { get; internal set; }
    }
}
