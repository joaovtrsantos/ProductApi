namespace ProductApi.Models.Interfaces
{
    public interface ICreateProductService
    {
        Task<Product> CreateProductAsync(string name, int price);
    }
}
