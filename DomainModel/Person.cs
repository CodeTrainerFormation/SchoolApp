using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Person")]
    public class Person
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(70)]
        [Required]
        public string LastName { get; set; }
    }
}
