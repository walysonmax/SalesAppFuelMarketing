using SalesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{
    public class SaleViewModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }


        public DateTime PurchaseDate { get; set; }

        public List<Customer> Customers { get; set; }
        public List<Product> Producs { get; set; }
    }
}
