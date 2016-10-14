using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GisysArbetsprov.Models.ViewModels
{
    public class ConsultantCalculateVM
    {
        //public ConsultantBonusInfoVM[] ConsultantList { get; set; }

        public int Performace { get; set; }
        public double Bonus { get; set; }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public int? HoursWorked { get; set; }

        public double LoyaltyFactor { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfEmployment { get; set; }

        public double  PerformancePoints { get; set; }
        public int EmployeeCategory { get; set; }

    }
}
