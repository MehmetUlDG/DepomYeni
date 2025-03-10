using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_ECOMMERCE
{
    namespace OOP_ECOMMERCE
    {
        public class BankTransferPayment : IPayment
        {
            private string bankName;
            private string bankAccount;
            private string bankBranch;

            public string BankName
            {
                get => bankName;
                set
                {
                    bankName = value;
                }
            }

            public string BankAccount
            {
                get => bankAccount;
                set
                {
                    bankAccount = value;
                }
            }

            public string BankBranch
            {
                get => bankBranch;
                set
                {
                    bankBranch = value;
                }
            }

            // Banka transferi ile ödeme işlemi
            public void PayOfBankTransfer()
            {
                Console.WriteLine("Please enter your bank name:");
                bankName = Console.ReadLine();
                Console.WriteLine("Please enter your bank account number:");
                bankAccount = Console.ReadLine();
                Console.WriteLine("Please enter your bank branch:");
                bankBranch = Console.ReadLine();

                // Ödeme işlemi başarılı
                Console.WriteLine("Payment with Bank Transfer is completed successfully.");
            }

            // Kredi kartı ile ödeme işlemi yapılmaz
            public void PayOfCreditCard()
            {
                Console.WriteLine("This method is not available for Bank Transfer payment.");
            }
        }
    }

}