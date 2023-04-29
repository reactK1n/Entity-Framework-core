using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesOrderProject.Model
{
    public class Customer
    {
        public string id { get; set; }

        public string fullname { get; set; }

        [ForeignKey("Address")]
        public string addressId { get; set; }

        public virtual Address address { get; set; }

        public ICollection<Order> orders { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedOn { get; set; }

    }
}
