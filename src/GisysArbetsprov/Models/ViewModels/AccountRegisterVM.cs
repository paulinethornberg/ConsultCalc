using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GisysArbetsprov.Models.ViewModels
{
    public class AccountRegisterVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
 
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Ange en giltig emailadress")]
        public string Email { get; set; }
    }
}
