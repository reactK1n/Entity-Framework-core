using SalesOrderProject.Data;
using SalesOrderProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace SalesOrderProject.BusinessLogic
{
    public class SalesOrder : ISalesOrder
    {

        private readonly ISalesRepository SalesRepository;
        private readonly IDataFormatting DataFormatting;
        public SalesOrder(ISalesRepository salesRepository, IDataFormatting dataFormatting)
        {
            SalesRepository = salesRepository;
            DataFormatting = dataFormatting;
        }

        public void GetSalesReport()
        {
            var customers = ConfigService.SalesRepository.FetchCustomer();
            var orders = ConfigService.SalesRepository.FetchOrder();
            var orderDetails = ConfigService.SalesRepository.FetchOrderDetails();
            var products = ConfigService.SalesRepository.FetchProduct();
            ConfigService.DataFormatting.PrintRow("Sales Report");
            ConfigService.DataFormatting.PrintSeperatorLine();
            ConfigService.DataFormatting.PrintRow("Order Date", "Name", "OrderNo", "Product", "Amount", "Quatity", "Total Price");
            foreach (var customer in customers)
            {
                ConfigService.DataFormatting.PrintSeperatorLine();
                var order = orders.FirstOrDefault(o => o.customerId == customer.id);
                if (order == null) continue;
                var orderDetail = orderDetails.FirstOrDefault(od => od.orderId == order.id);
                if (orderDetail == null) continue;
                var product = products.FirstOrDefault(p => p.orderDetailId == orderDetail.id);
                if (product == null) continue;
                ConfigService.DataFormatting.PrintRow(
                    order.CreatedOn.ToShortDateString(),
                    customer.fullname,
                    order.orderNo,
                    product.productName,
                    product.price.ToString(),
                    orderDetail.quantity.ToString(),
                    orderDetail.totalPrice.ToString());
            }
        }

        public void GetTop3Deal()
        {
            var customers = ConfigService.SalesRepository.FetchCustomer();
            var orders = ConfigService.SalesRepository.FetchOrder();
            var orderDetails = ConfigService.SalesRepository.FetchOrderDetails().OrderByDescending(p => p.totalPrice).Take(3).ToList();
            var products = ConfigService.SalesRepository.FetchProduct();
            ConfigService.DataFormatting.PrintRow("Top 3 Deal");
            ConfigService.DataFormatting.PrintSeperatorLine();
            ConfigService.DataFormatting.PrintRow("Order Date", "Name", "OrderNo", "Product", "Amount", "Quatity", "Total Price");
            foreach (var od in orderDetails)
            {
                ConfigService.DataFormatting.PrintSeperatorLine();
                var order = orders.FirstOrDefault(o => o.id == od.orderId);
                if (order == null) continue;
                var customer = customers.FirstOrDefault(c => c.id == order.customerId);
                if (customer == null) continue;
                var product = products.FirstOrDefault(p => p.orderDetailId == od.id);
                if (product == null) continue;
                ConfigService.DataFormatting.PrintRow(
                    order.CreatedOn.ToShortDateString(),
                    customer.fullname,
                    order.orderNo,
                    product.productName,
                    product.price.ToString(),
                    od.quantity.ToString(),
                    od.totalPrice.ToString());
            }

        }

        public void GetTopCustomerDeal()
        {
            var customers = ConfigService.SalesRepository.FetchCustomer();
            var orders = ConfigService.SalesRepository.FetchOrder();
            var orderDetails = ConfigService.SalesRepository.FetchOrderDetails();
            var products = ConfigService.SalesRepository.FetchProduct();
            ConfigService.DataFormatting.PrintRow("Top Customer Deal Above 16000");
            ConfigService.DataFormatting.PrintSeperatorLine();
            ConfigService.DataFormatting.PrintRow("Order Date", "Name", "OrderNo", "Product", "Amount", "Quatity", "Total Price");
            foreach (var customer in customers)
            {
                ConfigService.DataFormatting.PrintSeperatorLine();
                var order = orders.FirstOrDefault(o => o.customerId == customer.id);
                if (order == null) continue;
                var orderDetail = orderDetails.FirstOrDefault(od => od.orderId == order.id && od.totalPrice > 16000);
                if (orderDetail == null) continue;
                var product = products.FirstOrDefault(p => p.orderDetailId == orderDetail.id);
                if (product == null) continue;
                ConfigService.DataFormatting.PrintRow(
                    order.CreatedOn.ToShortDateString(),
                    customer.fullname,
                    order.orderNo,
                    product.productName,
                    product.price.ToString(),
                    orderDetail.quantity.ToString(),
                    orderDetail.totalPrice.ToString());
            }
        }

        public void GetCustomerGroupedByCountry()
        {
            List<Address> addressGroupByCountry = new List<Address>();
            var addresses = ConfigService.SalesRepository.FetchAddress();
            foreach (var address in addresses)
            {
                addressGroupByCountry = addresses.Where(p => p.country == address.country).ToList();

            }
            var customers = ConfigService.SalesRepository.FetchCustomer();
            var orders = ConfigService.SalesRepository.FetchOrder();
            var orderDetails = ConfigService.SalesRepository.FetchOrderDetails();
            var products = ConfigService.SalesRepository.FetchProduct();
            ConfigService.DataFormatting.PrintRow("Customer Grouped By Country");
            ConfigService.DataFormatting.PrintSeperatorLine();
            ConfigService.DataFormatting.PrintRow("Order Date", "Name", "Country", "OrderNo", "Product", "Amount", "Quatity", "Total Price");
            foreach (var address in addressGroupByCountry)
            {

                ConfigService.DataFormatting.PrintSeperatorLine();
                var customer = customers.FirstOrDefault(c => c.addressId == address.id);
                if (address == null) continue;          
                var order = orders.FirstOrDefault(o => o.customerId == customer.id);
                if (order == null) continue;
                var orderDetail = orderDetails.FirstOrDefault(od => od.orderId == order.id);
                if (orderDetail == null) continue;
                var product = products.FirstOrDefault(p => p.orderDetailId == orderDetail.id);
                if (product == null) continue;
                ConfigService.DataFormatting.PrintRow(
                    order.CreatedOn.ToShortDateString(),
                    customer.fullname,
                    address.country,
                    order.orderNo,
                    product.productName,
                    product.price.ToString(),
                    orderDetail.quantity.ToString(),
                    orderDetail.totalPrice.ToString());
            }
        }
    }
}
