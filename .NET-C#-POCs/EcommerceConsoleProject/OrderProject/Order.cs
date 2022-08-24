using CustomerProject;
using EcommerceConsoleProject;
using ProductProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject
{
    public class Order
    {
        List<OrderDetails> orders = new List<OrderDetails>();
        public List<OrderDetails> AddOrder()
        {
            OrderDetails order = new OrderDetails();
            Console.WriteLine("Enter following information to add new Order:");
            Console.WriteLine("Enter Order Id");
            order.OrderDetailsId= int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Order Quantity ");
            order.QuantityOrder = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Order Total Amount");
            order.TotalAmount = int.Parse(Console.ReadLine());
            Console.WriteLine("Order ID:" + order.OrderDetailsId +"\n"+ "Order quantity:" + order.QuantityOrder + "\n" + " Order TotalAmount:" + order.TotalAmount);

            return orders;
        }
           }
}
