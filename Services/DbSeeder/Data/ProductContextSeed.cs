using DbSeeder.Entities;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DbSeeder.Data
{
    public class ProductContextSeed
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ProductContext _context;
        private readonly ILogger<ProductContextSeed> _logger;

        public ProductContextSeed(IWebHostEnvironment hostEnvironment, ProductContext context, ILogger<ProductContextSeed> logger)
        {
            _hostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task SeedAsync()
        {
            if (!_context.Products.Any())
            {
                _context.Products.AddRange(GetPreconfiguredProducts());
                await _context.SaveChangesAsync();
                _logger.LogInformation("Seed database successfully - {DbContextName}", typeof(ProductContext).Name);
            }
        }

        private IEnumerable<Product> GetPreconfiguredProducts()
        {
            List<Product>? productList = null;

            try
            {
                string path = Path.Combine(_hostEnvironment.ContentRootPath, @"Data/ProductsList.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("Products"));

                string content = System.IO.File.ReadAllText(path);
                StringReader stringReader = new StringReader(content);

                productList = (List<Product>?)serializer.Deserialize(stringReader);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Seed from file error - {DbContextName}", typeof(ProductContext).Name);
            }

            if (productList == null)
            {
                return new List<Product>();
            }

            foreach (Product product in productList)
            {
                product.CreatedDate = DateTime.Now;
            }

            return productList;
        }
    }
}
