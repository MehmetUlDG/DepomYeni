using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ürünler
{
    public class Database
    {
          private List<Location> locations;

    public Database()
    {
       
        locations = new List<Location>();
    }

    
    public void AddLocation(Location location)
    {
        locations.Add(location);
        Console.WriteLine($"Veritabanına eklendi: {location}");
    }

    
    public List<Location> GetLocations()
    {
        return locations;
    }
}
    }
