using Dapper;
using Microsoft.Extensions.Configuration;
using SalesApp.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace SalesApp.Repository
{
    public class RepositorySales : IRepositorySales
    {
        IConfiguration _configuration;
        private string _connection;

        public RepositorySales(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }

        #region Customer
        public int CreateCustomer(Customer customer)
        {
            var count = 0;
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO Customers(Name, Email) VALUES(@Name, @Email); 
                                SELECT CAST(SCOPE_IDENTITY() as INT);";
                    count = con.Execute(query, customer);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        public int UpdateCustomer(Customer customer)
        {
            var count = 0;
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    var query = @"UPDATE Customers SET Name = @Name, Email = @Email 
                        WHERE Id = " + customer.Id;
                    count = con.Execute(query, customer);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        public int DeleteCustomer(int id)
        {
            var count = 0;
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    var query = @"DELETE FROM Customers WHERE Id = " + id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        public Customer GetCustomer(int id)
        {

            Customer customer = new Customer();
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Customers WHERE Id =" + id;
                    customer = con.Query<Customer>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return customer;
            }
        }
        public List<Customer> GetCustomers()
        {

            List<Customer> customers = new List<Customer>();
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Customers";
                    customers = con.Query<Customer>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return customers;
            }
        }

        #endregion


        #region Products
        public int CreateProduct(Product product)
        {
            var count = 0;
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO Products(Name, Price) VALUES(@Name, @Price); 
                                SELECT CAST(SCOPE_IDENTITY() as INT);";
                    count = con.Execute(query, product);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        public int UpdateProduct(Product product)
        {
            var count = 0;
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    var query = @"UPDATE Products SET Name = @Name, Price = @Price 
                        WHERE Id = " + product.Id;
                    count = con.Execute(query, product);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        public int DeleteProduct(int id)
        {
            var count = 0;
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    var query = @"DELETE FROM Products WHERE Id = " + id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        public Product GetProduct(int id)
        {
            Product product = new Product();
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Products WHERE Id =" + id;
                    product = con.Query<Product>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return product;
            }
        }
        public List<Product> GetProducts()
        {

            List<Product> products = new List<Product>();
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Products";
                    products = con.Query<Product>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return products;
            }
        }

        #endregion


        #region Sale


        public int CreateSale(Sale sale)
        {
            sale.Date = DateTime.Now;
            var count = 0;
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO Sales(CustomerId, ProductId, Date) VALUES(@CustomerId, @ProductId, @Date); 
                                SELECT CAST(SCOPE_IDENTITY() as INT);";
                    count = con.Execute(query, sale);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int UpdateSale(Sale sale)
        {
            var count = 0;
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();

                    var query = @"UPDATE Sales SET CustomerId = @CustomerId, ProductId = @ProductId ,Date= @Date
                        WHERE Id = " + sale.Id;
                    count = con.Execute(query, sale);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int DeleteSale(int id)
        {
            var count = 0;
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    var query = @"DELETE FROM Sales WHERE Id = " + id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public Sale GetSale(int id)
        {
            Sale sale = new Sale();
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Sales WHERE Id =" + id;
                    sale = con.Query<Sale>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return sale;
            }
        }

        public List<Sale> GetSales(int productId, int customerId, DateTime? fromDate, DateTime? toDate)
        {


            List<Sale> sales = new List<Sale>();
            var procedure = "SearchSales";
            using (var con = new SqlConnection(_connection))
            {
                try
                {

                    con.Open();
                    var values = new { Customer = customerId, Product = productId, StartDate = ConvertDateFormatSql(fromDate), EndDate = ConvertDateFormatSql(toDate) };
                    sales = con.Query<Sale>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return sales;
            }
        }


        public string ConvertDateFormatSql(DateTime? date)
        {
            string dateFormat = "";
            if (date.HasValue)
            {
                dateFormat = date.Value.ToString("yyyy-MM-dd");
            }
            return dateFormat;

        }


        #endregion

        #region login
        public void Register(string username, string password, string name, Profile profile)
        {
            using (var con = new SqlConnection(_connection))
            {

                con.Open();
                try
                {

                    var query = @"INSERT INTO [dbo].[User] (Username, Profile, Password,Name) VALUES(@Username, @Profile, @Password, @Name); 
                                SELECT CAST(SCOPE_IDENTITY() as INT);";
                    con.Execute(query, new { Username = username, Password = password, Profile = (int)profile , Name = name});

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public User GetUser(string username, string password)
        {
            User user = null;
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM [dbo].[User] WHERE Username ='" + username + "' and Password ='" + password + "'";
                    user = con.Query<User>(query)?.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return user;
            }
        }


        #endregion


        public Dashboard GetDashBoard()
        {
            Dashboard dashboard = new Dashboard();
            var procedure = "PROC_Dashboard";
            using (var con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    dashboard = con.Query<Dashboard>(procedure, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return dashboard;
            }
        }
    }
}
