using System;
using System.Collections.Generic;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
