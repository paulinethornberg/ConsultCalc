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
        // GET: /<controller>/
        public IActionResult List()
        {
            // GET DATA FROM DB - WITH EF - GET ALL CONSULTANTS :) 
            var viewModel = dataManager.GetConsultantsFromDB();

            return View(viewModel);
        }
        public IActionResult Calculate()
        {
            var viewModel = dataManager.GetConsultantsWithBonusInfoFromDB();
            return View(viewModel);
        }

        public IActionResult AddConsultant(AddConsultantVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                //ViewBag.Message = "Something went wrong.. Did you submit the values in the right format? ";
                ViewBag.Message = "Something went wrong.. Did you submit the values in the right format?";
                return RedirectToAction("List");

            }
            dataManager.SaveConsultantToDB(viewModel);

            ViewBag.Message = "Consultant was successfully added!";
            return RedirectToAction("List");


            // Lägg till View(_partialView) :) 
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
            var viewModel = new AddConsultantVM();
            viewModel = dataManager.GetSingleConsultantInfo(id);
            return View(viewModel);
        }

      
    }
}
