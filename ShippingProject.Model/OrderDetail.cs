using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderProject.Model
{
    public class OrderDetail
    {
        public string id { get; set; }
        public string status { get; set; }

        public int quantity { get; set; }

        public decimal totalPrice { get; set; }

        [ForeignKey("Order")]
        public string orderId { get; set; }

        public Order order { get; set; }

        public ICollection<Product> product { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedOn { get; set; }
    }
}
