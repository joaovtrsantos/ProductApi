using ProductApi.Models.Dtos;

namespace ProductApi.Models.Interfaces
{
    public interface IDeleteProductService
    {
        Task<bool> DeleteProductAsync(DeleteProductRequest deleteProductRequest);
    }
}
