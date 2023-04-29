using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesOrderProject.Model
{
    public class Address
    {
        public string id { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
    }
}
