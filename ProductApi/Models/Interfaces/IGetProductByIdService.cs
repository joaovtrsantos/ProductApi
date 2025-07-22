using ProductApi.Models.Dtos;

namespace ProductApi.Models.Interfaces
{
    public interface IGetProductByIdService
    {
        Task<Product> GetProductByIdAsync(int productId);
    }
}
