using Microsoft.EntityFrameworkCore;
using ProductApi.Infrastructure.Context;
using ProductApi.Models;
using ProductApi.Models.Interfaces;

namespace ProductApi.Services
{
    public class GetProductsService : IGetProductsService
    {
        private readonly ProductDbContext _context;

        public GetProductsService(ProductDbContext productDbContext)
        {
            _context = productDbContext;
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return _context.Products.ToListAsync();
        }
    }
}
