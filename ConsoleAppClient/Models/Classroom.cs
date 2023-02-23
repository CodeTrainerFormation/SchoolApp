using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClient.Models
{
    public class Classroom
    {
        public int ClassroomID { get; set; }

        public string Name { get; set; }

        public int Floor { get; set; }

        public string? Corridor { get; set; }
    }
}
