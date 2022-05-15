using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Models.Repositories;

namespace VShop.ProductApi.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper _mapper)
        {
            _productRepository = productRepository;
            this._mapper = _mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }
        public async Task<ProductDTO> GetProductById(int id)
        {
            var productsEntity = await _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(productsEntity);
        }
        public async Task AddProduct(ProductDTO productDto)
        {
            var productsEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Create(productsEntity);
            productDto.Id = productsEntity.Id;
        }
        public async Task UpdateProduct(ProductDTO productDto)
        {
            var productsEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Update(productsEntity);
        }
        public async Task RemoveProduct(int id)
        {
            var productsEntity = _productRepository.GetById(id).Result;
            await _productRepository.Delete(productsEntity.Id);
        }
    }
}
