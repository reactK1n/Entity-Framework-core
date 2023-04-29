using SalesOrderProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesOrderProject.BusinessLogic
{
    public static class ConfigService
    {
        public static IDataFormatting DataFormatting;
        public static ISalesOrder SalesOrder;
        public static ISalesRepository SalesRepository;
        static ConfigService()
        {
            DataFormatting = new DataFormatting();
            SalesRepository = new SalesRepository();
            SalesOrder = new SalesOrder(SalesRepository, DataFormatting);
        }
    }
}
