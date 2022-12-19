using System;
using System.Collections.Generic;

namespace DalDbFirst.Models
{
    public partial class Teacher : Person
    {
        public string Discipline { get; set; } = null!;
        public int Salary { get; set; }
        public DateTime? HiringDate { get; set; }


        public int? ClassroomId { get; set; }
        public virtual Classroom? Classroom { get; set; }
    }
}
