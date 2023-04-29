using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderProject.Model
{
    public class Product
    {
        public string id { get; set; }
        public string productName { get; set; }
        public string manufacturer { get; set; }
        public string description { get; set; }
        public decimal price { get; set; } 

        [ForeignKey("Category")]
        public string categoryId { get; set;}   
        
        
        [ForeignKey("OrderDetail")]
        public string orderDetailId { get; set;}

        public OrderDetail orderDetail { get; set; }
        public virtual Category category { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }

    }
}
