using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GisysArbetsprov.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GisysArbetsprov.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GisysArbetsprov.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        IdentityDbContext _identityContext;

        DataManager dataManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IdentityDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityContext = dbContext;
            //_context = context;
        }


        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _identityContext.Database.EnsureCreatedAsync();

            var user = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("UserName", result.Errors.First().Description);
                return View(model);
            }

            await _signInManager.PasswordSignInAsync(model.UserName, model.Password,
                false, false);

            return RedirectToAction(nameof(HomeController.Index), "home");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<bool> Login(AccountLoginVM viewModel)
        {
            if (!ModelState.IsValid)
                return false;

            var result = await _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);
            return result.Succeeded;
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public bool CheckIsLoggedIn()
        {
            bool isLogged = User.Identity.IsAuthenticated;
            return isLogged;
        }

    }
}
