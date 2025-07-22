using ProductApi.Infrastructure.Context;
using ProductApi.Models;
using ProductApi.Models.Interfaces;

namespace ProductApi.Services
{
    public class CreateProductService : ICreateProductService
    {
        private readonly ProductDbContext _context;

        public CreateProductService(ProductDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateProductAsync(string name, int price)
        {
            var product = new Product
            {
                Name = name,
                Price = price
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
