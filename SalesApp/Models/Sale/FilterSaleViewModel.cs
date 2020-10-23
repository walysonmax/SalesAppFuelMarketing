using SalesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{
    public class FilterSaleViewModel
    {

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public List<Customer> Customers { get; set; }
        public List<Product> Producs { get; set; }

        public DateTime? StartPurchaseDate { get; set; }
        public DateTime? EndPurchaseDate { get; set; }
    }
}
