using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderProject.BusinessLogic
{
    public interface ISalesOrder
    {
        public void GetSalesReport();
        public void GetTopCustomerDeal();

        public void GetTop3Deal();

        public void GetCustomerGroupedByCountry();
    }
}
