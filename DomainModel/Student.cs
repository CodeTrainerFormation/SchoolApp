using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Student")]
    public class Student : Person
    {
        [Range(0, 20)]
        public double Average { get; set; }

        public bool IsClassDelegate { get; set; }

        public int ClassroomID { get; set; }

        [JsonIgnore]
        public Classroom Classroom { get; set; }
    }
}
