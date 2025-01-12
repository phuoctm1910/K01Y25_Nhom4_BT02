using System;
using System.Collections.Generic;

namespace K01Y25_Nhom4_BT02.DB.Table
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int Courseid { get; set; }
        public string Title { get; set; } = null!;
        public double Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
