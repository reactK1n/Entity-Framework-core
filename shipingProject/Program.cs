using SalesOrderProject.BusinessLogic;
using System;

namespace SalesOrderProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigService.SalesOrder.GetSalesReport();
            Console.WriteLine();
            ConfigService.SalesOrder.GetTopCustomerDeal();
            Console.WriteLine();
            ConfigService.SalesOrder.GetTop3Deal();
            Console.WriteLine();
            ConfigService.SalesOrder.GetCustomerGroupedByCountry();
            Console.ReadLine();

        }
    }
}
