using OOP_ECOMMERCE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace OOP_ECOMMERCE
{
    public class Cart : IOrder
    {
        public List<Product> Products { get; set; }
         // Sepetteki ürünlerin listesi
        public decimal TotalPrice { get; private set; } // Sepetteki ürünlerin toplam fiyatı

        public Cart()
        {
            Products = new List<Product>(); // Yeni bir sepet oluşturduğunda ürün listesi başlatılır
            TotalPrice = 0m; // Toplam fiyat başlangıçta sıfırdır
        }

        // Sepete ürün eklemek için metot
        public void AddProduct(Product product)
        {
            Products.Add(product); // Ürünü sepete ekler
            CalculateTotalPrice(); // Sepetin toplam fiyatını hesaplar
            Console.WriteLine($"{product.ProductName} has been added to the cart.");
        }

        // Sepetten ürün kaldırmak için metot
        public void RemoveProduct(Product product)
        {
            if (Products.Contains(product))
            {
                Products.Remove(product); // Ürünü sepetten kaldırır
                CalculateTotalPrice(); // Sepetin toplam fiyatını yeniden hesaplar
                Console.WriteLine($"{product.ProductName} has been removed from the cart.");
            }
            else
            {
                Console.WriteLine("The product is not in the cart.");
            }
        }

        // Sepetteki toplam fiyatı hesaplamak için metot
        public void CalculateTotalPrice()
        {
            TotalPrice = Products.Sum(p => p.Price); // Ürünlerin fiyatlarının toplamını hesaplar
        }

        // Sipariş oluşturma işlemi
        public string makeOrder(Cart cart)
        {
            if (cart.Products.Count > 0)
            {
                Console.WriteLine("Write your address:");
                string address = Console.ReadLine();
                return "Order has been made successfully with address: " + address;
            }
            return "Cart is empty, no order made.";
        }

        // Siparişi gönderme işlemi
        public string sendOrder(int orderID)
        {
            Console.WriteLine("Write the order ID:");
            int orderIDInput = Convert.ToInt32(Console.ReadLine());

            if (orderIDInput == orderID)
            {
                return "Order is sent.";
            }
            else
            {
                return "Order not found.";
            }
        }

        // Sepetteki ürünleri yazdıran metot
        public void PrintCartDetails()
        {
            if (Products.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
            }
            else
            {
                Console.WriteLine("Your Cart: ");
                foreach (var product in Products)
                {
                    Console.WriteLine($"Product: {product.ProductName}, Price: {product.Price}, Stock: {product.Stock}");
                }
                Console.WriteLine($"Total Price: {TotalPrice}");
            }
        }
    }
}
