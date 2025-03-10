using OOP_ECOMMERCE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_ECOMMERCE
{



    public class Seller : User, IOrder
    {
        // Ürün ekleme
        public string addProduct(Product product)
        {
            Console.WriteLine("Write the product name");
            product.ProductName = Console.ReadLine();
            Console.WriteLine("Write the product price");
            product.Price = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Write the product stock");
            product.Stock = Convert.ToInt32(Console.ReadLine());
            return "Product added";
        }

        // Ürün kaldırma
        public string removeProduct(Product product)
        {
            return "Product removed";
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
    }

}