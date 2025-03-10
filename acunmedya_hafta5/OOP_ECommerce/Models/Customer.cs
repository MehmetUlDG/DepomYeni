using OOP_ECOMMERCE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_ECOMMERCE
{
    public class Customer : User
    {
        public string Address { get; set; }

        // Ürün satın alma
        public string buyProduct(Product product)
        {
            if (product.Stock > 0)
            {
                product.Stock--;
                return "Product is bought successfully";
            }
            return "Product is out of stock";
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
