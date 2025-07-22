namespace ProductApi.Models.Dtos
{
    public record UpdateProductRequest(int ProductId, string Name, int Price);
}
