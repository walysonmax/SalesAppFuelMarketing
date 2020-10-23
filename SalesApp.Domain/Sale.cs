using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Domain
{
    public class Sale
    {
        public int Id { get; set; }

        public string  CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }

        public DateTime Date{ get; set; }

    }
}
