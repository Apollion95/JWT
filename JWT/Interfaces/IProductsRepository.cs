using JWT.Data;

namespace JWT.Interfaces
{
    public interface IProductsRepository
    {
        bool Exists(Guid id);
        public Product Get(Guid id);
        public List<Product> GetAll();
        public Product Add(Product product);
        public void Update(Product product);
        public void Delete(Guid id);
    }
}
