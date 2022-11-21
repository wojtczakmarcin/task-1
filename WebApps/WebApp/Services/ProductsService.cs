using WebApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApp.Extensions;

namespace WebApp.Services
{
    public class ProductsService : IProductsService
    {
        private readonly HttpClient _client;

        public ProductsService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var response = await _client.GetAsync("/api/v1/Products");
            return await response.ReadContentAs<List<Product>>();
        }
    }
}
