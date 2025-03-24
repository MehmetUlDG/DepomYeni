using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCvWebSite.Models
{
       public class MyCvModel
    {
        public int Id { get; set; }
         public string? Name { get; set; }
        public string? Surname { get; set; }

        public string? Email { get; set; }

        public string? github { get; set; }
        public string? linkedin { get; set; }

        public string? Education { get; set; }
        public string? Experience { get; set; }
        public string? Skills { get; set; }
        public string? Projects { get; set; }
        public string? Certificates { get; set; }
        public string? Languages { get; set; }
        public string? Description { get; set; }
    
        public string? Image { get; set; }
    }  
      
    }