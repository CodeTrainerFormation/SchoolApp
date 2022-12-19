using System;
using System.Collections.Generic;

namespace DalDbFirst.Models
{
    public partial class Administrative : Person
    {
        public string? Activity { get; set; }
        public int Salary { get; set; }
    }
}
