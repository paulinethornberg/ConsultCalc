using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GisysArbetsprov.Models.ViewModels
{
    public class ConsultantBonusInfoVM
    {

        public string FirstName { get; set; }

        public int? HoursWorked { get; set; }

        public string LoyaltyFactor { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfEmployment { get; set; }

        public double HoursNoted { get; set; }

        public int EmployeeCategory { get; set; }
    }
}
