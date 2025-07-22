using Microsoft.EntityFrameworkCore;
using ProductApi.Infrastructure.Context;
using ProductApi.Models.Dtos;
using ProductApi.Models.Interfaces;

namespace ProductApi.Services
{
    public class DeleteProductService : IDeleteProductService
    {
        private readonly ProductDbContext _context;

        public DeleteProductService(ProductDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteProductAsync(DeleteProductRequest deleteProductRequest)
        {
            var productToBeDeleted = await _context.Products.SingleOrDefaultAsync(p => p.Id == deleteProductRequest.ProductId);
            if (productToBeDeleted == null)
            {
                return false;
            }
            _context.Products.Remove(productToBeDeleted);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
