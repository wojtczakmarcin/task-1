using WebApp.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetProducts();

    }
}
