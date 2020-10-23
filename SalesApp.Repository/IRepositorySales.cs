using SalesApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Repository
{
    public interface IRepositorySales
    {
        #region Customers
        public int CreateCustomer(Customer customer);

        public int UpdateCustomer(Customer customer);

        public int DeleteCustomer(int id);

        public Customer GetCustomer(int id);

        public List<Customer> GetCustomers();
        #endregion

        #region Products
        public int CreateProduct(Product customer);

        public int UpdateProduct(Product customer);

        public int DeleteProduct(int id);

        public Product GetProduct(int id);

        public List<Product> GetProducts();
        #endregion

        #region Sales
        public int CreateSale(Sale sale);

        public int UpdateSale(Sale sale);

        public int DeleteSale(int id);

        public Sale GetSale(int id);

        public List<Sale> GetSales(int productId,int customerId,DateTime? fromDate, DateTime? toDate);
        #endregion

        #region login

        public void Register(string username, string password, string name, Profile profile);
        public User GetUser(string username, string password);

        #endregion

        #region Dashboard
        public Dashboard GetDashBoard();
        #endregion
    }
}
