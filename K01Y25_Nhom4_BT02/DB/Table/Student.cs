using System;
using System.Collections.Generic;

namespace K01Y25_Nhom4_BT02.DB.Table
{
    public partial class Student
    {
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string Lastname { get; set; } = null!;
        public string Firstmidname { get; set; } = null!;
        public DateOnly Enrollmentdate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
