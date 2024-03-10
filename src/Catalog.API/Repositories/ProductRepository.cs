using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    /// <summary>
    /// Repository for product entity 
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="context"></param>
        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task CreateProductAsync(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        /// <summary>
        /// Delete a product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> DeleteProductAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetProductAsync(string id)
        {
            return await _context
                    .Products
                    .Find(x => x.Id == id)
                    .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get all the products 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context
                    .Products
                    .Find(x => true)
                    .ToListAsync();
        }

        public Task<IEnumerable<Product>> GetProductsByCategoryAsync(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
