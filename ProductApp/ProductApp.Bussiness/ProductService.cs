using DataAccess.Businness;
using ProductApp.DataAccess;
using ProductApp.Entities;
namespace ProductApp.Bussiness
{

    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }
        public void Add(Product product)
        {
            _repo.Add(product);
            _repo.Save();
        }


        public void Delete(int id)
        {
            var product = _repo.GetById(id);
            if (product != null)
            {
                _repo.Delete(product);
            }
            _repo.Save();
        }



        public List<Product> GetAll() => _repo.GetAll();

        public Product? GetById(int id) => _repo.GetById(id);

        public void Update(Product product)
        {
            var existing = _repo.GetById(product.ProductId);
            if (existing == null) throw new Exception("Ürün bulunamadı.");
            existing.ProductName = product.ProductName;
            existing.ProductGuid = product.ProductGuid;
            existing.Price = product.Price;
            existing.Category = product.Category;
            existing.CreatedAt = product.CreatedAt;
            existing.Description = product.Description;
            _repo.Update(existing);
            _repo.Save();


        }

    }
}

