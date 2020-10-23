using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesApp.Models;
using SalesApp.Repository;

namespace SalesApp.Controllers
{
    public class LoginController : BaseController
    {

        private IRepositorySales _repository;

        public LoginController(IRepositorySales repositorySales)
        {
            _repository = repositorySales;
        }
        //[HttpGet]
        public IActionResult Index()
        {
            SetUserSession(null);
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            _repository.Register(model.UserName, model.Password, model.Name, model.Profile);
            return View("Index");
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var user = _repository.GetUser(Username, Password);
            if (user != null)
            {
                SetUserSession(user);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid Username or Password!";

            return View("Index");

        }


    }
}
