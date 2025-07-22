using Microsoft.EntityFrameworkCore;
using ProductApi.Infrastructure.Context;
using ProductApi.Models;
using ProductApi.Models.Interfaces;

namespace ProductApi.Services
{
    public class GetProductByIdService : IGetProductByIdService
    {
        private readonly ProductDbContext _context;
        public GetProductByIdService(ProductDbContext context)
        {
            _context = context;
        }
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products.SingleAsync(p => p.Id == productId);
        }
    }
}
