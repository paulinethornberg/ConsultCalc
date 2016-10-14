﻿using System;
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

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfEmployment { get; set; }


        public int EmployeeCategory { get; set; }
    }
}
