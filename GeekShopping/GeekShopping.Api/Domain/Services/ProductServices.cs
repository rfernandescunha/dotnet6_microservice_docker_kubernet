﻿using AutoMapper;
using GeekShopping.Api.Domain.Dto;
using GeekShopping.Api.Domain.Entities;
using GeekShopping.Api.Domain.Interfaces.IRepository;
using GeekShopping.Api.Domain.Interfaces.IServices;

namespace GeekShopping.Api.Domain.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductServices(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Create(ProductDto product)
        {
            var obj = _mapper.Map<Product>(product);

            var result = await _productRepository.Create(obj);

            return _mapper.Map<ProductDto>(result);
        }

        public async Task<bool> Delete(long Id)
        {
            var result = await _productRepository.Delete(Id);

            return result;
        }

        public async Task<IEnumerable<ProductDto>> FindAll()
        {

            var result = await _productRepository.FindAll();

            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<ProductDto> FindById(long Id)
        {            

            var result = await _productRepository.FindById(Id);

            return _mapper.Map<ProductDto>(result);
        }

        public async Task<ProductDto> Update(ProductDto product)
        {
            var obj = _mapper.Map<Product>(product);

            var result = await _productRepository.Update(obj);

            return _mapper.Map<ProductDto>(result);
        }
    }
}
