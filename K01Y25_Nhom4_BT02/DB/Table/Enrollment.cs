﻿using System;
using System.Collections.Generic;

namespace K01Y25_Nhom4_BT02.DB.Table
{
    public partial class Enrollment
    {
        public int Enrollmentid { get; set; }
        public int Courseid { get; set; }
        public int Studentid { get; set; }
        public decimal Grade { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
