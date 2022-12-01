using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Teacher : Person
    {
        public string Discipline { get; set; }
        public int Salary { get; set; }

        public int? ClassroomID { get; set; }
        public Classroom Classroom { get; set; }
    }
}
