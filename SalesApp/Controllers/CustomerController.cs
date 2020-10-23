using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesApp.Domain;
using SalesApp.Filters;
using SalesApp.Models;
using SalesApp.Repository;

namespace SalesApp.Controllers
{
    [ServiceFilter(typeof(ActionFilter))]
    public class CustomerController : BaseController
    {

        private IRepositorySales _repository;

        public CustomerController(IRepositorySales repositorySales)
        {
            _repository = repositorySales;
        }
        //[HttpGet]
 
      
        public IActionResult Index(FilterCustomerViewModel filter)
        {
            List<CustomerViewModel> models = new List<CustomerViewModel>();

            var customers = _repository.GetCustomers();

            if (!string.IsNullOrEmpty(filter.Name))
                customers = customers.Where(x => x.Name == filter.Name).ToList();

            if (!string.IsNullOrEmpty(filter.Email))
                customers = customers.Where(x => x.Email == filter.Email).ToList();


            models = customers.Select(x => new CustomerViewModel
            {
                Email = x.Email,
                Name = x.Name,
                Id = x.Id
            }).ToList();

            return View(models);
        }

        public IActionResult Include()
        {
            return View();
        }

        public IActionResult Alter(int id)
        {
            CustomerViewModel model = new CustomerViewModel();
            var customer =  _repository.GetCustomer(id);
            model.Id = customer.Id;
            model.Name = customer.Name;
            model.Email = customer.Email;
            return View("Include", model);
        }

        public IActionResult Save(CustomerViewModel model)
        {         
            
            
            Customer customer = new Customer();
            customer.Id = model.Id;
            customer.Name = model.Name;
            customer.Email = model.Email;

            if (model.Id == 0)
                _repository.CreateCustomer(customer);
            else
                _repository.UpdateCustomer(customer);

            return RedirectToAction("Index");
        }
    }
}
