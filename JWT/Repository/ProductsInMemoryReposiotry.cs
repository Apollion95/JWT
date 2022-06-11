using JWT.Data;
using JWT.Interfaces;

namespace JWT.Repository
{
    public class ProductsInMemoryReposiotry : IProductsRepository
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product(Guid.NewGuid(), "Jan", true,"JanKowalski@wp.pl","Welcome"),
         new Product(Guid.NewGuid(), "Tomasz", true,"TomaszNowak@wp.pl","Password"),
        };

        public ProductsInMemoryReposiotry()
        {

        }

        public Product Add(Product product)
        {
            var existsProduct = _products.SingleOrDefault(x => x.Id == product.Id);
            if (existsProduct != null)
                throw new Exception($"Product with id: {product.Id} is exosts!");
            else
            {
                _products.Add(product);
            }

            return product;
        }

        public void Delete(Guid id)
        {
            var del = _products.SingleOrDefault(x=>x.Id == id);
             _products.Remove(del);
        }

        public bool Exists(Guid id)
        {
            return _products.Any(x => x.Id.Equals(id));
        }

        public Product Get(Guid id)
        {
            
            var findObj = _products
               .FirstOrDefault(x => x.Id.Equals(id));
            if (findObj == null)
            {
                Console.WriteLine("Product not exists!");
                //throw new Exception("Product not exists!");
            }
            return findObj;
        }

        public List<Product> GetAll()
        {
            return _products;
        }

   

        public void Update(Product product)
        {
            var updateProduct = _products.SingleOrDefault(x=>x.Id == product.Id);
            if(updateProduct != null)
            {
                updateProduct.Name = product.Name;
                updateProduct.IsAvailable = product.IsAvailable;
            }
            else
            {
                Console.WriteLine($"Product with id: {product.Id} is not exists!");
                
            }
           
        }
    }
}
