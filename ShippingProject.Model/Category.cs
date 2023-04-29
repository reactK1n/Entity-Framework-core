using System;
using System.Collections.Generic;

namespace SalesOrderProject.Model
{
    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public ICollection<Product> products { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }

    }
}
