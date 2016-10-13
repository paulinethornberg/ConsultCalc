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
            return View();
        }
    }
}
