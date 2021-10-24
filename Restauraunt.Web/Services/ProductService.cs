using Restauraunt.Web.Models;
using Restauraunt.Web.Services.IServices;

namespace Restauraunt.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.APIType.POST,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/products",
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.APIType.DELETE,
                Url = SD.ProductAPIBase + "/api/products/" + id,
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.APIType.GET,
                Url = SD.ProductAPIBase + "/api/products",
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.APIType.GET,
                Url = SD.ProductAPIBase + "/api/products/" + id,
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.APIType.PUT,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/products",
            });
        }
    }
}
