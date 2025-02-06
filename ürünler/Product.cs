using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ürünler
{
    
        public class Product
{
    public string ProductName { get; set; }
    public int Count { get; set; }
    public string ProductID { get; set; }

   
    public Product(string productName, int count, string productId)
    {
        ProductName = productName;
        Count = count;
        ProductID = productId;
    }

        public override string ToString()
    {
        return $"ProductName: {ProductName}, Count: {Count}, ProductID: {ProductID}";
    }
}
    }
