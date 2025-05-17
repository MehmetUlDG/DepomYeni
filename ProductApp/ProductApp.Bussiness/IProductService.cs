using ProductApp.Entities;
namespace DataAccess.Businness
{
     public interface IProductService{
        List<Product> GetAll();
        Product? GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
     }
}