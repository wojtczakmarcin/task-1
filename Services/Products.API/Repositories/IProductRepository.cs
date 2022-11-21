using Products.API.Entities;

namespace Products.API.Repositories
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductByCategory(string category);
    }
}
