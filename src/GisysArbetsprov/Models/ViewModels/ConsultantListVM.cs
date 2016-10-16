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
        public string DateOfEmployement { get; set; }

        public string Message { get; set; }
    }
}
