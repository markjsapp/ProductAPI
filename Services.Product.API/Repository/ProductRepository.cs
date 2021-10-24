using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.Product.API.DBContext;
using Services.Product.API.Models;
using Services.Product.API.Models.Dto;

namespace Services.Product.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> GetProductID(int productId)
        {
            Products products = await _db.Products.Where(x => x.ProductID == productId).FirstOrDefaultAsync();
                return _mapper.Map<ProductDto>(products);
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            // Converting the DTO 
            Products products = _mapper.Map<ProductDto, Products>(productDto);
            // If the product is already created 
            if(products.ProductID > 0)
            {
                // Update DTO
                _db.Products.Update(products);
            }
            else
            {
                // Otherwise create 
                _db.Products.Add(products);
            }
            await _db.SaveChangesAsync();
            // Convert using automapper and return 
            return _mapper.Map<Products, ProductDto>(products);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Products product = await _db.Products.FirstOrDefaultAsync(u => u.ProductID == productId);
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Products> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
