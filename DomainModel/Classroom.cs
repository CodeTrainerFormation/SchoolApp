using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DomainModel
{
    [Table("Classroom")]
    public class Classroom
    {
        public int ClassroomID { get; set; }

        [Required]
        [StringLength(30)]
        [Column("classname")]
        public string Name { get; set; }
        public int Floor { get; set; }
        public string? Corridor { get; set; }

        [JsonIgnore]
        public Teacher? Teacher { get; set; }

        [JsonIgnore]
        public ICollection<Student>? Students { get; set; }
    }
}