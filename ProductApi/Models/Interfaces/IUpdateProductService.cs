using ProductApi.Models.Dtos;

namespace ProductApi.Models.Interfaces
{
    public interface IUpdateProductService
    {
        Task<Product> UpdateProductAsync(UpdateProductRequest product);
    }
}
