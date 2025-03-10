using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OOP_ECOMMERCE.OOP_ECOMMERCE;


namespace OOP_ECOMMERCE
    {
        class Program
        {
            static void Main(string[] args)
            {
                User user = null; // Kullanıcı nesnesi
                int choice = 0;

                Console.WriteLine("Welcome to our E-commerce site!");
                Console.WriteLine("Login as: 1-Admin 2-Customer");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Admin olarak giriş
                        Console.WriteLine("Welcome Admin!");
                        user = new Seller(); // Admin (Seller) seçildi
                        user.Login(); // Giriş işlemi
                        AdminOperations((Seller)user); // Admin işlemleri
                        break;

                    case 2:
                        // Customer olarak giriş
                        Console.WriteLine("Welcome Customer!");
                        user = new Customer(); // Müşteri (Customer) seçildi
                        user.Login(); // Giriş işlemi
                        CustomerOperations((Customer)user); // Müşteri işlemleri
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            // Admin işlemleri
            static void AdminOperations(Seller seller)
            {
                int choice = 0;

                Console.WriteLine("1-Add Product 2-Remove Product 3-Send Order 4-Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Product product = new Product();
                        Console.WriteLine(seller.addProduct(product)); // Ürün ekleme
                        break;
                    case 2:
                        Product removeProduct = new Product();
                        Console.WriteLine(seller.removeProduct(removeProduct)); // Ürün kaldırma
                        break;
                    case 3:
                        Console.WriteLine(seller.sendOrder(1234)); // Siparişi gönder
                        break;
                    case 4:
                        Console.WriteLine("Exiting Admin Panel.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            // Müşteri işlemleri
            static void CustomerOperations(Customer customer)
            {
                int choice = 0;

                Console.WriteLine("1-Buy Product 2-Make Order 3-Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Product product = new Product();
                        Console.WriteLine(customer.buyProduct(product)); // Ürün satın alma
                        
                        break;
                    case 2:
                        Cart cart = new Cart();
                        Console.WriteLine(customer.makeOrder(cart)); // Sipariş oluşturma
                        Console.WriteLine("Select to payment methods 1-pay of bank transfer  2-pay of credit card");
                           int Choice = Convert.ToInt32(Console.ReadLine());
                           if (Choice == 1)
                             {
                                  BankTransferPayment payment = new BankTransferPayment();
                                  Console.WriteLine(payment.PayOfBankTransfer);
                          }
                           else if (Choice == 2)
                            {
                                     CreditCardPayment payment = new CreditCardPayment();
                                     Console.WriteLine(payment.PayOfCreditCard);
                         }
                                     else
                                        Console.WriteLine("invalid choice");
                        break;
                    case 3:
                        Console.WriteLine("Exiting Customer Panel.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }


