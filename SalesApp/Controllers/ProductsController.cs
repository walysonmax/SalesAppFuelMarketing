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

    public class ProductsController : BaseController
    {
        private IRepositorySales _repository;

        public ProductsController(IRepositorySales repositorySales)
        {
            _repository = repositorySales;
        }
        public IActionResult Index()
        {
            List<ProductsViewModel> models = new List<ProductsViewModel>();

            var products = _repository.GetProducts();     


            models = products.Select(x => new ProductsViewModel
            {
                Price = x.Price,
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
            ProductsViewModel model = new ProductsViewModel();
            var customer = _repository.GetProduct(id);
            model.Id = customer.Id;
            model.Name = customer.Name;
            model.Price = customer.Price;
            return View("Include", model);
        }

        public IActionResult Save(ProductsViewModel model)
        {
            Product product = new Product();
            product.Id = model.Id;
            product.Name = model.Name;
            product.Price = model.Price;

            if (model.Id == 0)
                _repository.CreateProduct(product);
            else
                _repository.UpdateProduct(product);

            return RedirectToAction("Index");
        }
    }
}
