using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesApp.Domain;
using SalesApp.Filters;
using SalesApp.Models;
using SalesApp.Repository;

namespace SalesApp.Controllers
{
    [ServiceFilter(typeof(ActionFilter))]

    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        private IRepositorySales _repository;

    
        public HomeController(ILogger<HomeController> logger, IRepositorySales repositorySales)
        {
            _logger = logger;
            _repository = repositorySales;

        }

        public IActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();
            Dashboard dashboard = _repository.GetDashBoard();
            model.TotalUsers = dashboard.TotalUsers;
            model.TotalSales = dashboard.TotalSales;
            model.TotalProducts = dashboard.TotalProducts;
            model.TotalCustomers = dashboard.TotalCustomers;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
