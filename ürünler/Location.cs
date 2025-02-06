using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ürünler
{
    public class Location
    {
         public string City { get; set; }
    public string District { get; set; }

    
    public Location(string city, string district)
    {
        City = city;
        District = district;
    }

    public override string ToString()
    {
        return $"City: {City}, District: {District}";
    }
}
    }
