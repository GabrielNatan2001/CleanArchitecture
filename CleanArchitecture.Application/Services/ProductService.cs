using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Products.Commands;
using CleanArchitecture.Application.Products.Queries;
using MediatR;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            //var entity = await _productRepository.GetProductsAsync();
            //return _mapper.Map<IEnumerable<ProductDTO>>(entity);
            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
                throw new Exception("entity could not be loaded");

            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GeByIdAsync(int? id)
        {
            //var entity = await _productRepository.GetByIdAsync(id);
            //return _mapper.Map<ProductDTO>(entity);

            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new Exception("entity could not be loaded");

            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        //{
        //    //var entity = await _productRepository.GetProductCategoryAsync(id);
        //    //return _mapper.Map<ProductDTO>(entity);
        //    var productByIdQuery = new GetProductByIdQuery(id.Value);

        //    if (productByIdQuery == null)
        //        throw new Exception("entity could not be loaded");

        //    var result = await _mediator.Send(productByIdQuery);
        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task Add(ProductDTO productDto)
        {
            //var entity = _mapper.Map<Product>(productDto);
            //await _productRepository.CreateAsync(entity);

            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDto)
        {
            //var entity = _mapper.Map<Product>(productDto);
            //await _productRepository.UpdateAsync(entity);
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            //var entity = await _productRepository.GetByIdAsync(id);
            //await _productRepository.RemoveAsync(entity);
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
                throw new Exception("entity could not be loaded");

            await _mediator.Send(productRemoveCommand);
        }
    }
}
