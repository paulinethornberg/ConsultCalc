using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GisysArbetsprov.Models.ViewModels
{
    public class AddConsultantVM
    {
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }

        public DateTime DateOfEmployment { get; set; }

        public double HoursNoted { get; set; }

        public int EmployeeCategory { get; set; }
    }
}
