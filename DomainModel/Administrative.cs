using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table(nameof(Administrative))]
    public class Administrative : Person
    {
        public string Activity { get; set; }
        public int Salary { get; set; }
    }
}
