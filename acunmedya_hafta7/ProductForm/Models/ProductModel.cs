using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductForm.Models
{
    public class ProductModel
    {
         [Display(Name ="Ürün Id")]
        public int ProductId {get;set;}

        [Display(Name ="Ürün Adı")]
        [StringLength(100)]
        [Required(ErrorMessage = "Ürün Adı Zorunlu")]
        public string? Name {get;set;}

        [Display(Name ="Ürün Fiyatı")]
        [Range(0,100000,ErrorMessage = "Fiyat 0 ile 100000 arasında olmalıdır")]
        [Required(ErrorMessage = "Ürün Fiyatı Zorunlu")]
        public decimal? Price {get;set;}

        [Display(Name ="Ürün Görseli")]
        public string? image {get;set;} = string.Empty;
        public bool IsActive {get;set;}

        [Display(Name ="Ürün Kategorisi")]
        [Required]
        public int? CategoryId {get;set;}
    
    }
}