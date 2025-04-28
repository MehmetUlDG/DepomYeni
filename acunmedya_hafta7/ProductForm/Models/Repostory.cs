using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductForm.Models
{
    public class Repostory
    {

        private static readonly List<ProductModel> products = new List<ProductModel>();
        private static readonly List<CategoryModel> categories = new List<CategoryModel>();

        static Repostory(){
            categories.Add(new CategoryModel { CategoryId = 1, Name = "Akıllı Telefonlar" });
            categories.Add(new CategoryModel { CategoryId = 2, Name = "Bilgisayarlar" });
            products.Add(new ProductModel { ProductId = 1, Name = "Iphone 15", Price = 80000,image= "Iphone15.jpg" ,CategoryId = 1, IsActive = true });
             products.Add(new ProductModel { ProductId = 2, Name = "Iphone 15 Pro", Price = 100000,image= "Iphone15Pro.jpg" ,CategoryId = 1, IsActive = true });
              products.Add(new ProductModel { ProductId = 3, Name = "Macbook Air", Price = 90000,image= "Mac1.jpg" ,CategoryId = 1, IsActive = true });
               products.Add(new ProductModel { ProductId = 4, Name = "Macbook Pro", Price = 120000,image= "Mac2.jpg" ,CategoryId = 1, IsActive = true });
        }
          public static List<ProductModel> Products{get{return products;}}

        public static void CreateProduct(ProductModel entity){
            products.Add(entity);
        }

        public static void EditProduct(ProductModel updateProduct){
            var entity = products.FirstOrDefault(p=>p.ProductId == updateProduct.ProductId);

            if(entity != null){
                if(!string.IsNullOrEmpty(updateProduct.Name)){
                entity.Name = updateProduct.Name;
                }
                entity.Price = updateProduct.Price;
                entity.image = updateProduct.image;
                entity.IsActive = updateProduct.IsActive;
                entity.CategoryId = updateProduct.CategoryId;
            }
        }

        public static void EditIsActive(ProductModel updateProduct){
            var entity = products.FirstOrDefault(p=>p.ProductId == updateProduct.ProductId);

            if(entity != null){
                entity.IsActive = updateProduct.IsActive;
            }
        }

        public static void DeleteProduct(ProductModel entity){
            var PrdEntity = products.FirstOrDefault(p=>p.ProductId == entity.ProductId);
            if(PrdEntity != null){
                products.Remove(PrdEntity);
            }
        }
        public static List<CategoryModel> Categories{get{return categories;}}

    }
    }
