using Microsoft.EntityFrameworkCore;
using ProductApi.Infrastructure.Context;
using ProductApi.Models;
using ProductApi.Models.Dtos;
using ProductApi.Models.Interfaces;

namespace ProductApi.Services
{
    public class UpdateProductService : IUpdateProductService
    {
        private readonly ProductDbContext _context;
        public UpdateProductService(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Product> UpdateProductAsync(UpdateProductRequest updateProductRequest)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == updateProductRequest.ProductId);
            if (product != null)
            {
                product.Price = updateProductRequest.Price;
                product.Name = updateProductRequest.Name;
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return product;
            }
            return new Product();
        }
    }
}
