using System;
using System.Collections.Generic;

namespace DalDbFirst.Models
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
    }
}
