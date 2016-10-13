using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GisysArbetsprov.Models.ViewModels
{
    public class ConsultantBonusInfoVM
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public int? HoursWorked { get; set; }

        public double LoyaltyFactor { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfEmployment { get; set; }


        public int EmployeeCategory { get; set; }
    }
}
