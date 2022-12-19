using System;
using System.Collections.Generic;

namespace DalDbFirst.Models
{
    public partial class Student : Person
    {
        public double Average { get; set; }
        public bool IsClassDelegate { get; set; }

        public int ClassroomId { get; set; }

        public virtual Classroom Classroom { get; set; } = null!;
    }
}
