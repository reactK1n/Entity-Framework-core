
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesOrderProject.Model
{
    public class Order
    {
        public string id { get; set; }

        public string orderNo { get; set; }

        [ForeignKey("Customer")]
        public string customerId { get; set; }
        public Customer customer { get; set; }


        [ForeignKey("Supplier")]
        public string supplierId { get; set; }

        public virtual Supplier supplier { get; set; }

        public virtual OrderDetail orderDetail { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
       
        public DateTime? UpdatedOn { get; set; }

    }
}
