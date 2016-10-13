using System;
using System.Collections.Generic;

namespace GisysArbetsprov.Models.Entities
{
    public partial class Consultants
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public int HoursWorked { get; set; }
    }
}
