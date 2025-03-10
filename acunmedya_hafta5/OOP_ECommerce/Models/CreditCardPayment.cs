using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_ECOMMERCE
{


    namespace OOP_ECOMMERCE
    {
        public class CreditCardPayment : IPayment
        {
            private string cardNumber;
            private string expirationDate;
            private string cvv;

            public string CardNumber
            {
                get => cardNumber;
                set
                {
                    cardNumber = value;
                }
            }

            public string ExpirationDate
            {
                get => expirationDate;
                set
                {
                    expirationDate = value;
                }
            }

            public string Cvv
            {
                get => cvv;
                set
                {
                    cvv = value;
                }
            }

            // Kredi kartı ile ödeme işlemi
            public void PayOfCreditCard()
            {
                Console.WriteLine("Please enter your card number:");
                cardNumber = Console.ReadLine();
                Console.WriteLine("Please enter your expiration date (MM/YY):");
                expirationDate = Console.ReadLine();
                Console.WriteLine("Please enter your CVV:");
                cvv = Console.ReadLine();

                // Ödeme işlemi başarılı
                Console.WriteLine("Payment with Credit Card is completed successfully.");
            }

            // Banka transferi ile ödeme işlemi yapılmaz
            public void PayOfBankTransfer()
            {
                Console.WriteLine("This method is not available for Credit Card payment.");
            }
        }
    }



}

