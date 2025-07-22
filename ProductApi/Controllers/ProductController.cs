using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Models.Dtos;
using ProductApi.Models.Interfaces;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(
        ICreateProductService createProductService,
        IGetProductsService getProductsService,
        IGetProductByIdService getProductByIdService,
        IUpdateProductService updateProductService,
        IDeleteProductService deleteProductService) : ControllerBase
    {

        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await getProductsService.GetProductsAsync();
        }

        [HttpGet("getProductById/{productId}")]
        public async Task<Product> GetProductById(int productId)
        {
            return await getProductByIdService.GetProductByIdAsync(productId);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(CreateProductRequest createProductRequest)
        {
            var createdProduct = await createProductService.CreateProductAsync(createProductRequest.Name, createProductRequest.Price);
            return createdProduct;
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct(UpdateProductRequest updateProductRequest)
        {
            var productUpdated = await updateProductService.UpdateProductAsync(updateProductRequest);
            if (productUpdated == null || productUpdated.Id == 0)
            {
                return NotFound("Product not found or update failed.");
            }
            return Ok(productUpdated);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteProduct(DeleteProductRequest deleteProductReqest)
        {
            var result = await deleteProductService.DeleteProductAsync(deleteProductReqest);
            if (result == false)
            {
                return NotFound("Product not found or delete failed.");
            }
            return NoContent();
        }
    }
}
