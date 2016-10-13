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
        internal ConsultantCalculateVM GetConsultantsWithBonusInfoFromDB()
        {
            var viewModel = new ConsultantCalculateVM();

            var listOfConsultants = _context.Consultants
               .Select(c => new ConsultantBonusInfoVM
               {
                   DateOfEmployment = c.DateOfEmployment,
                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   HoursWorked = null,
                   EmployeeCategory = CalculateYearsOfEmployment(c.DateOfEmployment),
                   EmployeeId = c.Id,
                   LoyaltyFactor = GenerateLoyaltyFactor(c.DateOfEmployment)
               })
               .ToArray();

            viewModel.ConsultantList = listOfConsultants;
            return viewModel;
        }

        private double GenerateLoyaltyFactor(DateTime dateofEmployment)
        {
            var yearsOfemployment = CalculateYearsOfEmployment(dateofEmployment);
            
            switch (yearsOfemployment)
            {
                case 0:
                    return 1;
                case 1:
                    return 1.1;
                case 2:
                    return 1.2;
                case 3:
                    return 1.3;
                case 4:
                    return 1.4;
                default:
                    return 1.5;            
             }
        }

        private int CalculateYearsOfEmployment(DateTime dateOfEmployment)
        {
     
            decimal tempYears = new decimal();
             int days = (DateTime.Today - dateOfEmployment).Days;

            tempYears = days / 365;
            int years = Convert.ToInt32(Math.Round(tempYears));
         
            return years;
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

        internal AddConsultantVM GetSingleConsultantInfo(int id)
        {
            return _context.Consultants
                .Where(x => x.Id == id)
                .Select(c => new AddConsultantVM
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    DateOfEmployment = c.DateOfEmployment
                }).FirstOrDefault();
        }
    }
}
