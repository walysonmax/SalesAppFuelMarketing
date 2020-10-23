using Microsoft.AspNetCore.Mvc;
using SalesApp.Models;
using SalesApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Views.Shared.Components.FilterSale
{
    public class FilterSale : ViewComponent
    {
        private IRepositorySales _repository;

        public FilterSale(IRepositorySales repositorySales)
        {
            _repository = repositorySales;
        }
        public IViewComponentResult Invoke()
        {
            FilterSaleViewModel filter = new FilterSaleViewModel();
            filter.Producs = _repository.GetProducts()?? new List<Domain.Product>();
            filter.Customers = _repository.GetCustomers()?? new List<Domain.Customer>();
            return View(filter);
        }
    }
}
