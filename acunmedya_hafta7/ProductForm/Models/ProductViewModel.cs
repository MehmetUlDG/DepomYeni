using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductForm.Models
{
    public class ProductViewModel
    {
           public List<ProductModel> Products {get;set;} = null!;
        public List<CategoryModel> Categories {get;set;} = null!;
        public string? SelectedCategory {get;set;}
    }
}