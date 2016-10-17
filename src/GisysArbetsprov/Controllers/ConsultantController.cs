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


        // Logic implemented to use Authorize filter, but login view not yet finished
        //[Authorize]
        public IActionResult List()
        {
            var viewModel = dataManager.GetConsultantsFromDB();

            if (TempData["status"] != null)
            {
                ViewBag.Status = TempData["status"].ToString();
            }

            return View(viewModel);
        }

        //
        public IActionResult Calculate()
        {
            var viewModel = dataManager.GetConsultantsWithBonusInfoFromDB();

            if (TempData["status"] != null)
            {
                ViewBag.Status = TempData["status"];
            }
            return View(viewModel);
        }

        //Update consultant Info
        public IActionResult Update(UpdateConsultantVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["status"] = "Uppdateringen misslyckades, försök igen!";
                return RedirectToAction("List");
            }

            dataManager.UpdateConsultantInfoDB(viewModel);

            TempData["status"] = "Uppdateringen genomförd!";
            return RedirectToAction("List");
        }


        public IActionResult AddHoursWorked(ConsultantCalculateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["status"] = "Något gick fel.. försök igen!";
                return RedirectToAction("Calculate");
            }
            dataManager.UpdateHoursForConsultant(viewModel);

            TempData["status"] = "Uppdateringen genomförd!";
            return RedirectToAction("Calculate");
        }
            
        public IActionResult AddConsultant(AddConsultantVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["status"] = "Något gick fel.. försök igen!";
                
                return RedirectToAction("List");

            }
            dataManager.SaveConsultantToDB(viewModel);

            TempData["status"] = "Konsulten är tillagd!";
            return RedirectToAction("List");


        }

        public IActionResult DeleteConsultant(int id)
        {

            var result = dataManager.RemoveConsultantFromDB(id);
            if (result)
            {
                TempData["status"] = "Konsulten är borttagen";
                return RedirectToAction("List");
            }
            else
            {
                TempData["status"] = "Det gick inte att ta bort konsulten";
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


            TempData["status"] = "Bonus Uppdaterad";
            return RedirectToAction("Calculate");
        }
        
    }
}
