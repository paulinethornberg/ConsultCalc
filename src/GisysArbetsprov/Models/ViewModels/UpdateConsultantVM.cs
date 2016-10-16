using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GisysArbetsprov.Models.ViewModels
{
    public class UpdateConsultantVM
    {

        [Required(ErrorMessage = "Ange förnamn")]
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ange efternamn")]
        [StringLength(30, MinimumLength = 2)]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Ange anställningsdatum")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfEmployment { get; set; }

        public int Id { get; set; }
        public int EmployeeCategory { get; set; }
    }
}
