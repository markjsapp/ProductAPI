using Services.Product.API.Models.Dto;

namespace Services.Product.API.Repository
{
    public interface IProductRepository 
    {
        // Remember we need this to be asyncronous and we only want to work with and return DTOs with the API 
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductID(int productId);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);    
    }
}
