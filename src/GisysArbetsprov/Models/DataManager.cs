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

        internal void SaveConsultantToDB(AddConsultantVM viewModel)
        {
            var consultant = new Consultants
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                DateOfEmployment = viewModel.DateOfEmployment
            };

            _context.Consultants.Add(consultant);
            _context.SaveChanges();

        }

        internal bool RemoveConsultantFromDB(int id)
        {
            var itemToRemove = _context.Consultants.SingleOrDefault(x => x.Id == id); //returns a single item.

            if (itemToRemove != null)
            {
                _context.Consultants.Remove(itemToRemove);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
