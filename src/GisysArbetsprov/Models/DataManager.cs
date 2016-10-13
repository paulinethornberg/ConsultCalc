using GisysArbetsprov.Models.Entities;
using GisysArbetsprov.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GisysArbetsprov.Models
{
    public class DataManager
    {
        GisysDBContext _context;
        UserManager<IdentityUser> _userManager;

        public DataManager(GisysDBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        internal ConsultantListVM[] GetConsultantsFromDB()
        {
            return _context.Consultants
                .Select(c => new ConsultantListVM
                {
                    EmployeeId = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    DateOfEmployement = c.DateOfEmployment
                })
                .ToArray();

        }
    }
}
