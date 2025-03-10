using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_ECOMMERCE
{
    public interface IOrder
    {
        string makeOrder(Cart cart);  // Sipariş oluşturma
        string sendOrder(int orderID); // Siparişi gönderme
    }

}