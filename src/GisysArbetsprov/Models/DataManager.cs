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
                    DateOfEmployement = GetDateRightFormat(c.DateOfEmployment)
                })
                .ToArray();
        }

        private string GetDateRightFormat(DateTime dateOfEmployment)
        {
            var tmpString = dateOfEmployment.ToString();
            return tmpString.Substring(0, 10);
        }

        internal ConsultantCalculateVM[] GetConsultantsWithBonusInfoFromDB()
        {
            return _context.Consultants
               .Select(c => new ConsultantCalculateVM
               {
                   DateOfEmployment = GetDateRightFormat(c.DateOfEmployment),
                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   HoursWorked = c.HoursWorked,
                   EmployeeCategory = CalculateYearsOfEmployment(c.DateOfEmployment),
                   Id = c.Id,
                   LoyaltyFactor = GenerateLoyaltyFactor(c.DateOfEmployment),
                   Bonus = Math.Round(Convert.ToDouble(c.Bonus))
               })
               .ToArray();

        }

        internal void UpdateConsultantInfoDB(UpdateConsultantVM viewModel)
        {
            var consultant = (from x in _context.Consultants
                              where x.Id == viewModel.Id
                              select x).First();
            consultant.FirstName = viewModel.FirstName;
            consultant.LastName = viewModel.LastName;
            consultant.DateOfEmployment = viewModel.DateOfEmployment;
            _context.SaveChanges();
        }

        internal void UpdateHoursForConsultant(ConsultantCalculateVM viewModel)
        {
            var consultant = (from x in _context.Consultants
                              where x.Id == viewModel.Id
                              select x).First();
            consultant.HoursWorked = viewModel.HoursWorked;
            _context.SaveChanges();
        }

        private double GenerateLoyaltyFactor(DateTime dateofEmployment)
        {
            var yearsOfemployment = CalculateYearsOfEmployment(dateofEmployment);

            if (yearsOfemployment < 0)
                return 1;

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

            // If consultant haven't started, years will be 0 (not negative)
            if (years < 0)
                return 0;
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

        internal void CalculateBonusAndAddToDB(ConsultantCalculateVM viewModel)
        {
            //get the 5% of the performance
            double bonusBase = 0.05 * viewModel.Performace;

            // get list of all consultants
            var consultants = GetConsultantsWithBonusInfoFromDB();
        
            //logic to calculate the individual points and add to total
            double totalPointsHoursCharged = new double();

            foreach (var consulant in consultants)
            {
                var pointsHoursCharged = consulant.LoyaltyFactor * Convert.ToDouble(consulant.HoursWorked);
                totalPointsHoursCharged += pointsHoursCharged;
                consulant.PerformancePoints = pointsHoursCharged;
            }

            
            foreach (var consultant in consultants)
            {
                consultant.Bonus = (consultant.PerformancePoints / totalPointsHoursCharged)*bonusBase;
            }

            // Save bonus to DB - use ID to save to right consultant
            foreach (var consultant in consultants)
            {
                var t = (from x in _context.Consultants
                         where x.Id == consultant.Id
                         select x).First();
                t.Bonus = consultant.Bonus;
                _context.SaveChanges();
            }
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

        internal bool RemoveConsultantFromDB(int id)
        {
            var itemToRemove = _context.Consultants.SingleOrDefault(x => x.Id == id);
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
