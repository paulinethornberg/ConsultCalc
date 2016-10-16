using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GisysArbetsprov.Models.ViewModels;
using GisysArbetsprov.Models;
using GisysArbetsprov.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GisysArbetsprov.Controllers
{
    public class ConsultantController : Controller
    {
        DataManager dataManager;
        private IHostingEnvironment _environment;

        public ConsultantController(GisysDBContext context, UserManager<IdentityUser> userManager, IHostingEnvironment environment)
        {
            dataManager = new DataManager(context, userManager);
            _environment = environment;
        }

        //[Authorize]
        public IActionResult List()
        {
            var viewModel = dataManager.GetConsultantsFromDB();

            //if (TempData["status"] != null)
            //{
            //    ViewBag.Status = "Success";
            //    TempData.Remove("status");
            //    //ViewBag.Message = TempData["status"].ToString();
            //}
              
            return View(viewModel);
        }
        public IActionResult Calculate()
        {
            var viewModel = dataManager.GetConsultantsWithBonusInfoFromDB();
            return View(viewModel);
        }
        public IActionResult Update(UpdateConsultantVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                //ViewBag.Message = "Something went wrong.. Did you submit the values in the right format?";
                TempData["status"] = "Success";
                return RedirectToAction("List");
            }

            dataManager.UpdateConsultantInfoDB(viewModel);

            ViewBag.Message = "Update Succeeded";
            return RedirectToAction("List");
        }
        public IActionResult AddHoursWorked(ConsultantCalculateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Något gick fel.. Angav du timmarna i rätt format?";
                return RedirectToAction("Calculate");
            }
            dataManager.UpdateHoursForConsultant(viewModel);
            return RedirectToAction("Calculate");
        }
            
        public IActionResult AddConsultant(AddConsultantVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Something went wrong.. Did you submit the values in the right format?";
                
                return RedirectToAction("List");

            }
            dataManager.SaveConsultantToDB(viewModel);

            ViewBag.Message = "Consultant was successfully added!";
            return RedirectToAction("List");


        }

        public IActionResult DeleteConsultant(int id)
        {
            var result = dataManager.RemoveConsultantFromDB(id);
            if (result)
            {
                ViewBag.Message = "Consultant successfully deleted";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Message = "OUuupps something went wrong";
                return RedirectToAction("List");
            }

        }
        public IActionResult GetConsultantInfo(int id)
        {
            var viewModel = dataManager.GetSingleConsultantInfo(id);
            return View(viewModel);
        }

        public IActionResult CalculateBonus(ConsultantCalculateVM viewModel)
        {
            dataManager.CalculateBonusAndAddToDB(viewModel);


            ViewBag.Message = "Bonus Updates";
            return RedirectToAction("Calculate");
        }
        
    }
}
