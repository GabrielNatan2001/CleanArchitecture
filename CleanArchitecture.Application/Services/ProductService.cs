using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GeByIdAsync(int? id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        {
            var entity = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var entity = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(entity);
        }
        public async Task Add(ProductDTO productDto)
        {
            var entity = _mapper.Map<Product>(productDto);
            await _productRepository.CreateAsync(entity);
        }

        public async Task Remove(int? id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            await _productRepository.RemoveAsync(entity);
        }

        public async Task Update(ProductDTO productDto)
        {
            var entity = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(entity);
        }
    }
}
