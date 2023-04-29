using System;
using System.Collections.Generic;

namespace SalesOrderProject.Model
{
    public class Supplier
    {
        public string id { get; set; }

        public string organisationName { get; set; }

        public string organisationAddress { get; set; }

        public ICollection<Order> order { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedOn { get; set; }
    }
}
