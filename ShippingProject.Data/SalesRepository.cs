using Newtonsoft.Json;
using SalesOrderProject.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SalesOrderProject.Data
{
    public class SalesRepository : ISalesRepository
    {

        private List<T> ReadJsonToList<T>(string fileName)
        {
            // Read the JSON file into a string
            string jsonString = File.ReadAllText(fileName);

            // Deserialize the JSON string into a list of objects
            List<T> objects = JsonConvert.DeserializeObject<List<T>>(jsonString);

            return objects;
        }
        public void SeedingToDb()
        {
            var context = new SalesDbContext();
            using (context)
            {
                foreach (var product in ReadJsonToList<Product>("C:\\Users\\User\\Desktop\\Repos\\shipingProjectDemo\\ShippingProject.Data\\JsonData\\product.json"))
                {
                    context.Add(product);
                }
                context.SaveChanges();
            }
        }



        public List<OrderDetail> FetchOrderDetails()
        {
            using var context = new SalesDbContext();
            return context.OrderDetail.ToList();
        }

        public List<Order> FetchOrder()
        {
            using var context = new SalesDbContext();
            return context.Order.ToList();

        }

        public List<Customer> FetchCustomer()
        {
            using var context = new SalesDbContext();
            return context.Customer.ToList();
        }

        public List<Address> FetchAddress()
        {
            using var context = new SalesDbContext();
            return context.Address.ToList();
        }

        public List<Product> FetchProduct()
        {
            using var context = new SalesDbContext();
            return context.Product.ToList();
        }
    }
}
