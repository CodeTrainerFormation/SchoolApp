using System;
using System.Collections.Generic;

namespace DalDbFirst.Models
{
    public partial class Classroom
    {
        public Classroom()
        {
            Students = new HashSet<Student>();
        }

        public int ClassroomId { get; set; }
        public string Classname { get; set; } = null!;
        public int Floor { get; set; }
        public string? Corridor { get; set; }

        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
