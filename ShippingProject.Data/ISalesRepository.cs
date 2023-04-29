using Newtonsoft.Json;
using SalesOrderProject.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace SalesOrderProject.Data
{
    public interface ISalesRepository
    {
        public void SeedingToDb();

        public List<OrderDetail> FetchOrderDetails();

        public List<Order> FetchOrder();

        public List<Customer> FetchCustomer();

        public List<Product> FetchProduct();

        public List<Address> FetchAddress();

    }
}
