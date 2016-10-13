using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GisysArbetsprov.Models.ViewModels
{
    public class ConsultantListVM
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfEmployement { get; set; }
        public double HoursNoted { get; set; }

        public int EmployeeCategory { get; set; }
    }
}
