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

    public class SalesController : BaseController
    {
        private IRepositorySales _repository;

        public SalesController(IRepositorySales repositorySales)
        {
            _repository = repositorySales;
        }
        public IActionResult Index(FilterSaleViewModel filter)
        {
            List<SaleViewModel> models = new List<SaleViewModel>();

            var sales = _repository.GetSales(filter.ProductId, filter.CustomerId, filter.StartPurchaseDate, filter.EndPurchaseDate);



            models = sales?.Select(x => new SaleViewModel
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                ProductId = x.ProductId,
                CustomerName = x.CustomerName,
                ProductName = x.ProductName,
                PurchaseDate = x.Date
            }).ToList();

            return View(models);
        }

       
        public IActionResult Include()
        {
            SaleViewModel model = new SaleViewModel();
            model.Producs = _repository.GetProducts();
            model.Customers = _repository.GetCustomers();
            model.PurchaseDate = DateTime.Now;

            return View(model);
        }

        public IActionResult Alter(int id)
        {
            SaleViewModel model = new SaleViewModel();
            var customer = _repository.GetSale(id);
            model.Id = customer.Id;
            model.CustomerId = customer.CustomerId;
            model.CustomerName = customer.CustomerName;
            model.ProductName = customer.ProductName;
            model.ProductId = customer.ProductId;
            model.PurchaseDate= customer.Date;
            model.Customers = _repository.GetCustomers()?? new List<Customer>();
            model.Producs = _repository.GetProducts() ?? new List<Product>() ;
            return View("Include", model);
        }

        public IActionResult Save(SaleViewModel model)
        {
            Sale sale = new Sale();
            sale.Id = model.Id;
            sale.CustomerId = model.CustomerId;
            sale.ProductId = model.ProductId;
            sale.Date = model.PurchaseDate;

            if (model.Id == 0)
                _repository.CreateSale(sale);
            else
                _repository.UpdateSale(sale);

            return RedirectToAction("Index");
        }
    }
}
