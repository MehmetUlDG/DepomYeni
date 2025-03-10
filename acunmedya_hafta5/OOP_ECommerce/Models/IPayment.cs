using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_ECOMMERCE
{
    public interface IPayment
    {
        public void PayOfBankTransfer();
        public void PayOfCreditCard();
    }
}