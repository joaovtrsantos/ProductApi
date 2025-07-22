namespace ProductApi.Models.Interfaces
{
    public interface IGetProductsService
    {
        Task<List<Product>> GetProductsAsync();
    }
}
