using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GisysArbetsprov.Models.ViewModels
{
    public class UpdateConsultantVM
    {
      
        public string FirstName { get; set; }
 
        public string LastName { get; set; }

        public int Id { get; set; }

        public DateTime DateOfEmployment { get; set; }
    }
}
