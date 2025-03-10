using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OOP_ECOMMERCE
{
    public class Order : IOrder
    {
        public int OrderId { get; set; }

        // Sipariş oluşturma
        public string makeOrder(Cart cart)
        {
            if (cart.Products.Count > 0)
            {
                Console.WriteLine("Write your address");
                string address = Console.ReadLine();
                return "Order is made successfully";
            }
            return "Cart is empty";
        }

        // Sipariş gönderme
        public string sendOrder(int orderID)
        {
            Console.WriteLine("Write the orderID");
            int orderIDInput = Convert.ToInt32(Console.ReadLine());
            if (orderIDInput == orderID)
            {
                return "Order is sent";
            }
            else
            {
                return "Order is not sent";
            }
        }
    }

}