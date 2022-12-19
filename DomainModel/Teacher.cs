using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table(nameof(Teacher))]
    //[Table("Teacher")]
    public class Teacher : Person
    {
        [Required]
        [StringLength(30)]
        public string Discipline { get; set; }

        public int Salary { get; set; }

        public DateTime? HiringDate { get; set; }

        public int? ClassroomID { get; set; }
        public Classroom Classroom { get; set; }
    }
}
