using Microsoft.EntityFrameworkCore;
using Products.API.Data;
using Products.API.Entities;

namespace Products.API.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            var productsList = await _dbContext.Products
                         .Where(o => o.Category == category)
                         .ToListAsync();

            return productsList;
        }
    }
}
