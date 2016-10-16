using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GisysArbetsprov.Models.ViewModels
{
    public class ConsultantCalculateVM
    {
        public int Performace { get; set; }
        public double Bonus { get; set; }

        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        [Range(0, 9000, ErrorMessage ="Debiterade timmar kan inte överstiga 9000" )]
        public int? HoursWorked { get; set; }

        public double LoyaltyFactor { get; set; }
        public string LastName { get; set; }

        public string DateOfEmployment { get; set; }

        public double  PerformancePoints { get; set; }
        public int EmployeeCategory { get; set; }

    }
}
